using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class AddImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageDetails_Extension",
                schema: "UserSchema",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageDetails_FileName",
                schema: "UserSchema",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ImageDetails_FileSize",
                schema: "UserSchema",
                table: "Freelancers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageDetails_Key",
                schema: "UserSchema",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageDetails_Extension",
                schema: "UserSchema",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageDetails_FileName",
                schema: "UserSchema",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ImageDetails_FileSize",
                schema: "UserSchema",
                table: "Companies",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageDetails_Key",
                schema: "UserSchema",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageDetails_Extension",
                schema: "UserSchema",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageDetails_FileName",
                schema: "UserSchema",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ImageDetails_FileSize",
                schema: "UserSchema",
                table: "Clients",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageDetails_Key",
                schema: "UserSchema",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDetails_Extension",
                schema: "UserSchema",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "ImageDetails_FileName",
                schema: "UserSchema",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "ImageDetails_FileSize",
                schema: "UserSchema",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "ImageDetails_Key",
                schema: "UserSchema",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "ImageDetails_Extension",
                schema: "UserSchema",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ImageDetails_FileName",
                schema: "UserSchema",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ImageDetails_FileSize",
                schema: "UserSchema",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ImageDetails_Key",
                schema: "UserSchema",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ImageDetails_Extension",
                schema: "UserSchema",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ImageDetails_FileName",
                schema: "UserSchema",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ImageDetails_FileSize",
                schema: "UserSchema",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ImageDetails_Key",
                schema: "UserSchema",
                table: "Clients");
        }
    }
}
