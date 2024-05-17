using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class ProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "DeviceType",
                table: "products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "products",
                nullable: true);
        }
    }
}
