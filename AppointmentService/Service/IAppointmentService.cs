using AppointmentService.DTOs;

namespace AppointmentService.Service
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsAsync();
        Task<(List<AppointmentDTO> AppointmentList, int TotalAppointments)> GetAllAppointmentsByUserAsync(int userId, int pageNumber, int pageSize);
        Task<AppointmentDTO> GetAppointmentByIdAsync(int id);
        Task<AppointmentDTO> CreateAppointmentAsync(AppointmentDTO appointmentDto);
        Task UpdateAppointmentAsync(int id, AppointmentDTO appointmentDto);
        Task DeleteAppointmentAsync(int id);
    }
}
