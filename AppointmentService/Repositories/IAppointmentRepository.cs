using AppointmentService.Models;

namespace AppointmentService.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<(List<Appointment> AppointmentList, int TotalAppointments)> GetAllAppointmentsByUserAsync(int userId, int pageNumber, int pageSize);
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task<Appointment> CreateAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(int id);
    }
}
