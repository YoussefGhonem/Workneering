using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    public partial class itiation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UserSchema");

            migrationBuilder.CreateTable(
                name: "CertifictionAttachment",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileDetails_Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDetails_FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDetails_Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDetails_FileSize = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_CertifictionAttachment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageDetails_Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageDetails_FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageDetails_Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageDetails_FileSize = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhoIAm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatDoIDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    TitleOverview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOfReviews = table.Column<int>(type: "int", nullable: true),
                    Reviews = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WengazPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProfilePoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PackagePoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeductedPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WengazPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsCountainCountry = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfReviewersOneStars = table.Column<int>(type: "int", nullable: true),
                    NumberOfReviewersTowStars = table.Column<int>(type: "int", nullable: true),
                    NumberOfReviewersThreeStars = table.Column<int>(type: "int", nullable: true),
                    NumberOfReviewersFourStars = table.Column<int>(type: "int", nullable: true),
                    NumberOfReviewersFiveStars = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageDetails_Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageDetails_FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageDetails_Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageDetails_FileSize = table.Column<long>(type: "bigint", nullable: true),
                    VatId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleOverview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhoAreWe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatDoWeDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOfReviews = table.Column<int>(type: "int", nullable: true),
                    Reviews = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WengazPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProfilePoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PackagePoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeductedPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WengazPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsCountainCountry = table.Column<bool>(type: "bit", nullable: false),
                    FoundedIn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CompanySize = table.Column<int>(type: "int", nullable: true),
                    NumberOfReviewersOneStars = table.Column<int>(type: "int", nullable: true),
                    NumberOfReviewersTowStars = table.Column<int>(type: "int", nullable: true),
                    NumberOfReviewersThreeStars = table.Column<int>(type: "int", nullable: true),
                    NumberOfReviewersFourStars = table.Column<int>(type: "int", nullable: true),
                    NumberOfReviewersFiveStars = table.Column<int>(type: "int", nullable: true),
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreelancerCategories",
                schema: "UserSchema",
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
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Freelancers",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMarked = table.Column<bool>(type: "bit", nullable: false),
                    ImageDetails_Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageDetails_FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageDetails_Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageDetails_FileSize = table.Column<long>(type: "bigint", nullable: true),
                    TitleOverview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Reviews = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WengazPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProfilePoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PackagePoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeductedPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WengazPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsCountainCountry = table.Column<bool>(type: "bit", nullable: false),
                    NumOfReviews = table.Column<int>(type: "int", nullable: true),
                    YearsOfExperience = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverviewDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceLevel = table.Column<int>(type: "int", nullable: true),
                    VideoIntroduction_LinkYoutube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoIntroduction_TypeOfVideo = table.Column<int>(type: "int", nullable: true),
                    Availability = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Freelancers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certifications",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Licence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: false),
                    AwardAreaOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GivenBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertifictionAttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certifications_CertifictionAttachment_CertifictionAttachmentId",
                        column: x => x.CertifictionAttachmentId,
                        principalSchema: "UserSchema",
                        principalTable: "CertifictionAttachment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Certifications_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalSchema: "UserSchema",
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearAttended = table.Column<int>(type: "int", nullable: true),
                    YearGraduated = table.Column<int>(type: "int", nullable: true),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalSchema: "UserSchema",
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmploymentHistories",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartYear = table.Column<int>(type: "int", nullable: true),
                    EndYear = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_EmploymentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploymentHistories_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalSchema: "UserSchema",
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalSchema: "UserSchema",
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Language", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Language_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalSchema: "UserSchema",
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartYear = table.Column<int>(type: "int", nullable: true),
                    EndYear = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalSchema: "UserSchema",
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "PortfolioFiles",
                schema: "UserSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileDetails_Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDetails_FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDetails_Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDetails_FileSize = table.Column<long>(type: "bigint", nullable: true),
                    PortfolioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_PortfolioFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioFiles_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalSchema: "UserSchema",
                        principalTable: "Portfolios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_CertifictionAttachmentId",
                schema: "UserSchema",
                table: "Certifications",
                column: "CertifictionAttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_FreelancerId",
                schema: "UserSchema",
                table: "Certifications",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_IsDeleted",
                schema: "UserSchema",
                table: "Certifications",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IsDeleted",
                schema: "UserSchema",
                table: "Clients",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IsDeleted",
                schema: "UserSchema",
                table: "Companies",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_FreelancerId",
                schema: "UserSchema",
                table: "Educations",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_IsDeleted",
                schema: "UserSchema",
                table: "Educations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentHistories_FreelancerId",
                schema: "UserSchema",
                table: "EmploymentHistories",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentHistories_IsDeleted",
                schema: "UserSchema",
                table: "EmploymentHistories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_FreelancerId",
                schema: "UserSchema",
                table: "Experiences",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_IsDeleted",
                schema: "UserSchema",
                table: "Experiences",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_IsDeleted",
                schema: "UserSchema",
                table: "Freelancers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Language_FreelancerId",
                table: "Language",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Language_IsDeleted",
                table: "Language",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioFiles_IsDeleted",
                schema: "UserSchema",
                table: "PortfolioFiles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioFiles_PortfolioId",
                schema: "UserSchema",
                table: "PortfolioFiles",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_FreelancerId",
                schema: "UserSchema",
                table: "Portfolios",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_IsDeleted",
                schema: "UserSchema",
                table: "Portfolios",
                column: "IsDeleted");

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
                name: "Certifications",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "Educations",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "EmploymentHistories",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "Experiences",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "FreelancerCategories",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "PortfolioFiles",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "UserCategories",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "UserSkills",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "UserSubCategories",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "CertifictionAttachment",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "Portfolios",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "UserSchema");

            migrationBuilder.DropTable(
                name: "Freelancers",
                schema: "UserSchema");
        }
    }
}
