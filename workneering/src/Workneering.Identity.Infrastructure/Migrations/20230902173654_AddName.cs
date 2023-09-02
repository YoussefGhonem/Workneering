using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Identity.Infrastructure.Migrations
{
    public partial class AddName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "IdentitySchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "IdentitySchema",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "IdentitySchema",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "IdentitySchema",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "IdentitySchema",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "IdentitySchema",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
