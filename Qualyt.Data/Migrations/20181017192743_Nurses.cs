using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class Nurses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NurseId",
                table: "patients",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Nurse",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurse", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_patients_NurseId",
                table: "patients",
                column: "NurseId");

            migrationBuilder.Sql(@" SET SQL_SAFE_UPDATES = 0;
                                    DELETE FROM controltrackings;
                                    DELETE FROM treatments;
                                    DELETE FROM patients;
                                    SET SQL_SAFE_UPDATES = 1;");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_Nurse_NurseId",
                table: "patients",
                column: "NurseId",
                principalTable: "Nurse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_Nurse_NurseId",
                table: "patients");

            migrationBuilder.DropTable(
                name: "Nurse");

            migrationBuilder.DropIndex(
                name: "IX_patients_NurseId",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "NurseId",
                table: "patients");
        }
    }
}
