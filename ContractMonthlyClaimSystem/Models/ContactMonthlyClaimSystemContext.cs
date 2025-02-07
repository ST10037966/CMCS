using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactMonthlyClaimSystem.Models
{
    public class ContactMonthlyClaimSystemContext : IdentityDbContext<ApplicationUser>
    {
        public ContactMonthlyClaimSystemContext(DbContextOptions<ContactMonthlyClaimSystemContext> options)
            : base(options)
        {
        }

        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<MonthlyClaim> MonthlyClaims { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 Seed Sample Lecturers
            modelBuilder.Entity<Lecturer>().HasData(
                new Lecturer { LecturerId = 1, FullName = "John Doe", Email = "john.doe@example.com" },
                new Lecturer { LecturerId = 2, FullName = "Jane Smith", Email = "jane.smith@example.com" }
            );

            // 🔹 Seed Sample Claims
            modelBuilder.Entity<MonthlyClaim>().HasData(
                new MonthlyClaim
                {
                    MonthlyClaimId = 1,
                    Description = "January Teaching Hours",
                    HoursWorked = 20,
                    HourlyRate = 50,
                    Status = "Pending",
                    SubmissionDate = DateTime.Now.AddDays(-7),
                    LecturerId = 1
                },
                new MonthlyClaim
                {
                    MonthlyClaimId = 2,
                    Description = "Research Assistance",
                    HoursWorked = 10,
                    HourlyRate = 45,
                    Status = "Approved",
                    SubmissionDate = DateTime.Now.AddDays(-14),
                    LecturerId = 2
                },
                new MonthlyClaim
                {
                    MonthlyClaimId = 3,
                    Description = "Guest Lecture",
                    HoursWorked = 5,
                    HourlyRate = 60,
                    Status = "Rejected",
                    SubmissionDate = DateTime.Now.AddDays(-10),
                    LecturerId = 1
                }
            );
        }
    }
}
