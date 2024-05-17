using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class ControlTrackingUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "controltrackings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_controltrackings_CreatedBy",
                table: "controltrackings",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_controltrackings_AspNetUsers_CreatedBy",
                table: "controltrackings",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_controltrackings_AspNetUsers_CreatedBy",
                table: "controltrackings");

            migrationBuilder.DropIndex(
                name: "IX_controltrackings_CreatedBy",
                table: "controltrackings");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "controltrackings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
