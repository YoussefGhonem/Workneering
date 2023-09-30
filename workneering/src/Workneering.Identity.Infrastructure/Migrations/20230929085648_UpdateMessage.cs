using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.Identity.Infrastructure.Migrations
{
    public partial class UpdateMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                schema: "IdentitySchema",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId1",
                schema: "IdentitySchema",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                schema: "IdentitySchema",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId1",
                schema: "IdentitySchema",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "IdentitySchema",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "IdentitySchema",
                table: "Messages");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipientId",
                schema: "IdentitySchema",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SenderId",
                schema: "IdentitySchema",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                schema: "IdentitySchema",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                schema: "IdentitySchema",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_RecipientId",
                schema: "IdentitySchema",
                table: "Messages",
                column: "RecipientId",
                principalSchema: "IdentitySchema",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderId",
                schema: "IdentitySchema",
                table: "Messages",
                column: "SenderId",
                principalSchema: "IdentitySchema",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_RecipientId",
                schema: "IdentitySchema",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderId",
                schema: "IdentitySchema",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_RecipientId",
                schema: "IdentitySchema",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId",
                schema: "IdentitySchema",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                schema: "IdentitySchema",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderId",
                schema: "IdentitySchema",
                table: "Messages");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "IdentitySchema",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                schema: "IdentitySchema",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                schema: "IdentitySchema",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId1",
                schema: "IdentitySchema",
                table: "Messages",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                schema: "IdentitySchema",
                table: "Messages",
                column: "UserId",
                principalSchema: "IdentitySchema",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId1",
                schema: "IdentitySchema",
                table: "Messages",
                column: "UserId1",
                principalSchema: "IdentitySchema",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
