namespace AppointmentService.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
    }
}
