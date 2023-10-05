using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Message.Infrustructure.Migrations
{
    public partial class Udates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "ChatSchema",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "ChatSchema",
                table: "Rooms");
        }
    }
}
