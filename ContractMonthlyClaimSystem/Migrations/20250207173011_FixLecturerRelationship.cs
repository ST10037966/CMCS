using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractMonthlyClaimSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixLecturerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Claims_ClaimId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.RenameColumn(
                name: "ClaimId",
                table: "Documents",
                newName: "MonthlyClaimId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_ClaimId",
                table: "Documents",
                newName: "IX_Documents_MonthlyClaimId");

            migrationBuilder.CreateTable(
                name: "MonthlyClaims",
                columns: table => new
                {
                    MonthlyClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoursWorked = table.Column<double>(type: "float", nullable: false),
                    HourlyRate = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyClaims", x => x.MonthlyClaimId);
                    table.ForeignKey(
                        name: "FK_MonthlyClaims_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "LecturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyClaims_LecturerId",
                table: "MonthlyClaims",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_MonthlyClaims_MonthlyClaimId",
                table: "Documents",
                column: "MonthlyClaimId",
                principalTable: "MonthlyClaims",
                principalColumn: "MonthlyClaimId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_MonthlyClaims_MonthlyClaimId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "MonthlyClaims");

            migrationBuilder.RenameColumn(
                name: "MonthlyClaimId",
                table: "Documents",
                newName: "ClaimId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_MonthlyClaimId",
                table: "Documents",
                newName: "IX_Documents_ClaimId");

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    HourlyRate = table.Column<double>(type: "float", nullable: false),
                    HoursWorked = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK_Claims_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "LecturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_LecturerId",
                table: "Claims",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Claims_ClaimId",
                table: "Documents",
                column: "ClaimId",
                principalTable: "Claims",
                principalColumn: "ClaimId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
