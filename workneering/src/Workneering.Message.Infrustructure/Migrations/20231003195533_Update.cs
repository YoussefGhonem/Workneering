using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Message.Infrustructure.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientDeleted",
                schema: "ChatSchema",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                schema: "ChatSchema",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderDeleted",
                schema: "ChatSchema",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderId",
                schema: "ChatSchema",
                table: "Messages");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRead",
                schema: "ChatSchema",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                schema: "ChatSchema",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "ChatSchema",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                schema: "ChatSchema",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MessageAttachments",
                schema: "ChatSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Attachments_Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachments_FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachments_Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachments_FileSize = table.Column<long>(type: "bigint", nullable: true),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_MessageAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageAttachments_Messages_MessageId",
                        column: x => x.MessageId,
                        principalSchema: "ChatSchema",
                        principalTable: "Messages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageAttachments_IsDeleted",
                schema: "ChatSchema",
                table: "MessageAttachments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MessageAttachments_MessageId",
                schema: "ChatSchema",
                table: "MessageAttachments",
                column: "MessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageAttachments",
                schema: "ChatSchema");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "ChatSchema",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "ChatSchema",
                table: "Messages");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRead",
                schema: "ChatSchema",
                table: "Messages",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                schema: "ChatSchema",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "RecipientDeleted",
                schema: "ChatSchema",
                table: "Messages",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RecipientId",
                schema: "ChatSchema",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SenderDeleted",
                schema: "ChatSchema",
                table: "Messages",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SenderId",
                schema: "ChatSchema",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
