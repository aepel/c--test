using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class Plans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plans",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    LaboratoryId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    CountryId = table.Column<long>(nullable: false),
                    Start = table.Column<DateTimeOffset>(nullable: false),
                    End = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_plans_countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_plans_laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_plans_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "planpathologies",
                columns: table => new
                {
                    PlanId = table.Column<long>(nullable: false),
                    PathologyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planpathologies", x => new { x.PathologyId, x.PlanId });
                    table.ForeignKey(
                        name: "FK_planpathologies_pathologies_PathologyId",
                        column: x => x.PathologyId,
                        principalTable: "pathologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_planpathologies_plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_planpathologies_PlanId",
                table: "planpathologies",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_plans_CountryId",
                table: "plans",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_plans_LaboratoryId",
                table: "plans",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_plans_Name",
                table: "plans",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_plans_ProductId",
                table: "plans",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "planpathologies");

            migrationBuilder.DropTable(
                name: "plans");
        }
    }
}
