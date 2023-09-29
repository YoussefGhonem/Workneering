﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workneering.Project.Infrastructure.Persistence;

#nullable disable

namespace Workneering.Project.Infrastructure.Migrations
{
    [DbContext(typeof(ProjectsDbContext))]
    [Migration("20230927221925_UpdateImage")]
    partial class UpdateImage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Workneering.Project.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssginedFreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
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

                    b.Property<int?>("HoursPerWeek")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsOpenDueDate")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsRecommend")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("ProjectBudget")
                        .HasColumnType("int");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectDuration")
                        .HasColumnType("int");

                    b.Property<string>("ProjectDurationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ProjectFixedBudgetPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ProjectHourlyFromPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ProjectHourlyToPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProjectStatus")
                        .HasColumnType("int");

                    b.Property<string>("ProjectTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Projects", "ProjectsSchema");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.ProjectActivity", b =>
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

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectActivities", "ProjectsSchema");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.ProjectAttachment", b =>
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

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("ProjectId");

                    b.ToTable("Attachments", "ProjectsSchema");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.ProjectCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectCategories", "ProjectsSchema");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.ProjectSkill", b =>
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("ProjectId");

                    b.ToTable("Skills", "ProjectsSchema");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.ProjectSubCategory", b =>
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectSubCategories", "ProjectsSchema");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.Proposal", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CoverLetter")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<decimal?>("HourlyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ProposalDuration")
                        .HasColumnType("int");

                    b.Property<int?>("ProposalStatus")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalBid")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("ProjectId");

                    b.ToTable("Proposals", "ProjectsSchema");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.Wishlist", b =>
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

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("ProjectId");

                    b.ToTable("Wishlist", "ProjectsSchema");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.ProjectActivity", b =>
                {
                    b.HasOne("Workneering.Project.Domain.Entities.Project", null)
                        .WithMany("Activities")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.ProjectAttachment", b =>
                {
                    b.HasOne("Workneering.Project.Domain.Entities.Project", null)
                        .WithMany("Attachments")
                        .HasForeignKey("ProjectId");

                    b.OwnsOne("Workneering.Shared.Core.Models.FileDto", "ImageDetails", b1 =>
                        {
                            b1.Property<Guid>("ProjectAttachmentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Extension")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FileName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<long?>("FileSize")
                                .HasColumnType("bigint");

                            b1.Property<string>("Key")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProjectAttachmentId");

                            b1.ToTable("Attachments", "ProjectsSchema");

                            b1.WithOwner()
                                .HasForeignKey("ProjectAttachmentId");
                        });

                    b.Navigation("ImageDetails");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.ProjectCategory", b =>
                {
                    b.HasOne("Workneering.Project.Domain.Entities.Project", null)
                        .WithMany("Categories")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.ProjectSkill", b =>
                {
                    b.HasOne("Workneering.Project.Domain.Entities.Project", null)
                        .WithMany("Skills")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.ProjectSubCategory", b =>
                {
                    b.HasOne("Workneering.Project.Domain.Entities.Project", null)
                        .WithMany("SubCategories")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.Proposal", b =>
                {
                    b.HasOne("Workneering.Project.Domain.Entities.Project", null)
                        .WithMany("Proposals")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.Wishlist", b =>
                {
                    b.HasOne("Workneering.Project.Domain.Entities.Project", null)
                        .WithMany("Wishlist")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.Project", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("Attachments");

                    b.Navigation("Categories");

                    b.Navigation("Proposals");

                    b.Navigation("Skills");

                    b.Navigation("SubCategories");

                    b.Navigation("Wishlist");
                });
#pragma warning restore 612, 618
        }
    }
}
