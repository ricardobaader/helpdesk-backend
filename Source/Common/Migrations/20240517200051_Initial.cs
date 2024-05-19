using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Common.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "rooms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    userType = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    room_id = table.Column<Guid>(type: "uuid", nullable: false),
                    support_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_tickets_rooms_room_id",
                        column: x => x.room_id,
                        principalSchema: "dbo",
                        principalTable: "rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tickets_users_support_user_id",
                        column: x => x.support_user_id,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tickets_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chat_messages",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ticket_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_chat_messages_tickets_ticket_id",
                        column: x => x.ticket_id,
                        principalSchema: "dbo",
                        principalTable: "tickets",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_chat_messages_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ticket_images",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ticket_id = table.Column<Guid>(type: "uuid", nullable: false),
                    image = table.Column<byte[]>(type: "bytea", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_ticket_images_tickets_ticket_id",
                        column: x => x.ticket_id,
                        principalSchema: "dbo",
                        principalTable: "tickets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "rooms",
                columns: new[] { "id", "created_at", "description", "is_deleted", "last_updated_at", "name" },
                values: new object[,]
                {
                    { new Guid("01e790b9-cf98-434f-938b-8cb35fe1cd2f"), new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8801), "Sala de Estudo em Grupo - Matemática", false, new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8801), "B2" },
                    { new Guid("0c4dc28c-6da2-4f9a-9988-4f2f91184411"), new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8779), "Sala de Aula - Física Avançada", false, new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8779), "A1" },
                    { new Guid("3c98991a-13f6-4915-bb7d-0ea7fc30628d"), new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8805), "Auditório - Palestras de História da Arte", false, new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8805), "C1" },
                    { new Guid("6bde5fa1-b7c3-4db0-8c4a-145f50e2853f"), new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8828), "Sala de Projeção - Filmes de Literatura", false, new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8828), "C2" },
                    { new Guid("749d0d36-265d-4a58-bb1d-a26a5dc33619"), new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8843), "Biblioteca - Estudos de Filosofia", false, new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8843), "E1" },
                    { new Guid("7cf046c2-40b2-4b63-b097-eb88f08fbb88"), new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8838), "Laboratório de Informática - Desenvolvimento de Software", false, new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8838), "D2" },
                    { new Guid("916ab47c-8152-4da8-9f07-aa86f1deebe1"), new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8796), "Sala de Conferências - Ciências Sociais", false, new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8796), "B1" },
                    { new Guid("c0271f70-2609-4d2d-b9db-2d5542359048"), new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8847), "Sala de Reuniões - Administração de Empresas", false, new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8847), "E2" },
                    { new Guid("e3b4a787-d2c6-41a4-8495-ca73efb58b8f"), new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8834), "Sala de Seminários - Engenharia Civil", false, new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8834), "D1" },
                    { new Guid("e95114c2-fa39-445f-9b4b-6daf3bdde121"), new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8790), "Laboratório de Química Orgânica", false, new DateTime(2024, 5, 17, 20, 0, 51, 142, DateTimeKind.Utc).AddTicks(8790), "A2" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "users",
                columns: new[] { "id", "created_at", "email", "is_deleted", "last_updated_at", "name", "password", "userType" },
                values: new object[] { new Guid("d05c7c01-8786-46c1-a03b-87808caa1e54"), new DateTime(2024, 5, 17, 20, 0, 51, 143, DateTimeKind.Utc).AddTicks(436), "admin@gmail.com.br", false, new DateTime(2024, 5, 17, 20, 0, 51, 143, DateTimeKind.Utc).AddTicks(436), "admin", "admin123", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_chat_messages_id_is_deleted",
                schema: "dbo",
                table: "chat_messages",
                columns: new[] { "id", "is_deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chat_messages_ticket_id",
                schema: "dbo",
                table: "chat_messages",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_messages_user_id",
                schema: "dbo",
                table: "chat_messages",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_id_is_deleted",
                schema: "dbo",
                table: "rooms",
                columns: new[] { "id", "is_deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticket_images_id_is_deleted",
                schema: "dbo",
                table: "ticket_images",
                columns: new[] { "id", "is_deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticket_images_ticket_id",
                schema: "dbo",
                table: "ticket_images",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_id_is_deleted",
                schema: "dbo",
                table: "tickets",
                columns: new[] { "id", "is_deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_room_id",
                schema: "dbo",
                table: "tickets",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_support_user_id",
                schema: "dbo",
                table: "tickets",
                column: "support_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_user_id",
                schema: "dbo",
                table: "tickets",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_id_is_deleted",
                schema: "dbo",
                table: "users",
                columns: new[] { "id", "is_deleted" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chat_messages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ticket_images",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tickets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "rooms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "users",
                schema: "dbo");
        }
    }
}
