using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class PointFieldFreelancer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DeductedPoint",
                schema: "UserSchema",
                table: "Freelancers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthPoint",
                schema: "UserSchema",
                table: "Freelancers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PackagePoint",
                schema: "UserSchema",
                table: "Freelancers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProfilePoint",
                schema: "UserSchema",
                table: "Freelancers",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeductedPoint",
                schema: "UserSchema",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "MonthPoint",
                schema: "UserSchema",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "PackagePoint",
                schema: "UserSchema",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "ProfilePoint",
                schema: "UserSchema",
                table: "Freelancers");
        }
    }
}
