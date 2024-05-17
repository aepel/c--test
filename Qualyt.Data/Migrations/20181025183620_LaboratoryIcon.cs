using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class LaboratoryIcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "IconBytes",
                table: "laboratories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconType",
                table: "laboratories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconBytes",
                table: "laboratories");

            migrationBuilder.DropColumn(
                name: "IconType",
                table: "laboratories");
        }
    }
}
