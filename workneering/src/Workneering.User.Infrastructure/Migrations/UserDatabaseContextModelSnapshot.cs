﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workneering.User.Infrastructure.Persistence;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    [DbContext(typeof(UserDatabaseContext))]
    partial class UserDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Workneering.User.Domain.Entites.Certification", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AwardAreaOfStudy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EndYear")
                        .HasColumnType("int");

                    b.Property<Guid?>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GivenBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Licence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Certifications", "UserSchema");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal?>("DeductedPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsCountainCountry")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal?>("MonthPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumOfReviews")
                        .HasColumnType("int");

                    b.Property<decimal?>("PackagePoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ProfilePoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Reviews")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleOverview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("WengazPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("WengazPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WhatDoIDo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhoIAm")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Clients", "UserSchema");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CompanySize")
                        .HasColumnType("int");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal?>("DeductedPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("FoundedIn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("IndustryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCountainCountry")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal?>("MonthPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumOfReviews")
                        .HasColumnType("int");

                    b.Property<decimal?>("PackagePoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ProfilePoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Reviews")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleOverview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VatId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("WengazPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("WengazPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WhatDoWeDo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhoAreWe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Companies", "UserSchema");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Education", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YearAttended")
                        .HasColumnType("int");

                    b.Property<int?>("YearGraduated")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Educations", "UserSchema");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.EmploymentHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<Guid?>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StartYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("EmploymentHistories", "UserSchema");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Experience", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Experiences", "UserSchema");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Freelancer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Availability")
                        .HasColumnType("int");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal?>("DeductedPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("ExperienceLevel")
                        .HasColumnType("int");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<decimal?>("HourlyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsCountainCountry")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMarked")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal?>("MonthPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumOfReviews")
                        .HasColumnType("int");

                    b.Property<string>("OverviewDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PackagePoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ProfilePoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Reviews")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleOverview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("WengazPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("WengazPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("YearsOfExperience")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Freelancers", "UserSchema");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.FreelancerCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("FreelancerCategories", "UserSchema");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Portfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<Guid?>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Portfolios", "UserSchema");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.PortfolioFile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("PortfolioId");

                    b.ToTable("PortfolioFile");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.UserCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("UserCategories", "UserSchema");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.UserSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("SkillId");

                    b.ToTable("UserSkills", "UserSchema");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.UserSubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("SubCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("UserSubCategories", "UserSchema");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Certification", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Freelancer", null)
                        .WithMany("Certifications")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Client", b =>
                {
                    b.OwnsOne("Workneering.User.Domain.valueobjects.ReviewersStars", "ReviewersStars", b1 =>
                        {
                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int?>("NumberOfReviewersFiveStars")
                                .HasColumnType("int")
                                .HasColumnName("NumberOfReviewersFiveStars");

                            b1.Property<int?>("NumberOfReviewersFourStars")
                                .HasColumnType("int")
                                .HasColumnName("NumberOfReviewersFourStars");

                            b1.Property<int?>("NumberOfReviewersOneStars")
                                .HasColumnType("int")
                                .HasColumnName("NumberOfReviewersOneStars");

                            b1.Property<int?>("NumberOfReviewersThreeStars")
                                .HasColumnType("int")
                                .HasColumnName("NumberOfReviewersThreeStars");

                            b1.Property<int?>("NumberOfReviewersTowStars")
                                .HasColumnType("int")
                                .HasColumnName("NumberOfReviewersTowStars");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients", "UserSchema");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.Navigation("ReviewersStars");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Company", b =>
                {
                    b.OwnsOne("Workneering.User.Domain.valueobjects.ReviewersStars", "ReviewersStars", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int?>("NumberOfReviewersFiveStars")
                                .HasColumnType("int")
                                .HasColumnName("NumberOfReviewersFiveStars");

                            b1.Property<int?>("NumberOfReviewersFourStars")
                                .HasColumnType("int")
                                .HasColumnName("NumberOfReviewersFourStars");

                            b1.Property<int?>("NumberOfReviewersOneStars")
                                .HasColumnType("int")
                                .HasColumnName("NumberOfReviewersOneStars");

                            b1.Property<int?>("NumberOfReviewersThreeStars")
                                .HasColumnType("int")
                                .HasColumnName("NumberOfReviewersThreeStars");

                            b1.Property<int?>("NumberOfReviewersTowStars")
                                .HasColumnType("int")
                                .HasColumnName("NumberOfReviewersTowStars");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Companies", "UserSchema");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");
                        });

                    b.Navigation("ReviewersStars");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Education", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Freelancer", null)
                        .WithMany("Educations")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.EmploymentHistory", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Freelancer", null)
                        .WithMany("EmploymentHistory")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Experience", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Freelancer", null)
                        .WithMany("Experiences")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Freelancer", b =>
                {
                    b.OwnsOne("Workneering.User.Domain.valueobjects.VideoIntroduction", "VideoIntroduction", b1 =>
                        {
                            b1.Property<Guid>("FreelancerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("LinkYoutube")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int?>("TypeOfVideo")
                                .HasColumnType("int");

                            b1.HasKey("FreelancerId");

                            b1.ToTable("Freelancers", "UserSchema");

                            b1.WithOwner()
                                .HasForeignKey("FreelancerId");
                        });

                    b.Navigation("VideoIntroduction");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Language", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Freelancer", null)
                        .WithMany("Languages")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Portfolio", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Freelancer", null)
                        .WithMany("Portfolios")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.PortfolioFile", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Portfolio", null)
                        .WithMany("PortfolioFiles")
                        .HasForeignKey("PortfolioId");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.UserCategory", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Client", null)
                        .WithMany("Categories")
                        .HasForeignKey("ClientId");

                    b.HasOne("Workneering.User.Domain.Entites.Company", null)
                        .WithMany("Categories")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Workneering.User.Domain.Entites.Freelancer", null)
                        .WithMany("Categories")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.UserSkill", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Client", null)
                        .WithMany("Skills")
                        .HasForeignKey("ClientId");

                    b.HasOne("Workneering.User.Domain.Entites.Company", null)
                        .WithMany("Skills")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Workneering.User.Domain.Entites.Freelancer", null)
                        .WithMany("Skills")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.UserSubCategory", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Client", null)
                        .WithMany("SubCategories")
                        .HasForeignKey("ClientId");

                    b.HasOne("Workneering.User.Domain.Entites.Company", null)
                        .WithMany("SubCategories")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Workneering.User.Domain.Entites.Freelancer", null)
                        .WithMany("SubCategories")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Client", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Skills");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Company", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Skills");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Freelancer", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Certifications");

                    b.Navigation("Educations");

                    b.Navigation("EmploymentHistory");

                    b.Navigation("Experiences");

                    b.Navigation("Languages");

                    b.Navigation("Portfolios");

                    b.Navigation("Skills");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Portfolio", b =>
                {
                    b.Navigation("PortfolioFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
