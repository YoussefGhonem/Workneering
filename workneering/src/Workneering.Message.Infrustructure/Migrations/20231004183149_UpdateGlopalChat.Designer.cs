﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workneering.Message.Infrustructure.Persistence;

#nullable disable

namespace Workneering.Message.Infrustructure.Migrations
{
    [DbContext(typeof(MessagesDbContext))]
    [Migration("20231004183149_UpdateGlopalChat")]
    partial class UpdateGlopalChat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Workneering.Message.Domain.Entities.GlopalChat", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("GlopalChats", "ChatSchema");
                });

            modelBuilder.Entity("Workneering.Message.Domain.Entities.GlopalChatAttachments", b =>
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

                    b.Property<Guid?>("GlopalChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("GlopalChatId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("GlopalChatAttachments", "ChatSchema");
                });

            modelBuilder.Entity("Workneering.Message.Domain.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Messages", "ChatSchema");
                });

            modelBuilder.Entity("Workneering.Message.Domain.Entities.MessageAttachments", b =>
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

                    b.Property<Guid?>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("MessageId");

                    b.ToTable("MessageAttachments", "ChatSchema");
                });

            modelBuilder.Entity("Workneering.Message.Domain.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Rooms", "ChatSchema");
                });

            modelBuilder.Entity("Workneering.Message.Domain.Entities.GlopalChatAttachments", b =>
                {
                    b.HasOne("Workneering.Message.Domain.Entities.GlopalChat", null)
                        .WithMany("GlopalChatAttachments")
                        .HasForeignKey("GlopalChatId");

                    b.OwnsOne("Workneering.Shared.Core.Models.FileDto", "Attachments", b1 =>
                        {
                            b1.Property<Guid>("GlopalChatAttachmentsId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Extension")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FileName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<long?>("FileSize")
                                .HasColumnType("bigint");

                            b1.Property<string>("Key")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("GlopalChatAttachmentsId");

                            b1.ToTable("GlopalChatAttachments", "ChatSchema");

                            b1.WithOwner()
                                .HasForeignKey("GlopalChatAttachmentsId");
                        });

                    b.Navigation("Attachments")
                        .IsRequired();
                });

            modelBuilder.Entity("Workneering.Message.Domain.Entities.MessageAttachments", b =>
                {
                    b.HasOne("Workneering.Message.Domain.Entities.Message", null)
                        .WithMany("MessageAttachments")
                        .HasForeignKey("MessageId");

                    b.OwnsOne("Workneering.Shared.Core.Models.FileDto", "Attachments", b1 =>
                        {
                            b1.Property<Guid>("MessageAttachmentsId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Extension")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FileName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<long?>("FileSize")
                                .HasColumnType("bigint");

                            b1.Property<string>("Key")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("MessageAttachmentsId");

                            b1.ToTable("MessageAttachments", "ChatSchema");

                            b1.WithOwner()
                                .HasForeignKey("MessageAttachmentsId");
                        });

                    b.Navigation("Attachments")
                        .IsRequired();
                });

            modelBuilder.Entity("Workneering.Message.Domain.Entities.GlopalChat", b =>
                {
                    b.Navigation("GlopalChatAttachments");
                });

            modelBuilder.Entity("Workneering.Message.Domain.Entities.Message", b =>
                {
                    b.Navigation("MessageAttachments");
                });
#pragma warning restore 612, 618
        }
    }
}
