using AutoMapper;
using Microsoft.Extensions.Logging;
using AppointmentService.DTOs;
using AppointmentService.Models;
using AppointmentService.Repositories;

namespace AppointmentService.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AppointmentService> _logger;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, ILogger<AppointmentService> logger)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsAsync()
        {
            try
            {
                var appointments = await _appointmentRepository.GetAllAppointmentsAsync();
                return _mapper.Map<IEnumerable<AppointmentDTO>>(appointments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all appointments.");
                throw;
            }
        }
        public async Task<(List<AppointmentDTO> AppointmentList, int TotalAppointments)> GetAllAppointmentsByUserAsync(int userId, int pageNumber, int pageSize)
        {
            try
            {
                var appointments = await _appointmentRepository.GetAllAppointmentsByUserAsync(userId, pageNumber, pageSize);
                var appointmentList = _mapper.Map<List<AppointmentDTO>>(appointments.AppointmentList);

                return (appointmentList, appointments.TotalAppointments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting all appointments for user: {userId}.");
                throw;
            }
        }

        public async Task<AppointmentDTO> GetAppointmentByIdAsync(int id)
        {
            try
            {
                var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);
                return _mapper.Map<AppointmentDTO>(appointment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting appointment with ID {id}.");
                throw;
            }
        }

        public async Task<AppointmentDTO> CreateAppointmentAsync(AppointmentDTO appointmentDto)
        {
            try
            {
                var appointment = _mapper.Map<Appointment>(appointmentDto);
                var createdAppointment = await _appointmentRepository.CreateAppointmentAsync(appointment);
                return _mapper.Map<AppointmentDTO>(createdAppointment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new appointment.");
                throw;
            }
        }

        public async Task UpdateAppointmentAsync(int id, AppointmentDTO appointmentDto)
        {
            try
            {
                var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);
                if (appointment == null)
                {
                    throw new KeyNotFoundException($"Appointment with ID {id} not found.");
                }

                _mapper.Map(appointmentDto, appointment);
                await _appointmentRepository.UpdateAppointmentAsync(appointment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating appointment with ID {id}.");
                throw;
            }
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            try
            {
                await _appointmentRepository.DeleteAppointmentAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting appointment with ID {id}.");
                throw;
            }
        }
    }
}