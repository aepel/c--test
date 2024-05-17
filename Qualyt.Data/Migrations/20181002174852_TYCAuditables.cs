using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class TYCAuditables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_laboratories_LaboratoryId1",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_LaboratoryId1",
                table: "products");

            migrationBuilder.DropColumn(
                name: "LaboratoryId1",
                table: "products");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "termsandconditions",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "termsandconditions");

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

            migrationBuilder.AddColumn<long>(
                name: "LaboratoryId1",
                table: "products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_LaboratoryId1",
                table: "products",
                column: "LaboratoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_products_laboratories_LaboratoryId1",
                table: "products",
                column: "LaboratoryId1",
                principalTable: "laboratories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
