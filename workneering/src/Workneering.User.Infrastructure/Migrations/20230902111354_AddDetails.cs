using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class AddDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                schema: "User",
                table: "Freelancers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "User",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumOfReviews",
                schema: "User",
                table: "Freelancers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Reviews",
                schema: "User",
                table: "Freelancers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleOverview",
                schema: "User",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearsOfExperience",
                schema: "User",
                table: "Freelancers",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "User",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "User",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "NumOfReviews",
                schema: "User",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "Reviews",
                schema: "User",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "TitleOverview",
                schema: "User",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                schema: "User",
                table: "Freelancers");
        }
    }
}
