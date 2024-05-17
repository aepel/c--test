using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class ClinicalHistories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clinicalhistories",
                columns: table => new
                {
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    LivesWith = table.Column<int>(nullable: false),
                    SchoolLevel = table.Column<int>(nullable: false),
                    Profession = table.Column<string>(nullable: true),
                    BloodType = table.Column<int>(nullable: false),
                    RhFactor = table.Column<int>(nullable: false),
                    InMedicalTreatment = table.Column<bool>(nullable: false),
                    MedicalTreatmentDetail = table.Column<string>(nullable: true),
                    Allergic = table.Column<bool>(nullable: false),
                    AllergyDetail = table.Column<string>(nullable: true),
                    Hemorrhage = table.Column<bool>(nullable: false),
                    HemorrhageDetail = table.Column<string>(nullable: true),
                    Seizures = table.Column<bool>(nullable: false),
                    SeizuresDetail = table.Column<string>(nullable: true),
                    Smoker = table.Column<bool>(nullable: false),
                    SmokerDetail = table.Column<string>(nullable: true),
                    PracticeSports = table.Column<bool>(nullable: false),
                    SportsDetail = table.Column<string>(nullable: true),
                    RheumatoidArthritis = table.Column<bool>(nullable: false),
                    KidneyProblems = table.Column<bool>(nullable: false),
                    Asthma = table.Column<bool>(nullable: false),
                    ArterialHypertension = table.Column<bool>(nullable: false),
                    MellitusDiabetes1 = table.Column<bool>(nullable: false),
                    MellitusDiabetes2 = table.Column<bool>(nullable: false),
                    HIV = table.Column<bool>(nullable: false),
                    Anemia = table.Column<bool>(nullable: false),
                    Hepatitis = table.Column<bool>(nullable: false),
                    HeartProblems = table.Column<bool>(nullable: false),
                    Tuberculosis = table.Column<bool>(nullable: false),
                    Cancer = table.Column<bool>(nullable: false),
                    Headache = table.Column<bool>(nullable: false),
                    Epilepsy = table.Column<bool>(nullable: false),
                    COPD = table.Column<bool>(nullable: false),
                    Surgeries = table.Column<bool>(nullable: false),
                    Hypothyroidism = table.Column<bool>(nullable: false),
                    OtherDiseases = table.Column<string>(nullable: true),
                    Pacemaker = table.Column<bool>(nullable: false),
                    Prosthesis = table.Column<bool>(nullable: false),
                    ProsthesisDetail = table.Column<string>(nullable: true),
                    HasBeenPregnant = table.Column<bool>(nullable: false),
                    Pregnancies = table.Column<int>(nullable: false),
                    BirthsType = table.Column<int>(nullable: false),
                    ChildrenBorn = table.Column<int>(nullable: false),
                    FamiliarDiabetes = table.Column<bool>(nullable: false),
                    FamiliarDiabetesDetail = table.Column<string>(nullable: true),
                    FamiliarArterialHypertension = table.Column<bool>(nullable: false),
                    FamiliarArterialHypertensionDetail = table.Column<string>(nullable: true),
                    FamiliarHeartProblems = table.Column<bool>(nullable: false),
                    FamiliarHeartProblemsDetail = table.Column<string>(nullable: true),
                    FamiliarCancer = table.Column<bool>(nullable: false),
                    FamiliarCancerDetail = table.Column<string>(nullable: true),
                    OtherFamilyDiseases = table.Column<string>(nullable: true),
                    PatientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinicalhistories", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_clinicalhistories_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clinicalhistories");
        }
    }
}
