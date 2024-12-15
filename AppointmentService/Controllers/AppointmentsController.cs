using Microsoft.AspNetCore.Mvc;
using AppointmentService.DTOs;
using AppointmentService.Service;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AppointmentService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAppointments()
        {
            try
            {
                var appointments = await _appointmentService.GetAllAppointmentsAsync();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong. Please try again later" });
            }
        }
        [HttpGet("user")]
        public async Task<IActionResult> GetAppointmentsByUser([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var appointments = await _appointmentService.GetAllAppointmentsByUserAsync(Convert.ToInt32(userId),pageNumber,pageSize); 
            var totalAppointments = appointments.TotalAppointments;
            var totalPages = (int)Math.Ceiling(totalAppointments / (double)pageSize);

            return Ok(new
            {
                appointments = appointments.AppointmentList,
                totalPages
            });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong. Please try again later" });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDTO>> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentDTO>> PostAppointment(AppointmentDTO appointmentDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            appointmentDto.UserId = Convert.ToInt32(userId);

            var createdAppointment = await _appointmentService.CreateAppointmentAsync(appointmentDto);
            return CreatedAtAction(nameof(GetAppointment), new { id = createdAppointment.Id }, createdAppointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, AppointmentDTO appointmentDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            appointmentDto.UserId = Convert.ToInt32(userId);

            try
            {
                await _appointmentService.UpdateAppointmentAsync(id, appointmentDto);
                return Ok(new { message = "Appointment updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);
            return NoContent();
        }
    }
}