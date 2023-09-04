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
    [Migration("20230904213330_Intitial2")]
    partial class Intitial2
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

                    b.Property<string>("DueDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExperienceLevel")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsOpenDueDate")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("ProjectBudget")
                        .HasColumnType("int");

                    b.Property<decimal?>("ProjectBudgetPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<Guid?>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectSkills", "ProjectsSchema");
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

            modelBuilder.Entity("Workneering.Project.Domain.Entities.Project", b =>
                {
                    b.OwnsOne("Workneering.Project.Domain.ValueObject.ProjectCategory", "ProjectCategory", b1 =>
                        {
                            b1.Property<Guid>("ProjectId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("CategoryId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("CategoryId");

                            b1.Property<Guid>("SubCategoryId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("SubCategoryId");

                            b1.HasKey("ProjectId");

                            b1.ToTable("Projects", "ProjectsSchema");

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.Navigation("ProjectCategory");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.ProjectActivity", b =>
                {
                    b.HasOne("Workneering.Project.Domain.Entities.Project", null)
                        .WithMany("Activities")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Workneering.Project.Domain.Entities.ProjectSkill", b =>
                {
                    b.HasOne("Workneering.Project.Domain.Entities.Project", null)
                        .WithMany("RequiredSkills")
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

                    b.Navigation("Proposals");

                    b.Navigation("RequiredSkills");

                    b.Navigation("Wishlist");
                });
#pragma warning restore 612, 618
        }
    }
}
