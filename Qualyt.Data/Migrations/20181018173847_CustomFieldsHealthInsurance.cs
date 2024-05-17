using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class CustomFieldsHealthInsurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerializedHealthInsuranceFields",
                table: "patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerializedFields",
                table: "healthinsurances",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerializedHealthInsuranceFields",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "SerializedFields",
                table: "healthinsurances");
        }
    }
}
