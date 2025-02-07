using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContractMonthlyClaimSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedFakeClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "LecturerId", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe" },
                    { 2, "jane.smith@example.com", "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "MonthlyClaims",
                columns: new[] { "MonthlyClaimId", "Description", "HourlyRate", "HoursWorked", "LecturerId", "Status", "SubmissionDate" },
                values: new object[,]
                {
                    { 1, "January Teaching Hours", 50.0, 20.0, 1, "Pending", new DateTime(2025, 1, 31, 22, 16, 56, 21, DateTimeKind.Local).AddTicks(9825) },
                    { 2, "Research Assistance", 45.0, 10.0, 2, "Approved", new DateTime(2025, 1, 24, 22, 16, 56, 23, DateTimeKind.Local).AddTicks(7735) },
                    { 3, "Guest Lecture", 60.0, 5.0, 1, "Rejected", new DateTime(2025, 1, 28, 22, 16, 56, 23, DateTimeKind.Local).AddTicks(7756) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MonthlyClaims",
                keyColumn: "MonthlyClaimId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MonthlyClaims",
                keyColumn: "MonthlyClaimId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MonthlyClaims",
                keyColumn: "MonthlyClaimId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "LecturerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "LecturerId",
                keyValue: 2);
        }
    }
}
