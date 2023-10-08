using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Message.Infrustructure.Migrations
{
    public partial class addNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RecipientId",
                schema: "ChatSchema",
                table: "MessegeNotifications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SenderId",
                schema: "ChatSchema",
                table: "MessegeNotifications",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientId",
                schema: "ChatSchema",
                table: "MessegeNotifications");

            migrationBuilder.DropColumn(
                name: "SenderId",
                schema: "ChatSchema",
                table: "MessegeNotifications");
        }
    }
}
