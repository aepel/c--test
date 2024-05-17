using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class PatientUniqueByIdAndPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_patients_Email",
                table: "patients");

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "patients",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "patients",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_patients_IdNumber_PlanId",
                table: "patients",
                columns: new[] { "IdNumber", "PlanId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_patients_IdNumber_PlanId",
                table: "patients");

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "patients",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "patients",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_patients_Email",
                table: "patients",
                column: "Email",
                unique: true);
        }
    }
}
