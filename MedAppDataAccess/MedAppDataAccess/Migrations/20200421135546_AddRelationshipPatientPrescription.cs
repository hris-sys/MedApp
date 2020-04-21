using Microsoft.EntityFrameworkCore.Migrations;

namespace MedAppDataAccess.Migrations
{
    public partial class AddRelationshipPatientPrescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Specialties",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "PatientsPrescriptions",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false),
                    PrescriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsPrescriptions", x => new { x.PatientId, x.PrescriptionId });
                    table.ForeignKey(
                        name: "FK_PatientsPrescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientsPrescriptions_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientsPrescriptions_PrescriptionId",
                table: "PatientsPrescriptions",
                column: "PrescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientsPrescriptions");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Specialties",
                newName: "name");
        }
    }
}
