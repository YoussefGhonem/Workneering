using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class UpdatesDataUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreelancerCategories_Freelancers_FreelancerId",
                schema: "User",
                table: "FreelancerCategories");

            migrationBuilder.DropIndex(
                name: "IX_FreelancerCategories_FreelancerId",
                schema: "User",
                table: "FreelancerCategories");

            migrationBuilder.DropIndex(
                name: "IX_FreelancerCategories_IsDeleted",
                schema: "User",
                table: "FreelancerCategories");

            migrationBuilder.DropColumn(
                name: "FreelancerId",
                schema: "User",
                table: "FreelancerCategories");

            migrationBuilder.EnsureSchema(
                name: "UserSchema");

            migrationBuilder.RenameTable(
                name: "Portfolios",
                schema: "User",
                newName: "Portfolios",
                newSchema: "UserSchema");

            migrationBuilder.RenameTable(
                name: "FreelancerSkills",
                schema: "User",
                newName: "FreelancerSkills",
                newSchema: "UserSchema");

            migrationBuilder.RenameTable(
                name: "Freelancers",
                schema: "User",
                newName: "Freelancers",
                newSchema: "UserSchema");

            migrationBuilder.RenameTable(
                name: "FreelancerCategories",
                schema: "User",
                newName: "FreelancerCategories",
                newSchema: "UserSchema");

            migrationBuilder.RenameTable(
                name: "Experiences",
                schema: "User",
                newName: "Experiences",
                newSchema: "UserSchema");

            migrationBuilder.RenameTable(
                name: "EmploymentHistories",
                schema: "User",
                newName: "EmploymentHistories",
                newSchema: "UserSchema");

            migrationBuilder.RenameTable(
                name: "Educations",
                schema: "User",
                newName: "Educations",
                newSchema: "UserSchema");

            migrationBuilder.RenameTable(
                name: "CompanyCategories",
                schema: "User",
                newName: "CompanyCategories",
                newSchema: "UserSchema");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "User",
                newName: "Companies",
                newSchema: "UserSchema");

            migrationBuilder.RenameTable(
                name: "Clients",
                schema: "User",
                newName: "Clients",
                newSchema: "UserSchema");

            migrationBuilder.RenameTable(
                name: "ClientCategories",
                schema: "User",
                newName: "ClientCategories",
                newSchema: "UserSchema");

            migrationBuilder.RenameTable(
                name: "Certifications",
                schema: "User",
                newName: "Certifications",
                newSchema: "UserSchema");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.RenameTable(
                name: "Portfolios",
                schema: "UserSchema",
                newName: "Portfolios",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "FreelancerSkills",
                schema: "UserSchema",
                newName: "FreelancerSkills",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "Freelancers",
                schema: "UserSchema",
                newName: "Freelancers",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "FreelancerCategories",
                schema: "UserSchema",
                newName: "FreelancerCategories",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "Experiences",
                schema: "UserSchema",
                newName: "Experiences",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "EmploymentHistories",
                schema: "UserSchema",
                newName: "EmploymentHistories",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "Educations",
                schema: "UserSchema",
                newName: "Educations",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "CompanyCategories",
                schema: "UserSchema",
                newName: "CompanyCategories",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "UserSchema",
                newName: "Companies",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "Clients",
                schema: "UserSchema",
                newName: "Clients",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "ClientCategories",
                schema: "UserSchema",
                newName: "ClientCategories",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "Certifications",
                schema: "UserSchema",
                newName: "Certifications",
                newSchema: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "FreelancerId",
                schema: "User",
                table: "FreelancerCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerCategories_FreelancerId",
                schema: "User",
                table: "FreelancerCategories",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerCategories_IsDeleted",
                schema: "User",
                table: "FreelancerCategories",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_FreelancerCategories_Freelancers_FreelancerId",
                schema: "User",
                table: "FreelancerCategories",
                column: "FreelancerId",
                principalSchema: "User",
                principalTable: "Freelancers",
                principalColumn: "Id");
        }
    }
}
