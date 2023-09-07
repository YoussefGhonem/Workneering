using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Project.Infrastructure.Migrations
{
    public partial class Intitial66 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectBudgetPrice",
                schema: "ProjectsSchema",
                table: "Projects",
                newName: "ProjectHourlyToPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "ProjectFixedBudgetPrice",
                schema: "ProjectsSchema",
                table: "Projects",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProjectHourlyFromPrice",
                schema: "ProjectsSchema",
                table: "Projects",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectFixedBudgetPrice",
                schema: "ProjectsSchema",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectHourlyFromPrice",
                schema: "ProjectsSchema",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectHourlyToPrice",
                schema: "ProjectsSchema",
                table: "Projects",
                newName: "ProjectBudgetPrice");
        }
    }
}
