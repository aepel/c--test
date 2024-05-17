using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class LocationInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location_Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_Apartment1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Location_Floor1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Location_Latitude",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Location_Longitude",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location_Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Location_Apartment1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Location_Floor1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Location_Latitude",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Location_Longitude",
                table: "AspNetUsers");
        }
    }
}
