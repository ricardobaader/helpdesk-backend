using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    qr_code = table.Column<byte[]>(type: "bytea", nullable: true),
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
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
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
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        principalTable: "rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tickets_users_support_user_id",
                        column: x => x.support_user_id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tickets_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chat_messages",
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
                        principalTable: "tickets",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_chat_messages_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ticket_images",
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
                        principalTable: "tickets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "id", "created_at", "description", "is_deleted", "last_updated_at", "name", "qr_code" },
                values: new object[,]
                {
                    { new Guid("341d68bf-ebfb-4e3c-8749-e716827f48bd"), new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7700), "Biblioteca - Estudos de Filosofia", false, new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7700), "E1", null },
                    { new Guid("5551bdbf-9c2e-495c-97c6-c2a68ebf3b1a"), new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7702), "Sala de Reuniões - Administração de Empresas", false, new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7702), "E2", null },
                    { new Guid("5d1164ca-3b93-4b4c-9281-2e8868fbe151"), new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7687), "Sala de Estudo em Grupo - Matemática", false, new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7687), "B2", null },
                    { new Guid("9d88d8e3-f41b-4dbe-a4e3-58a67bff9771"), new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7689), "Auditório - Palestras de História da Arte", false, new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7689), "C1", null },
                    { new Guid("d042c31a-5454-4bef-890c-aa06db7333cc"), new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7678), "Sala de Aula - Física Avançada", false, new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7678), "A1", null },
                    { new Guid("dee09be6-a2f8-4ac1-a68c-15f0e5b1ede9"), new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7696), "Laboratório de Informática - Desenvolvimento de Software", false, new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7696), "D2", null },
                    { new Guid("e1f047ea-a10e-4622-8927-752ab8f4874d"), new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7685), "Sala de Conferências - Ciências Sociais", false, new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7685), "B1", null },
                    { new Guid("e270a034-caea-492c-a3f5-d01c74e8ca21"), new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7692), "Sala de Projeção - Filmes de Literatura", false, new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7692), "C2", null },
                    { new Guid("e42bae84-0ef7-4888-8984-5761fd5a2076"), new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7682), "Laboratório de Química Orgânica", false, new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7682), "A2", null },
                    { new Guid("ea78e078-1e9f-433c-9977-567ce3c4c240"), new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7694), "Sala de Seminários - Engenharia Civil", false, new DateTime(2024, 6, 21, 0, 2, 18, 68, DateTimeKind.Utc).AddTicks(7694), "D1", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_chat_messages_id_is_deleted",
                table: "chat_messages",
                columns: new[] { "id", "is_deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chat_messages_ticket_id",
                table: "chat_messages",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_messages_user_id",
                table: "chat_messages",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_id_is_deleted",
                table: "rooms",
                columns: new[] { "id", "is_deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticket_images_id_is_deleted",
                table: "ticket_images",
                columns: new[] { "id", "is_deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticket_images_ticket_id",
                table: "ticket_images",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_id_is_deleted",
                table: "tickets",
                columns: new[] { "id", "is_deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_room_id",
                table: "tickets",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_support_user_id",
                table: "tickets",
                column: "support_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_user_id",
                table: "tickets",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_id_is_deleted",
                table: "users",
                columns: new[] { "id", "is_deleted" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chat_messages");

            migrationBuilder.DropTable(
                name: "ticket_images");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
