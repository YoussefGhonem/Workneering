using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class WengazeProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "WengazPercentage",
                schema: "UserSchema",
                table: "Freelancers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WengazPoint",
                schema: "UserSchema",
                table: "Freelancers",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WengazPercentage",
                schema: "UserSchema",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "WengazPoint",
                schema: "UserSchema",
                table: "Freelancers");
        }
    }
}
