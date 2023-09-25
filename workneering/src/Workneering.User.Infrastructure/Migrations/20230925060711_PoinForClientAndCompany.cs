using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class PoinForClientAndCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DeductedPoint",
                schema: "UserSchema",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthPoint",
                schema: "UserSchema",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PackagePoint",
                schema: "UserSchema",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProfilePoint",
                schema: "UserSchema",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DeductedPoint",
                schema: "UserSchema",
                table: "Clients",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthPoint",
                schema: "UserSchema",
                table: "Clients",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PackagePoint",
                schema: "UserSchema",
                table: "Clients",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProfilePoint",
                schema: "UserSchema",
                table: "Clients",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeductedPoint",
                schema: "UserSchema",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MonthPoint",
                schema: "UserSchema",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "PackagePoint",
                schema: "UserSchema",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ProfilePoint",
                schema: "UserSchema",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DeductedPoint",
                schema: "UserSchema",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "MonthPoint",
                schema: "UserSchema",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PackagePoint",
                schema: "UserSchema",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ProfilePoint",
                schema: "UserSchema",
                table: "Clients");
        }
    }
}
