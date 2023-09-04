using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Project.Infrastructure.Migrations
{
    public partial class Intitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ProjectsSchema");

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "ProjectsSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOpenDueDate = table.Column<bool>(type: "bit", nullable: true),
                    DueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectBudgetPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectStatus = table.Column<int>(type: "int", nullable: true),
                    ExperienceLevel = table.Column<int>(type: "int", nullable: true),
                    ProjectBudget = table.Column<int>(type: "int", nullable: true),
                    ProjectType = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectActivities",
                schema: "ProjectsSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_ProjectActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectActivities_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "ProjectsSchema",
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkills",
                schema: "ProjectsSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_ProjectSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "ProjectsSchema",
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                schema: "ProjectsSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProposalDuratio = table.Column<int>(type: "int", nullable: true),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalBid = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "ProjectsSchema",
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                schema: "ProjectsSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Wishlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlist_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "ProjectsSchema",
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectActivities_IsDeleted",
                schema: "ProjectsSchema",
                table: "ProjectActivities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectActivities_ProjectId",
                schema: "ProjectsSchema",
                table: "ProjectActivities",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IsDeleted",
                schema: "ProjectsSchema",
                table: "Projects",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkills_IsDeleted",
                schema: "ProjectsSchema",
                table: "ProjectSkills",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkills_ProjectId",
                schema: "ProjectsSchema",
                table: "ProjectSkills",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_IsDeleted",
                schema: "ProjectsSchema",
                table: "Proposals",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_ProjectId",
                schema: "ProjectsSchema",
                table: "Proposals",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_IsDeleted",
                schema: "ProjectsSchema",
                table: "Wishlist",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_ProjectId",
                schema: "ProjectsSchema",
                table: "Wishlist",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectActivities",
                schema: "ProjectsSchema");

            migrationBuilder.DropTable(
                name: "ProjectSkills",
                schema: "ProjectsSchema");

            migrationBuilder.DropTable(
                name: "Proposals",
                schema: "ProjectsSchema");

            migrationBuilder.DropTable(
                name: "Wishlist",
                schema: "ProjectsSchema");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "ProjectsSchema");
        }
    }
}
