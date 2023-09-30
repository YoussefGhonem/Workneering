using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Identity.Infrastructure.Migrations
{
    public partial class UpdateMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ChatSchema");

            migrationBuilder.RenameTable(
                name: "Messages",
                schema: "IdentitySchema",
                newName: "Messages",
                newSchema: "ChatSchema");

            migrationBuilder.AddColumn<string>(
                name: "ImageKey",
                schema: "IdentitySchema",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageKey",
                schema: "IdentitySchema",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Messages",
                schema: "ChatSchema",
                newName: "Messages",
                newSchema: "IdentitySchema");
        }
    }
}
