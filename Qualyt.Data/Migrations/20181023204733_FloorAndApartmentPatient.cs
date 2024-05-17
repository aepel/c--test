using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class FloorAndApartmentPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location_Apartment",
                table: "patients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Location_Floor",
                table: "patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_Apartment",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Location_Floor",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location_Apartment",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "Location_Floor",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "Location_Apartment",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Location_Floor",
                table: "AspNetUsers");
        }
    }
}
