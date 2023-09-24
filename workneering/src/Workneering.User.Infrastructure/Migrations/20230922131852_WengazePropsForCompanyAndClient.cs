using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class WengazePropsForCompanyAndClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "WengazPercentage",
                schema: "UserSchema",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WengazPoint",
                schema: "UserSchema",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WengazPercentage",
                schema: "UserSchema",
                table: "Clients",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WengazPoint",
                schema: "UserSchema",
                table: "Clients",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WengazPercentage",
                schema: "UserSchema",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "WengazPoint",
                schema: "UserSchema",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "WengazPercentage",
                schema: "UserSchema",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "WengazPoint",
                schema: "UserSchema",
                table: "Clients");
        }
    }
}
