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
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
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
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userType = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
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
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    room_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    support_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "ticket_images",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ticket_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
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
                columns: new[] { "id", "created_at", "description", "is_deleted", "name" },
                values: new object[,]
                {
                    { new Guid("05e51fd4-e2ab-43b9-9d62-2592de23db4d"), new DateTime(2024, 4, 21, 1, 22, 19, 797, DateTimeKind.Utc).AddTicks(4887), "Sala de Estudo em Grupo - Matemática", false, "B2" },
                    { new Guid("28520bf4-6548-4491-8d43-837d3c7e7fa7"), new DateTime(2024, 4, 21, 1, 22, 19, 797, DateTimeKind.Utc).AddTicks(4900), "Biblioteca - Estudos de Filosofia", false, "E1" },
                    { new Guid("4a36519a-4178-4898-8bc0-470af8a26606"), new DateTime(2024, 4, 21, 1, 22, 19, 797, DateTimeKind.Utc).AddTicks(4897), "Sala de Seminários - Engenharia Civil", false, "D1" },
                    { new Guid("6e5cb509-c8a1-4e65-bc7c-e21312c479fc"), new DateTime(2024, 4, 21, 1, 22, 19, 797, DateTimeKind.Utc).AddTicks(4875), "Sala de Conferências - Ciências Sociais", false, "B1" },
                    { new Guid("6e8ebf59-8dcc-42e3-afc1-fa3ce7ee68e6"), new DateTime(2024, 4, 21, 1, 22, 19, 797, DateTimeKind.Utc).AddTicks(4902), "Sala de Reuniões - Administração de Empresas", false, "E2" },
                    { new Guid("73912fb7-50c0-4146-825e-d04a262bda0b"), new DateTime(2024, 4, 21, 1, 22, 19, 797, DateTimeKind.Utc).AddTicks(4898), "Laboratório de Informática - Desenvolvimento de Software", false, "D2" },
                    { new Guid("97967d55-1357-42ba-917d-26d13f753c0b"), new DateTime(2024, 4, 21, 1, 22, 19, 797, DateTimeKind.Utc).AddTicks(4889), "Auditório - Palestras de História da Arte", false, "C1" },
                    { new Guid("a3201571-2643-4efb-a020-23969f6b4d57"), new DateTime(2024, 4, 21, 1, 22, 19, 797, DateTimeKind.Utc).AddTicks(4868), "Sala de Aula - Física Avançada", false, "A1" },
                    { new Guid("c97635e5-8c18-429e-8831-46a5a0a3d5f4"), new DateTime(2024, 4, 21, 1, 22, 19, 797, DateTimeKind.Utc).AddTicks(4871), "Laboratório de Química Orgânica", false, "A2" },
                    { new Guid("d5d0cbd9-ed36-4a1c-9897-e2d289e7a263"), new DateTime(2024, 4, 21, 1, 22, 19, 797, DateTimeKind.Utc).AddTicks(4894), "Sala de Projeção - Filmes de Literatura", false, "C2" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "users",
                columns: new[] { "id", "created_at", "email", "is_deleted", "name", "password", "userType" },
                values: new object[] { new Guid("01c5344e-1d9b-4704-88b3-aa86ac16ccef"), new DateTime(2024, 4, 21, 1, 22, 19, 797, DateTimeKind.Utc).AddTicks(5607), "admin@gmail.com.br", false, "admin", "admin123", 2 });

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
