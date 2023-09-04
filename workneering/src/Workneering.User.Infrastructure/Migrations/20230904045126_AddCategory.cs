using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class AddCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Freelancers_FreelancerId",
                schema: "User",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Testimonial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                schema: "User",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "User",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "User",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "User",
                newName: "FreelancerCategories",
                newSchema: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_IsDeleted",
                schema: "User",
                table: "FreelancerCategories",
                newName: "IX_FreelancerCategories_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_FreelancerId",
                schema: "User",
                table: "FreelancerCategories",
                newName: "IX_FreelancerCategories_FreelancerId");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                schema: "User",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Licence",
                schema: "User",
                table: "Certifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                schema: "User",
                table: "FreelancerCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreelancerCategories",
                schema: "User",
                table: "FreelancerCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClientCategories",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCategories_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "User",
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyCategories",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyCategories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "User",
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientCategories_ClientId",
                schema: "User",
                table: "ClientCategories",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCategories_IsDeleted",
                schema: "User",
                table: "ClientCategories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCategories_CompanyId",
                schema: "User",
                table: "CompanyCategories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCategories_IsDeleted",
                schema: "User",
                table: "CompanyCategories",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_FreelancerCategories_Freelancers_FreelancerId",
                schema: "User",
                table: "FreelancerCategories",
                column: "FreelancerId",
                principalSchema: "User",
                principalTable: "Freelancers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreelancerCategories_Freelancers_FreelancerId",
                schema: "User",
                table: "FreelancerCategories");

            migrationBuilder.DropTable(
                name: "ClientCategories",
                schema: "User");

            migrationBuilder.DropTable(
                name: "CompanyCategories",
                schema: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreelancerCategories",
                schema: "User",
                table: "FreelancerCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "User",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Licence",
                schema: "User",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "User",
                table: "FreelancerCategories");

            migrationBuilder.RenameTable(
                name: "FreelancerCategories",
                schema: "User",
                newName: "Categories",
                newSchema: "User");

            migrationBuilder.RenameIndex(
                name: "IX_FreelancerCategories_IsDeleted",
                schema: "User",
                table: "Categories",
                newName: "IX_Categories_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_FreelancerCategories_FreelancerId",
                schema: "User",
                table: "Categories",
                newName: "IX_Categories_FreelancerId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "User",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "User",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                schema: "User",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Testimonial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedInProfile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageToClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplayClient = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testimonial_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalSchema: "User",
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_FreelancerId",
                table: "Testimonial",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_IsDeleted",
                table: "Testimonial",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Freelancers_FreelancerId",
                schema: "User",
                table: "Categories",
                column: "FreelancerId",
                principalSchema: "User",
                principalTable: "Freelancers",
                principalColumn: "Id");
        }
    }
}
