using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Project.Infrastructure.Migrations
{
    public partial class Intitial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSkills_Projects_ProjectId",
                schema: "ProjectsSchema",
                table: "ProjectSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectSkills",
                schema: "ProjectsSchema",
                table: "ProjectSkills");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "ProjectsSchema",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                schema: "ProjectsSchema",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "ProjectSkills",
                schema: "ProjectsSchema",
                newName: "Skills",
                newSchema: "ProjectsSchema");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectSkills_ProjectId",
                schema: "ProjectsSchema",
                table: "Skills",
                newName: "IX_Skills_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectSkills_IsDeleted",
                schema: "ProjectsSchema",
                table: "Skills",
                newName: "IX_Skills_IsDeleted");

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillId",
                schema: "ProjectsSchema",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                schema: "ProjectsSchema",
                table: "Skills",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProjectCategories",
                schema: "ProjectsSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_ProjectCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectCategories_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "ProjectsSchema",
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectSubCategories",
                schema: "ProjectsSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_ProjectSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectSubCategories_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "ProjectsSchema",
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCategories_IsDeleted",
                schema: "ProjectsSchema",
                table: "ProjectCategories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCategories_ProjectId",
                schema: "ProjectsSchema",
                table: "ProjectCategories",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSubCategories_IsDeleted",
                schema: "ProjectsSchema",
                table: "ProjectSubCategories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSubCategories_ProjectId",
                schema: "ProjectsSchema",
                table: "ProjectSubCategories",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Projects_ProjectId",
                schema: "ProjectsSchema",
                table: "Skills",
                column: "ProjectId",
                principalSchema: "ProjectsSchema",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Projects_ProjectId",
                schema: "ProjectsSchema",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "ProjectCategories",
                schema: "ProjectsSchema");

            migrationBuilder.DropTable(
                name: "ProjectSubCategories",
                schema: "ProjectsSchema");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                schema: "ProjectsSchema",
                table: "Skills");

            migrationBuilder.RenameTable(
                name: "Skills",
                schema: "ProjectsSchema",
                newName: "ProjectSkills",
                newSchema: "ProjectsSchema");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_ProjectId",
                schema: "ProjectsSchema",
                table: "ProjectSkills",
                newName: "IX_ProjectSkills_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_IsDeleted",
                schema: "ProjectsSchema",
                table: "ProjectSkills",
                newName: "IX_ProjectSkills_IsDeleted");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                schema: "ProjectsSchema",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubCategoryId",
                schema: "ProjectsSchema",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillId",
                schema: "ProjectsSchema",
                table: "ProjectSkills",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectSkills",
                schema: "ProjectsSchema",
                table: "ProjectSkills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSkills_Projects_ProjectId",
                schema: "ProjectsSchema",
                table: "ProjectSkills",
                column: "ProjectId",
                principalSchema: "ProjectsSchema",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
