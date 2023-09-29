using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Identity.Infrastructure.Migrations
{
    public partial class UpdateImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image_FileName",
                schema: "IdentitySchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Image_FileSize",
                schema: "IdentitySchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Image_Id",
                schema: "IdentitySchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Image_IsExternal",
                schema: "IdentitySchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Image_Url",
                schema: "IdentitySchema",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image_FileName",
                schema: "IdentitySchema",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Image_FileSize",
                schema: "IdentitySchema",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image_Id",
                schema: "IdentitySchema",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Image_IsExternal",
                schema: "IdentitySchema",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image_Url",
                schema: "IdentitySchema",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
