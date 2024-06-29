using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class ModelToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorId",
                table: "PrescribedMedicines",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "PrescribedMedicines",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedMedicines_DoctorId",
                table: "PrescribedMedicines",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedMedicines_PatientId",
                table: "PrescribedMedicines",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribedMedicines_AspNetUsers_DoctorId",
                table: "PrescribedMedicines",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribedMedicines_AspNetUsers_PatientId",
                table: "PrescribedMedicines",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescribedMedicines_AspNetUsers_DoctorId",
                table: "PrescribedMedicines");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescribedMedicines_AspNetUsers_PatientId",
                table: "PrescribedMedicines");

            migrationBuilder.DropIndex(
                name: "IX_PrescribedMedicines_DoctorId",
                table: "PrescribedMedicines");

            migrationBuilder.DropIndex(
                name: "IX_PrescribedMedicines_PatientId",
                table: "PrescribedMedicines");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "PrescribedMedicines");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PrescribedMedicines");
        }
    }
}
