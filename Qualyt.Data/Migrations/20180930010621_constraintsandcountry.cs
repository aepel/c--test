using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class constraintsandcountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_controltrackings_treatments_TreatmentId",
                table: "controltrackings");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_countries_CountryId",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_healthinsurances_HealthInsuranceId",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_treatments_pathologies_PathologyId",
                table: "treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_treatments_patients_PatientId",
                table: "treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_treatments_products_ProductId",
                table: "treatments");

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "healthinsurances",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_healthinsurances_CountryId",
                table: "healthinsurances",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_controltrackings_treatments_TreatmentId",
                table: "controltrackings",
                column: "TreatmentId",
                principalTable: "treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_healthinsurances_countries_CountryId",
                table: "healthinsurances",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_patients_countries_CountryId",
                table: "patients",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_patients_healthinsurances_HealthInsuranceId",
                table: "patients",
                column: "HealthInsuranceId",
                principalTable: "healthinsurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_treatments_pathologies_PathologyId",
                table: "treatments",
                column: "PathologyId",
                principalTable: "pathologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_treatments_patients_PatientId",
                table: "treatments",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_treatments_products_ProductId",
                table: "treatments",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_controltrackings_treatments_TreatmentId",
                table: "controltrackings");

            migrationBuilder.DropForeignKey(
                name: "FK_healthinsurances_countries_CountryId",
                table: "healthinsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_countries_CountryId",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_healthinsurances_HealthInsuranceId",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_treatments_pathologies_PathologyId",
                table: "treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_treatments_patients_PatientId",
                table: "treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_treatments_products_ProductId",
                table: "treatments");

            migrationBuilder.DropIndex(
                name: "IX_healthinsurances_CountryId",
                table: "healthinsurances");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "healthinsurances");

            migrationBuilder.AddForeignKey(
                name: "FK_controltrackings_treatments_TreatmentId",
                table: "controltrackings",
                column: "TreatmentId",
                principalTable: "treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patients_countries_CountryId",
                table: "patients",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patients_healthinsurances_HealthInsuranceId",
                table: "patients",
                column: "HealthInsuranceId",
                principalTable: "healthinsurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_treatments_pathologies_PathologyId",
                table: "treatments",
                column: "PathologyId",
                principalTable: "pathologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_treatments_patients_PatientId",
                table: "treatments",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_treatments_products_ProductId",
                table: "treatments",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
