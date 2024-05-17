using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class ManyFilesPerPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attachedfiles_patients_PatientId",
                table: "attachedfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_attachedfiles",
                table: "attachedfiles");

            migrationBuilder.RenameTable(
                name: "attachedfiles",
                newName: "AttachedFile");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "AttachedFile",
                nullable: false,
                defaultValue: 0L)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "AttachedFile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AttachedFile",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "AttachedFile",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "AttachedFile",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttachedFile",
                table: "AttachedFile",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AttachedFile_PatientId",
                table: "AttachedFile",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachedFile_patients_PatientId",
                table: "AttachedFile",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachedFile_patients_PatientId",
                table: "AttachedFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttachedFile",
                table: "AttachedFile");

            migrationBuilder.DropIndex(
                name: "IX_AttachedFile_PatientId",
                table: "AttachedFile");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AttachedFile");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "AttachedFile");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AttachedFile");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "AttachedFile");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AttachedFile");

            migrationBuilder.RenameTable(
                name: "AttachedFile",
                newName: "attachedfiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_attachedfiles",
                table: "attachedfiles",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_attachedfiles_patients_PatientId",
                table: "attachedfiles",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
