using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Project.Infrastructure.Migrations
{
    public partial class updatesdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRecommend",
                schema: "ProjectsSchema",
                table: "Projects",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecommend",
                schema: "ProjectsSchema",
                table: "Projects");
        }
    }
}
