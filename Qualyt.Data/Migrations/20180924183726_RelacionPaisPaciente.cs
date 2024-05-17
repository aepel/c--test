using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class RelacionPaisPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "patients",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_patients_CountryId",
                table: "patients",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_countries_CountryId",
                table: "patients",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_countries_CountryId",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_CountryId",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "patients");
        }
    }
}
