using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class UpdateOnAvailabilty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability_ContractToHire",
                schema: "User",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "Availability_DateForNewWork",
                schema: "User",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "Availability_HoursPerWeek",
                schema: "User",
                table: "Freelancers");

            migrationBuilder.RenameColumn(
                name: "Visibility",
                schema: "User",
                table: "Freelancers",
                newName: "Availability");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Availability",
                schema: "User",
                table: "Freelancers",
                newName: "Visibility");

            migrationBuilder.AddColumn<bool>(
                name: "Availability_ContractToHire",
                schema: "User",
                table: "Freelancers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Availability_DateForNewWork",
                schema: "User",
                table: "Freelancers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Availability_HoursPerWeek",
                schema: "User",
                table: "Freelancers",
                type: "int",
                nullable: true);
        }
    }
}
