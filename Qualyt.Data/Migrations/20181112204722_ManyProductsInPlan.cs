using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class ManyProductsInPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plans_products_ProductId",
                table: "plans");

            migrationBuilder.DropIndex(
                name: "IX_plans_ProductId",
                table: "plans");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "plans");

            migrationBuilder.CreateTable(
                name: "planproducts",
                columns: table => new
                {
                    PlanId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planproducts", x => new { x.ProductId, x.PlanId });
                    table.ForeignKey(
                        name: "FK_planproducts_plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_planproducts_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_planproducts_PlanId",
                table: "planproducts",
                column: "PlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "planproducts");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "plans",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_plans_ProductId",
                table: "plans",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_plans_products_ProductId",
                table: "plans",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
