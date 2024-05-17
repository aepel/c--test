using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class MothersSurname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MothersSurname",
                table: "salescontact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MothersSurname",
                table: "nurses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MothersSurname",
                table: "salescontact");

            migrationBuilder.DropColumn(
                name: "MothersSurname",
                table: "nurses");
        }
    }
}
