using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class addCounrtyflag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCountainCountry",
                schema: "UserSchema",
                table: "Freelancers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCountainCountry",
                schema: "UserSchema",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCountainCountry",
                schema: "UserSchema",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCountainCountry",
                schema: "UserSchema",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "IsCountainCountry",
                schema: "UserSchema",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsCountainCountry",
                schema: "UserSchema",
                table: "Clients");
        }
    }
}
