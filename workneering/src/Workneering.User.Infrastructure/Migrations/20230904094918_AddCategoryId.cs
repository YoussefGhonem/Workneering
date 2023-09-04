using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class AddCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                schema: "User",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "User",
                table: "Clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SpecialtyId",
                schema: "User",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                schema: "User",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
