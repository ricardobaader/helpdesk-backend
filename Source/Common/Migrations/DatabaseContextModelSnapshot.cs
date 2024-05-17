﻿// <auto-generated />
using System;
using Common.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Common.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Common.Domain.Chats.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_updated_at");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("message");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ticket_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.HasIndex("Id", "IsDeleted")
                        .IsUnique();

                    b.ToTable("chat_messages", "dbo");
                });

            modelBuilder.Entity("Common.Domain.Rooms.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_updated_at");

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
                            Id = new Guid("d7ccbde3-942c-4c60-a6a2-59de1918eb60"),
                            CreatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5944),
                            Description = "Sala de Aula - Física Avançada",
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5944),
                            Name = "A1"
                        },
                        new
                        {
                            Id = new Guid("e46d5bad-cce5-42f0-ac5e-24e4e8e8fb82"),
                            CreatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5948),
                            Description = "Laboratório de Química Orgânica",
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5948),
                            Name = "A2"
                        },
                        new
                        {
                            Id = new Guid("c302660b-574d-496b-875c-06918939dad3"),
                            CreatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5951),
                            Description = "Sala de Conferências - Ciências Sociais",
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5951),
                            Name = "B1"
                        },
                        new
                        {
                            Id = new Guid("924ed68e-e3ff-4123-a6c7-5b6780a716ed"),
                            CreatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5963),
                            Description = "Sala de Estudo em Grupo - Matemática",
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5963),
                            Name = "B2"
                        },
                        new
                        {
                            Id = new Guid("3b7baa4f-25aa-487a-89e7-4528de7d466f"),
                            CreatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5965),
                            Description = "Auditório - Palestras de História da Arte",
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5965),
                            Name = "C1"
                        },
                        new
                        {
                            Id = new Guid("1f70629a-394f-4fcb-abce-17ad18a02f26"),
                            CreatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5968),
                            Description = "Sala de Projeção - Filmes de Literatura",
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5968),
                            Name = "C2"
                        },
                        new
                        {
                            Id = new Guid("08e14d3f-b93e-4889-917f-765c0f158a50"),
                            CreatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5970),
                            Description = "Sala de Seminários - Engenharia Civil",
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5970),
                            Name = "D1"
                        },
                        new
                        {
                            Id = new Guid("0ee5db7a-a16d-4de9-a5ab-fe069dd93ad0"),
                            CreatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5973),
                            Description = "Laboratório de Informática - Desenvolvimento de Software",
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5973),
                            Name = "D2"
                        },
                        new
                        {
                            Id = new Guid("07c14ebd-e874-44cd-93a8-765ef3ab9d79"),
                            CreatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5975),
                            Description = "Biblioteca - Estudos de Filosofia",
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5975),
                            Name = "E1"
                        },
                        new
                        {
                            Id = new Guid("450427b2-aaf0-4a69-ba15-b53aaf2a23fb"),
                            CreatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5977),
                            Description = "Sala de Reuniões - Administração de Empresas",
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5977),
                            Name = "E2"
                        });
                });

            modelBuilder.Entity("Common.Domain.TicketImages.TicketImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("image");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_updated_at");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ticket_id");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("Id", "IsDeleted")
                        .IsUnique();

                    b.ToTable("ticket_images", "dbo");
                });

            modelBuilder.Entity("Common.Domain.Tickets.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_updated_at");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("room_id");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<Guid?>("SupportUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("support_user_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("SupportUserId");

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

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_updated_at");

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

                    b.HasData(
                        new
                        {
                            Id = new Guid("a4bd732b-465c-4525-9bea-4909213d32ff"),
                            CreatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(6602),
                            Email = "admin@gmail.com.br",
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(6602),
                            Name = "admin",
                            Password = "admin123",
                            UserType = 2
                        });
                });

            modelBuilder.Entity("Common.Domain.Chats.Chat", b =>
                {
                    b.HasOne("Common.Domain.Tickets.Ticket", "Ticket")
                        .WithMany("Chats")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Common.Domain.Users.User", "User")
                        .WithMany("Chats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Common.Domain.TicketImages.TicketImage", b =>
                {
                    b.HasOne("Common.Domain.Tickets.Ticket", "Ticket")
                        .WithMany("TicketImages")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Common.Domain.Tickets.Ticket", b =>
                {
                    b.HasOne("Common.Domain.Rooms.Room", "Room")
                        .WithMany("Tickets")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Domain.Users.User", "SupportUser")
                        .WithMany("UserSupportTickets")
                        .HasForeignKey("SupportUserId");

                    b.HasOne("Common.Domain.Users.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("SupportUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Common.Domain.Rooms.Room", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Common.Domain.Tickets.Ticket", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("TicketImages");
                });

            modelBuilder.Entity("Common.Domain.Users.User", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("Tickets");

                    b.Navigation("UserSupportTickets");
                });
#pragma warning restore 612, 618
        }
    }
}
