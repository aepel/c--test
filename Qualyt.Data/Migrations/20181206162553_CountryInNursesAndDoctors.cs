using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class CountryInNursesAndDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "nurses",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.Sql(@" SET SQL_SAFE_UPDATES = 0;
                                    update nurses set CountryId=2;
                                    update aspnetusers set CountryId=2;
                                    SET SQL_SAFE_UPDATES = 1;");

            migrationBuilder.CreateIndex(
                name: "IX_nurses_CountryId",
                table: "nurses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_countries_CountryId",
                table: "AspNetUsers",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_nurses_countries_CountryId",
                table: "nurses",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_countries_CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_nurses_countries_CountryId",
                table: "nurses");

            migrationBuilder.DropIndex(
                name: "IX_nurses_CountryId",
                table: "nurses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "nurses");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "AspNetUsers");
        }
    }
}
