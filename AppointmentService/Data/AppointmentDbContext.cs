using Microsoft.EntityFrameworkCore;
using AppointmentService.Models;

namespace AppointmentService.Data
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Appointments
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, UserId = 1, AppointmentDate = new DateTime(2024, 12, 25, 10, 0, 0), Description = "Dental check-up", IsDeleted = false },
                new Appointment { Id = 2, UserId = 1, AppointmentDate = new DateTime(2024, 12, 27, 9, 0, 0), Description = "Annual physical exam", IsDeleted = false },
                new Appointment { Id = 3, UserId = 2, AppointmentDate = new DateTime(2025, 01, 02, 9, 0, 0), Description = "Regular checkup", IsDeleted = false },
                new Appointment { Id = 4, UserId = 2, AppointmentDate = new DateTime(2025, 01, 07, 9, 0, 0), Description = "Physical exam", IsDeleted = false },
                new Appointment { Id = 5, UserId = 3, AppointmentDate = new DateTime(2025, 02, 05, 9, 0, 0), Description = "Blood Test", IsDeleted = false }
            );
        }
    }
}
