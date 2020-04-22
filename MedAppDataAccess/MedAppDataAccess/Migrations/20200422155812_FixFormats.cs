using Microsoft.EntityFrameworkCore.Migrations;

namespace MedAppDataAccess.Migrations
{
    public partial class FixFormats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Patients",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Patients",
                newName: "PatientId");
        }
    }
}
