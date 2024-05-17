using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class ControlType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "NextControl",
                table: "controltrackings",
                nullable: true,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<bool>(
                name: "FollowingTheTreatment",
                table: "controltrackings",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "controltrackings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "controltrackings");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "NextControl",
                table: "controltrackings",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "FollowingTheTreatment",
                table: "controltrackings",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
