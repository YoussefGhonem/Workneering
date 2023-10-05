using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Identity.Infrastructure.Migrations
{
    public partial class AddProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Provider",
                schema: "IdentitySchema",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Provider",
                schema: "IdentitySchema",
                table: "Users");
        }
    }
}
