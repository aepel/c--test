using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class ControlNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FollowingTheTreatment",
                table: "controltrackings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NextTreatment",
                table: "controltrackings",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "TreatmentInterruptDate",
                table: "controltrackings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TreatmentInterruptReason",
                table: "controltrackings",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "TreatmentStart",
                table: "controltrackings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FollowingTheTreatment",
                table: "controltrackings");

            migrationBuilder.DropColumn(
                name: "NextTreatment",
                table: "controltrackings");

            migrationBuilder.DropColumn(
                name: "TreatmentInterruptDate",
                table: "controltrackings");

            migrationBuilder.DropColumn(
                name: "TreatmentInterruptReason",
                table: "controltrackings");

            migrationBuilder.DropColumn(
                name: "TreatmentStart",
                table: "controltrackings");
        }
    }
}
