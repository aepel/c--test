using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class CambiosEnElModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "products",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LaboratoryId1",
                table: "products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_LaboratoryId1",
                table: "products",
                column: "LaboratoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_products_laboratories_LaboratoryId1",
                table: "products",
                column: "LaboratoryId1",
                principalTable: "laboratories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_laboratories_LaboratoryId1",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_LaboratoryId1",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "products");

            migrationBuilder.DropColumn(
                name: "LaboratoryId1",
                table: "products");
        }
    }
}
