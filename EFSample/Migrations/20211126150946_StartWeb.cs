using Microsoft.EntityFrameworkCore.Migrations;

namespace EFSample.Migrations
{
    public partial class StartWeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Hospital");

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "Hospital",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "История пациента",
                schema: "Hospital",
                columns: table => new
                {
                    DoctorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctor = table.Column<string>(nullable: false),
                    NameofDoctor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_История пациента", x => x.DoctorID);
                });

            migrationBuilder.CreateTable(
                name: "diseases",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false),
                    DoctorID = table.Column<int>(nullable: false),
                    Diagnosis = table.Column<string>(nullable: false),
                    Complaint = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diseases", x => new { x.PatientId, x.DoctorID });
                    table.UniqueConstraint("AK_diseases_DoctorID_PatientId", x => new { x.DoctorID, x.PatientId });
                    table.ForeignKey(
                        name: "FK_diseases_История пациента_DoctorID",
                        column: x => x.DoctorID,
                        principalSchema: "Hospital",
                        principalTable: "История пациента",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_diseases_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "Hospital",
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diseases");

            migrationBuilder.DropTable(
                name: "История пациента",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Patient",
                schema: "Hospital");
        }
    }
}
