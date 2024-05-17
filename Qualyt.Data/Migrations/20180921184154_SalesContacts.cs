using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class SalesContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorId",
                table: "patients",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SalesContactId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "salescontact",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salescontact", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_patients_DoctorId",
                table: "patients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SalesContactId",
                table: "AspNetUsers",
                column: "SalesContactId");

            migrationBuilder.CreateIndex(
                name: "IX_salescontact_Name",
                table: "salescontact",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_salescontact_SalesContactId",
                table: "AspNetUsers",
                column: "SalesContactId",
                principalTable: "salescontact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patients_AspNetUsers_DoctorId",
                table: "patients",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_salescontact_SalesContactId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_AspNetUsers_DoctorId",
                table: "patients");

            migrationBuilder.DropTable(
                name: "salescontact");

            migrationBuilder.DropIndex(
                name: "IX_patients_DoctorId",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SalesContactId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "SalesContactId",
                table: "AspNetUsers");
        }
    }
}
