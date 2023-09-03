using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class fixesNulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassedDate",
                schema: "User",
                table: "Certifications",
                newName: "GivenBy");

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "Language",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location_CountryName",
                schema: "User",
                table: "EmploymentHistories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location_City",
                schema: "User",
                table: "EmploymentHistories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AwardAreaOfStudy",
                schema: "User",
                table: "Certifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EndYear",
                schema: "User",
                table: "Certifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartYear",
                schema: "User",
                table: "Certifications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwardAreaOfStudy",
                schema: "User",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "EndYear",
                schema: "User",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "StartYear",
                schema: "User",
                table: "Certifications");

            migrationBuilder.RenameColumn(
                name: "GivenBy",
                schema: "User",
                table: "Certifications",
                newName: "PassedDate");

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "Language",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Location_CountryName",
                schema: "User",
                table: "EmploymentHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location_City",
                schema: "User",
                table: "EmploymentHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
