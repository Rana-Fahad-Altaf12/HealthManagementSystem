using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var hashedPasswordFahad = BCrypt.Net.BCrypt.HashPassword("fahad123");
            var hashedPasswordAli = BCrypt.Net.BCrypt.HashPassword("ali123");
            var hashedPasswordHamza = BCrypt.Net.BCrypt.HashPassword("hamza123");

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "fahad", Password = hashedPasswordFahad, Email = "fahad@gmail.com" },
                new User { Id = 2, Username = "ali", Password = hashedPasswordAli, Email = "ali@gmail.com" },
                new User { Id = 3, Username = "hamza", Password = hashedPasswordHamza, Email = "hamza@gmail.com" }
            );
        }
    }
}
