using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class updatesinclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WhatDoIDo",
                schema: "UserSchema",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhoIAm",
                schema: "UserSchema",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhatDoIDo",
                schema: "UserSchema",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "WhoIAm",
                schema: "UserSchema",
                table: "Clients");
        }
    }
}
