using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class DoctorSalesContactRelationFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_salescontact_SalesContactId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_doctorspecialties_SpecialtyId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "salescontact",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "salescontact",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "salescontact",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "salescontact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "salescontact",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "salescontact",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_salescontact_SalesContactId",
                table: "AspNetUsers",
                column: "SalesContactId",
                principalTable: "salescontact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_doctorspecialties_SpecialtyId",
                table: "AspNetUsers",
                column: "SpecialtyId",
                principalTable: "doctorspecialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_salescontact_SalesContactId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_doctorspecialties_SpecialtyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "salescontact");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "salescontact");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "salescontact");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "salescontact");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "salescontact");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "salescontact");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_salescontact_SalesContactId",
                table: "AspNetUsers",
                column: "SalesContactId",
                principalTable: "salescontact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_doctorspecialties_SpecialtyId",
                table: "AspNetUsers",
                column: "SpecialtyId",
                principalTable: "doctorspecialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
