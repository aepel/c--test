using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class NursesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_Nurse_NurseId",
                table: "patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nurse",
                table: "Nurse");

            migrationBuilder.RenameTable(
                name: "Nurse",
                newName: "nurses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_nurses",
                table: "nurses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_nurses_NurseId",
                table: "patients",
                column: "NurseId",
                principalTable: "nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_nurses_NurseId",
                table: "patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_nurses",
                table: "nurses");

            migrationBuilder.RenameTable(
                name: "nurses",
                newName: "Nurse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nurse",
                table: "Nurse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_Nurse_NurseId",
                table: "patients",
                column: "NurseId",
                principalTable: "Nurse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
