using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class PathologyHasLaboratory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LaboratoryId",
                table: "pathologies",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_pathologies_LaboratoryId",
                table: "pathologies",
                column: "LaboratoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_pathologies_laboratories_LaboratoryId",
                table: "pathologies",
                column: "LaboratoryId",
                principalTable: "laboratories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pathologies_laboratories_LaboratoryId",
                table: "pathologies");

            migrationBuilder.DropIndex(
                name: "IX_pathologies_LaboratoryId",
                table: "pathologies");

            migrationBuilder.DropColumn(
                name: "LaboratoryId",
                table: "pathologies");
        }
    }
}
