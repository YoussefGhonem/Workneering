using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class CreateTablePortfoilFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioFile_Portfolios_PortfolioId",
                table: "PortfolioFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PortfolioFile",
                table: "PortfolioFile");

            migrationBuilder.RenameTable(
                name: "PortfolioFile",
                newName: "PortfolioFiles",
                newSchema: "UserSchema");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioFile_PortfolioId",
                schema: "UserSchema",
                table: "PortfolioFiles",
                newName: "IX_PortfolioFiles_PortfolioId");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioFile_IsDeleted",
                schema: "UserSchema",
                table: "PortfolioFiles",
                newName: "IX_PortfolioFiles_IsDeleted");

            migrationBuilder.AddColumn<string>(
                name: "FileDetails_Extension",
                schema: "UserSchema",
                table: "PortfolioFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileDetails_FileName",
                schema: "UserSchema",
                table: "PortfolioFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileDetails_FileSize",
                schema: "UserSchema",
                table: "PortfolioFiles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileDetails_Key",
                schema: "UserSchema",
                table: "PortfolioFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortfolioFiles",
                schema: "UserSchema",
                table: "PortfolioFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioFiles_Portfolios_PortfolioId",
                schema: "UserSchema",
                table: "PortfolioFiles",
                column: "PortfolioId",
                principalSchema: "UserSchema",
                principalTable: "Portfolios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioFiles_Portfolios_PortfolioId",
                schema: "UserSchema",
                table: "PortfolioFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PortfolioFiles",
                schema: "UserSchema",
                table: "PortfolioFiles");

            migrationBuilder.DropColumn(
                name: "FileDetails_Extension",
                schema: "UserSchema",
                table: "PortfolioFiles");

            migrationBuilder.DropColumn(
                name: "FileDetails_FileName",
                schema: "UserSchema",
                table: "PortfolioFiles");

            migrationBuilder.DropColumn(
                name: "FileDetails_FileSize",
                schema: "UserSchema",
                table: "PortfolioFiles");

            migrationBuilder.DropColumn(
                name: "FileDetails_Key",
                schema: "UserSchema",
                table: "PortfolioFiles");

            migrationBuilder.RenameTable(
                name: "PortfolioFiles",
                schema: "UserSchema",
                newName: "PortfolioFile");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioFiles_PortfolioId",
                table: "PortfolioFile",
                newName: "IX_PortfolioFile_PortfolioId");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioFiles_IsDeleted",
                table: "PortfolioFile",
                newName: "IX_PortfolioFile_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortfolioFile",
                table: "PortfolioFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioFile_Portfolios_PortfolioId",
                table: "PortfolioFile",
                column: "PortfolioId",
                principalSchema: "UserSchema",
                principalTable: "Portfolios",
                principalColumn: "Id");
        }
    }
}
