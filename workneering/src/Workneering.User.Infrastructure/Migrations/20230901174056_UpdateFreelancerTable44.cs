using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class UpdateFreelancerTable44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioSkill_Portfolios_PortfolioId",
                table: "PortfolioSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PortfolioSkill",
                table: "PortfolioSkill");

            migrationBuilder.EnsureSchema(
                name: "User.Portfolio");

            migrationBuilder.RenameTable(
                name: "PortfolioSkill",
                newName: "PortfolioSkills",
                newSchema: "User.Portfolio");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioSkill_PortfolioId",
                schema: "User.Portfolio",
                table: "PortfolioSkills",
                newName: "IX_PortfolioSkills_PortfolioId");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioSkill_IsDeleted",
                schema: "User.Portfolio",
                table: "PortfolioSkills",
                newName: "IX_PortfolioSkills_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortfolioSkills",
                schema: "User.Portfolio",
                table: "PortfolioSkills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioSkills_Portfolios_PortfolioId",
                schema: "User.Portfolio",
                table: "PortfolioSkills",
                column: "PortfolioId",
                principalSchema: "User",
                principalTable: "Portfolios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioSkills_Portfolios_PortfolioId",
                schema: "User.Portfolio",
                table: "PortfolioSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PortfolioSkills",
                schema: "User.Portfolio",
                table: "PortfolioSkills");

            migrationBuilder.RenameTable(
                name: "PortfolioSkills",
                schema: "User.Portfolio",
                newName: "PortfolioSkill");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioSkills_PortfolioId",
                table: "PortfolioSkill",
                newName: "IX_PortfolioSkill_PortfolioId");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioSkills_IsDeleted",
                table: "PortfolioSkill",
                newName: "IX_PortfolioSkill_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortfolioSkill",
                table: "PortfolioSkill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioSkill_Portfolios_PortfolioId",
                table: "PortfolioSkill",
                column: "PortfolioId",
                principalSchema: "User",
                principalTable: "Portfolios",
                principalColumn: "Id");
        }
    }
}
