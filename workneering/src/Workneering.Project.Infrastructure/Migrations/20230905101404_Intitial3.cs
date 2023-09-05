using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Project.Infrastructure.Migrations
{
    public partial class Intitial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DueDate",
                schema: "ProjectsSchema",
                table: "Projects",
                newName: "ProjectDurationDescription");

            migrationBuilder.AddColumn<int>(
                name: "ProposalStatus",
                schema: "ProjectsSchema",
                table: "Proposals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoursPerWeek",
                schema: "ProjectsSchema",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectDuration",
                schema: "ProjectsSchema",
                table: "Projects",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProposalStatus",
                schema: "ProjectsSchema",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "HoursPerWeek",
                schema: "ProjectsSchema",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectDuration",
                schema: "ProjectsSchema",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectDurationDescription",
                schema: "ProjectsSchema",
                table: "Projects",
                newName: "DueDate");
        }
    }
}
