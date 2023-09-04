using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Settings.Infrastructure.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Categories_CategoryId",
                schema: "SettingsSchema.Refrences",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "IsMain",
                schema: "SettingsSchema",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "SettingsSchema",
                newName: "Categories",
                newSchema: "SettingsSchema.Refrences");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "SettingsSchema.Refrences",
                table: "Skills",
                newName: "SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_CategoryId",
                schema: "SettingsSchema.Refrences",
                table: "Skills",
                newName: "IX_Skills_SubCategoryId");

            migrationBuilder.CreateTable(
                name: "SubCategories",
                schema: "SettingsSchema.Refrences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "SettingsSchema.Refrences",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                schema: "SettingsSchema.Refrences",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_IsDeleted",
                schema: "SettingsSchema.Refrences",
                table: "SubCategories",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SubCategories_SubCategoryId",
                schema: "SettingsSchema.Refrences",
                table: "Skills",
                column: "SubCategoryId",
                principalSchema: "SettingsSchema.Refrences",
                principalTable: "SubCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SubCategories_SubCategoryId",
                schema: "SettingsSchema.Refrences",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "SubCategories",
                schema: "SettingsSchema.Refrences");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "SettingsSchema.Refrences",
                newName: "Categories",
                newSchema: "SettingsSchema");

            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                schema: "SettingsSchema.Refrences",
                table: "Skills",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_SubCategoryId",
                schema: "SettingsSchema.Refrences",
                table: "Skills",
                newName: "IX_Skills_CategoryId");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                schema: "SettingsSchema",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Categories_CategoryId",
                schema: "SettingsSchema.Refrences",
                table: "Skills",
                column: "CategoryId",
                principalSchema: "SettingsSchema",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
