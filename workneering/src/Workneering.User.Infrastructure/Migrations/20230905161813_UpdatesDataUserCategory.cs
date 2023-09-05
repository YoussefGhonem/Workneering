using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class UpdatesDataUserCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCategories",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "CompanyCategories",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "FreelancerSkills",
                schema: "UserSchema");

            migrationBuilder.CreateTable(
                name: "UserCategories",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_UserCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCategories_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "UserSchema",
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCategories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "UserSchema",
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCategories_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalSchema: "UserSchema",
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_UserSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSkills_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "UserSchema",
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSkills_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "UserSchema",
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSkills_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalSchema: "UserSchema",
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSubCategories",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_UserSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubCategories_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "UserSchema",
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSubCategories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "UserSchema",
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSubCategories_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalSchema: "UserSchema",
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_CategoryId",
                schema: "UserSchema",
                table: "UserCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_ClientId",
                schema: "UserSchema",
                table: "UserCategories",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_CompanyId",
                schema: "UserSchema",
                table: "UserCategories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_FreelancerId",
                schema: "UserSchema",
                table: "UserCategories",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_IsDeleted",
                schema: "UserSchema",
                table: "UserCategories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_ClientId",
                schema: "UserSchema",
                table: "UserSkills",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_CompanyId",
                schema: "UserSchema",
                table: "UserSkills",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_FreelancerId",
                schema: "UserSchema",
                table: "UserSkills",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_IsDeleted",
                schema: "UserSchema",
                table: "UserSkills",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillId",
                schema: "UserSchema",
                table: "UserSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubCategories_ClientId",
                schema: "UserSchema",
                table: "UserSubCategories",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubCategories_CompanyId",
                schema: "UserSchema",
                table: "UserSubCategories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubCategories_FreelancerId",
                schema: "UserSchema",
                table: "UserSubCategories",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubCategories_IsDeleted",
                schema: "UserSchema",
                table: "UserSubCategories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubCategories_SubCategoryId",
                schema: "UserSchema",
                table: "UserSubCategories",
                column: "SubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCategories",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "UserSkills",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "UserSubCategories",
                schema: "UserSchema");

            migrationBuilder.CreateTable(
                name: "ClientCategories",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCategories_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "UserSchema",
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyCategories",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyCategories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "UserSchema",
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FreelancerSkills",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreelancerSkills_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalSchema: "UserSchema",
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientCategories_ClientId",
                schema: "UserSchema",
                table: "ClientCategories",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCategories_IsDeleted",
                schema: "UserSchema",
                table: "ClientCategories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCategories_CompanyId",
                schema: "UserSchema",
                table: "CompanyCategories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCategories_IsDeleted",
                schema: "UserSchema",
                table: "CompanyCategories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerSkills_FreelancerId",
                schema: "UserSchema",
                table: "FreelancerSkills",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerSkills_IsDeleted",
                schema: "UserSchema",
                table: "FreelancerSkills",
                column: "IsDeleted");
        }
    }
}
