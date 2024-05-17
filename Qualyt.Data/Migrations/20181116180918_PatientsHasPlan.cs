using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class PatientsHasPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_planpathologies_pathologies_PathologyId",
                table: "planpathologies");

            migrationBuilder.DropForeignKey(
                name: "FK_planpathologies_plans_PlanId",
                table: "planpathologies");

            migrationBuilder.DropForeignKey(
                name: "FK_planproducts_plans_PlanId",
                table: "planproducts");

            migrationBuilder.DropForeignKey(
                name: "FK_planproducts_products_ProductId",
                table: "planproducts");

            migrationBuilder.AddColumn<long>(
                name: "PlanId",
                table: "patients",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_patients_PlanId",
                table: "patients",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_plans_PlanId",
                table: "patients",
                column: "PlanId",
                principalTable: "plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_planpathologies_pathologies_PathologyId",
                table: "planpathologies",
                column: "PathologyId",
                principalTable: "pathologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_planpathologies_plans_PlanId",
                table: "planpathologies",
                column: "PlanId",
                principalTable: "plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_planproducts_plans_PlanId",
                table: "planproducts",
                column: "PlanId",
                principalTable: "plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_planproducts_products_ProductId",
                table: "planproducts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_plans_PlanId",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_planpathologies_pathologies_PathologyId",
                table: "planpathologies");

            migrationBuilder.DropForeignKey(
                name: "FK_planpathologies_plans_PlanId",
                table: "planpathologies");

            migrationBuilder.DropForeignKey(
                name: "FK_planproducts_plans_PlanId",
                table: "planproducts");

            migrationBuilder.DropForeignKey(
                name: "FK_planproducts_products_ProductId",
                table: "planproducts");

            migrationBuilder.DropIndex(
                name: "IX_patients_PlanId",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "patients");

            migrationBuilder.AddForeignKey(
                name: "FK_planpathologies_pathologies_PathologyId",
                table: "planpathologies",
                column: "PathologyId",
                principalTable: "pathologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_planpathologies_plans_PlanId",
                table: "planpathologies",
                column: "PlanId",
                principalTable: "plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_planproducts_plans_PlanId",
                table: "planproducts",
                column: "PlanId",
                principalTable: "plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_planproducts_products_ProductId",
                table: "planproducts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
