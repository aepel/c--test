using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class TYCNoAuditables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "termsandconditions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "termsandconditions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "termsandconditions");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "termsandconditions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "termsandconditions",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "termsandconditions",
                nullable: false,
                defaultValue: new DateTimeOffset());

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "termsandconditions",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "termsandconditions",
                nullable: true);
        }
    }
}
