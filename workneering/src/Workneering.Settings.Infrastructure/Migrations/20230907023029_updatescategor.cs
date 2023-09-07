using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Settings.Infrastructure.Migrations
{
    public partial class updatescategor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "SettingsSchema.Refrences",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "SettingsSchema.Refrences",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "SettingsSchema.Refrences",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "SettingsSchema.Refrences",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "SettingsSchema.Refrences",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "SettingsSchema.Refrences",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
