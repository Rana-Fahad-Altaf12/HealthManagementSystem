using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentService.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "Description", "IsDeleted", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), "Dental check-up", false, 1 },
                    { 2, new DateTime(2024, 12, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "Annual physical exam", false, 1 },
                    { 3, new DateTime(2025, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), "Regular checkup", false, 2 },
                    { 4, new DateTime(2025, 1, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), "Physical exam", false, 2 },
                    { 5, new DateTime(2025, 2, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Blood Test", false, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
