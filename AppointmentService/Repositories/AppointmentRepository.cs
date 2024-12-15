using Microsoft.EntityFrameworkCore;
using AppointmentService.Data;
using AppointmentService.Models;

namespace AppointmentService.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentDbContext _context;

        public AppointmentRepository(AppointmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments.ToListAsync();
        }
        public async Task<(List<Appointment> AppointmentList, int TotalAppointments)> GetAllAppointmentsByUserAsync(int userId, int pageNumber, int pageSize)
        {
            var totalAppointments = await _context.Appointments
            .Where(a => a.UserId == userId && !a.IsDeleted)
            .CountAsync();

            var appointments = await _context.Appointments
                .Where(a => a.UserId == userId && !a.IsDeleted)
                .OrderByDescending(x=>x.AppointmentDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (appointments, totalAppointments);
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            var appointment = await GetAppointmentByIdAsync(id);
            if (appointment != null)
            {
                appointment.IsDeleted = true;
                _context.Appointments.Update(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }
}