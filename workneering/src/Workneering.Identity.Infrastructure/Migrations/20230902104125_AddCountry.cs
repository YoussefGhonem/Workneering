using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Identity.Infrastructure.Migrations
{
    public partial class AddCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryName",
                schema: "IdentitySchema",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "IdentitySchema",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "IdentitySchema",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                schema: "IdentitySchema",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
