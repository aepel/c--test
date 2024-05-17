using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class AttachedFilesHasVersionOfTerms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TermsAndConditionsId",
                table: "AttachedFile",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttachedFile_TermsAndConditionsId",
                table: "AttachedFile",
                column: "TermsAndConditionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachedFile_termsandconditions_TermsAndConditionsId",
                table: "AttachedFile",
                column: "TermsAndConditionsId",
                principalTable: "termsandconditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachedFile_termsandconditions_TermsAndConditionsId",
                table: "AttachedFile");

            migrationBuilder.DropIndex(
                name: "IX_AttachedFile_TermsAndConditionsId",
                table: "AttachedFile");

            migrationBuilder.DropColumn(
                name: "TermsAndConditionsId",
                table: "AttachedFile");
        }
    }
}
