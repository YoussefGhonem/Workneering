﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workneering.User.Infrastructure.Persistence;

#nullable disable

namespace Workneering.User.Infrastructure.Migrations
{
    [DbContext(typeof(UserDatabaseContext))]
    [Migration("20230901164428_UpdateFreelancerTable4")]
    partial class UpdateFreelancerTable4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Workneering.User.Domain.Entites.Category", b =>
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Categories", "User");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Certification", b =>
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

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Certifications", "User");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Client", b =>
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

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Company", b =>
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

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Companies");
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

                    b.ToTable("Educations", "User");
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

                    b.Property<DateTimeOffset?>("EndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCurrentlyWork")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("EmploymentHistories", "User");
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

                    b.ToTable("Experiences", "User");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Freelancer", b =>
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

                    b.Property<int?>("ExperienceLevel")
                        .HasColumnType("int");

                    b.Property<decimal?>("HourlyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("OverviewDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Visibility")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Freelancers", "User");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.FreelancerSkill", b =>
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("FreelancerSkills", "User");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Portfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CompletionDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FileCaption")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("ProjectSolutionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectTaskDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RelatedSpecializedProfile")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Template")
                        .HasColumnType("int");

                    b.Property<string>("YouTubeLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Portfolios", "User");
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

            modelBuilder.Entity("Workneering.User.Domain.Entites.PortfolioSkill", b =>
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("PortfolioId");

                    b.ToTable("PortfolioSkill");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Category", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Freelancer", null)
                        .WithMany("Categories")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Certification", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Freelancer", null)
                        .WithMany("Certifications")
                        .HasForeignKey("FreelancerId");
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

                    b.OwnsOne("Workneering.Shared.Core.Models.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("EmploymentHistoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CountryName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EmploymentHistoryId");

                            b1.ToTable("EmploymentHistories", "User");

                            b1.WithOwner()
                                .HasForeignKey("EmploymentHistoryId");
                        });

                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Experience", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Freelancer", null)
                        .WithMany("Experiences")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Freelancer", b =>
                {
                    b.OwnsOne("Workneering.User.Domain.valueobjects.Availability", "Availability", b1 =>
                        {
                            b1.Property<Guid>("FreelancerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool?>("ContractToHire")
                                .HasColumnType("bit");

                            b1.Property<DateTimeOffset?>("DateForNewWork")
                                .HasColumnType("datetimeoffset");

                            b1.Property<int?>("HoursPerWeek")
                                .HasColumnType("int");

                            b1.HasKey("FreelancerId");

                            b1.ToTable("Freelancers", "User");

                            b1.WithOwner()
                                .HasForeignKey("FreelancerId");
                        });

                    b.OwnsOne("Workneering.User.Domain.valueobjects.VideoIntroduction", "VideoIntroduction", b1 =>
                        {
                            b1.Property<Guid>("FreelancerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("LinkYoutube")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int?>("TypeOfVideo")
                                .HasColumnType("int");

                            b1.HasKey("FreelancerId");

                            b1.ToTable("Freelancers", "User");

                            b1.WithOwner()
                                .HasForeignKey("FreelancerId");
                        });

                    b.Navigation("Availability");

                    b.Navigation("VideoIntroduction");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.FreelancerSkill", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Freelancer", null)
                        .WithMany("FreelancerSkills")
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

            modelBuilder.Entity("Workneering.User.Domain.Entites.PortfolioSkill", b =>
                {
                    b.HasOne("Workneering.User.Domain.Entites.Portfolio", null)
                        .WithMany("PortfolioSkills")
                        .HasForeignKey("PortfolioId");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Freelancer", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Certifications");

                    b.Navigation("Educations");

                    b.Navigation("EmploymentHistory");

                    b.Navigation("Experiences");

                    b.Navigation("FreelancerSkills");

                    b.Navigation("Portfolios");
                });

            modelBuilder.Entity("Workneering.User.Domain.Entites.Portfolio", b =>
                {
                    b.Navigation("PortfolioFiles");

                    b.Navigation("PortfolioSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
