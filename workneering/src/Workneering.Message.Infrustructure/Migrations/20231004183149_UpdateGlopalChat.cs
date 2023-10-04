using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Message.Infrustructure.Migrations
{
    public partial class UpdateGlopalChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlopalChats",
                schema: "ChatSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateRead = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_GlopalChats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "ChatSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlopalChatAttachments",
                schema: "ChatSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Attachments_Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachments_FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachments_Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachments_FileSize = table.Column<long>(type: "bigint", nullable: true),
                    GlopalChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_GlopalChatAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlopalChatAttachments_GlopalChats_GlopalChatId",
                        column: x => x.GlopalChatId,
                        principalSchema: "ChatSchema",
                        principalTable: "GlopalChats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlopalChatAttachments_GlopalChatId",
                schema: "ChatSchema",
                table: "GlopalChatAttachments",
                column: "GlopalChatId");

            migrationBuilder.CreateIndex(
                name: "IX_GlopalChatAttachments_IsDeleted",
                schema: "ChatSchema",
                table: "GlopalChatAttachments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GlopalChats_IsDeleted",
                schema: "ChatSchema",
                table: "GlopalChats",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IsDeleted",
                schema: "ChatSchema",
                table: "Rooms",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlopalChatAttachments",
                schema: "ChatSchema");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "ChatSchema");

            migrationBuilder.DropTable(
                name: "GlopalChats",
                schema: "ChatSchema");
        }
    }
}
