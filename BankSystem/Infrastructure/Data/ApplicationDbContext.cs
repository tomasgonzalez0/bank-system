using BankSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
                .Property(l => l.Amount)
                .HasColumnType("decimal(18,2)");

            var userPassword = BCrypt.Net.BCrypt.HashPassword("123");
            var adminPassword = BCrypt.Net.BCrypt.HashPassword("123");

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "usuario@test.com", PasswordHash = "123", IsAdmin = false },
                new User { Id = 2, Email = "admin@test.com", PasswordHash = "123", IsAdmin = true }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
