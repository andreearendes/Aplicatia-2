using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplicatia_2.Migrations
{
    public partial class PatientTreatment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorID);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    TreatmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.TreatmentID);
                });

            migrationBuilder.CreateTable(
                name: "PatientTreatment",
                columns: table => new
                {
                    PatientTreatmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    TreatmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTreatment", x => x.PatientTreatmentID);
                    table.ForeignKey(
                        name: "FK_PatientTreatment_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTreatment_Treatment_TreatmentID",
                        column: x => x.TreatmentID,
                        principalTable: "Treatment",
                        principalColumn: "TreatmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DoctorID",
                table: "Patient",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTreatment_PatientID",
                table: "PatientTreatment",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTreatment_TreatmentID",
                table: "PatientTreatment",
                column: "TreatmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctor_DoctorID",
                table: "Patient",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctor_DoctorID",
                table: "Patient");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "PatientTreatment");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropIndex(
                name: "IX_Patient_DoctorID",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Patient");
        }
    }
}
