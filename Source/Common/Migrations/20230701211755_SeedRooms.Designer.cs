﻿// <auto-generated />
using System;
using Common.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Common.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230701211755_SeedRooms")]
    partial class SeedRooms
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Common.Domain.Rooms.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Id", "IsDeleted")
                        .IsUnique();

                    b.ToTable("rooms", "dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("841e259d-cd5d-4997-8812-7e5f410fd4fa"),
                            IsDeleted = false,
                            Name = "A1"
                        },
                        new
                        {
                            Id = new Guid("1803fe74-ec77-4636-ba82-62218d67ec6d"),
                            IsDeleted = false,
                            Name = "A2"
                        },
                        new
                        {
                            Id = new Guid("8bfc63ea-deec-40bf-a54c-9343b29ca851"),
                            IsDeleted = false,
                            Name = "B1"
                        },
                        new
                        {
                            Id = new Guid("b1285d62-db5d-4a0e-894b-4aeee67480af"),
                            IsDeleted = false,
                            Name = "B2"
                        },
                        new
                        {
                            Id = new Guid("7a866c5b-ccf9-4dab-9355-1d6a22c092c5"),
                            IsDeleted = false,
                            Name = "C1"
                        },
                        new
                        {
                            Id = new Guid("2b773451-1765-494d-be0a-860939938b57"),
                            IsDeleted = false,
                            Name = "C2"
                        },
                        new
                        {
                            Id = new Guid("17a0910f-3b6d-42cf-b7ed-d6b243d43eb2"),
                            IsDeleted = false,
                            Name = "D1"
                        },
                        new
                        {
                            Id = new Guid("22427b3c-e652-4d93-9b9a-76369e56a5f6"),
                            IsDeleted = false,
                            Name = "D2"
                        },
                        new
                        {
                            Id = new Guid("76c18967-ff4b-4af1-9b87-83bc99076579"),
                            IsDeleted = false,
                            Name = "E1"
                        },
                        new
                        {
                            Id = new Guid("87d43a76-e5e3-45f9-8c5a-84ddc9d22352"),
                            IsDeleted = false,
                            Name = "E2"
                        });
                });

            modelBuilder.Entity("Common.Domain.Tickets.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("room");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("Id", "IsDeleted")
                        .IsUnique();

                    b.ToTable("tickets", "dbo");
                });

            modelBuilder.Entity("Common.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<int>("UserType")
                        .HasColumnType("int")
                        .HasColumnName("userType");

                    b.HasKey("Id");

                    b.HasIndex("Id", "IsDeleted")
                        .IsUnique();

                    b.ToTable("users", "dbo");
                });

            modelBuilder.Entity("Common.Domain.Tickets.Ticket", b =>
                {
                    b.HasOne("Common.Domain.Users.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Common.Domain.Users.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}