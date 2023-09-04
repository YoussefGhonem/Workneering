using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Project.Infrastructure.Migrations
{
    public partial class Intitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProposalDuratio",
                schema: "ProjectsSchema",
                table: "Proposals",
                newName: "ProposalDuration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProposalDuration",
                schema: "ProjectsSchema",
                table: "Proposals",
                newName: "ProposalDuratio");
        }
    }
}
