using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class LaboratoriesColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_attentionplaces_AttentionPlaceId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "laboratories",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_attentionplaces_AttentionPlaceId",
                table: "AspNetUsers",
                column: "AttentionPlaceId",
                principalTable: "attentionplaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_attentionplaces_AttentionPlaceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "laboratories");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_attentionplaces_AttentionPlaceId",
                table: "AspNetUsers",
                column: "AttentionPlaceId",
                principalTable: "attentionplaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
