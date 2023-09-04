using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class FixesInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioSkills_Portfolios_PortfolioId",
                schema: "User.Portfolio",
                table: "PortfolioSkills");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioSkills_IsDeleted",
                schema: "User.Portfolio",
                table: "PortfolioSkills");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioSkills_PortfolioId",
                schema: "User.Portfolio",
                table: "PortfolioSkills");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                schema: "User.Portfolio",
                table: "PortfolioSkills");

            migrationBuilder.DropColumn(
                name: "CompletionDate",
                schema: "User",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "FileCaption",
                schema: "User",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "ProjectSolutionDescription",
                schema: "User",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "ProjectTaskDescription",
                schema: "User",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "ProjectURL",
                schema: "User",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "RelatedSpecializedProfile",
                schema: "User",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Role",
                schema: "User",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Template",
                schema: "User",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "YouTubeLink",
                schema: "User",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "User",
                table: "EmploymentHistories");

            migrationBuilder.DropColumn(
                name: "IsCurrentlyWork",
                schema: "User",
                table: "EmploymentHistories");

            migrationBuilder.DropColumn(
                name: "Location_City",
                schema: "User",
                table: "EmploymentHistories");

            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "User",
                table: "EmploymentHistories");

            migrationBuilder.RenameColumn(
                name: "Location_CountryName",
                schema: "User",
                table: "EmploymentHistories",
                newName: "Role");

            migrationBuilder.AddColumn<int>(
                name: "EndYear",
                schema: "User",
                table: "Portfolios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartYear",
                schema: "User",
                table: "Portfolios",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "Language",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "Language",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EndYear",
                schema: "User",
                table: "EmploymentHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartYear",
                schema: "User",
                table: "EmploymentHistories",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndYear",
                schema: "User",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "StartYear",
                schema: "User",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "EndYear",
                schema: "User",
                table: "EmploymentHistories");

            migrationBuilder.DropColumn(
                name: "StartYear",
                schema: "User",
                table: "EmploymentHistories");

            migrationBuilder.RenameColumn(
                name: "Role",
                schema: "User",
                table: "EmploymentHistories",
                newName: "Location_CountryName");

            migrationBuilder.AddColumn<Guid>(
                name: "PortfolioId",
                schema: "User.Portfolio",
                table: "PortfolioSkills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CompletionDate",
                schema: "User",
                table: "Portfolios",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileCaption",
                schema: "User",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectSolutionDescription",
                schema: "User",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectTaskDescription",
                schema: "User",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectURL",
                schema: "User",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RelatedSpecializedProfile",
                schema: "User",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                schema: "User",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Template",
                schema: "User",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "YouTubeLink",
                schema: "User",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "Language",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Language",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndDate",
                schema: "User",
                table: "EmploymentHistories",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentlyWork",
                schema: "User",
                table: "EmploymentHistories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Location_City",
                schema: "User",
                table: "EmploymentHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartDate",
                schema: "User",
                table: "EmploymentHistories",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioSkills_IsDeleted",
                schema: "User.Portfolio",
                table: "PortfolioSkills",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioSkills_PortfolioId",
                schema: "User.Portfolio",
                table: "PortfolioSkills",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioSkills_Portfolios_PortfolioId",
                schema: "User.Portfolio",
                table: "PortfolioSkills",
                column: "PortfolioId",
                principalSchema: "User",
                principalTable: "Portfolios",
                principalColumn: "Id");
        }
    }
}
