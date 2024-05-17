using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Common.Migrations
{
    /// <inheritdoc />
    public partial class CreateChatMessageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("27290885-d7c6-400b-a9c6-980778d6834d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("328dc2e2-a7e7-46cd-92f5-8c0e187def3a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("5ef6fdd4-4c85-4c90-8771-0f2857493c8b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("78ec12e6-91f2-47f7-bd33-3c47b66651d3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("9edb91b9-cbf8-40f7-b993-06deb1d51f01"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("a81ebf27-bdfc-450d-ae85-5130dee66946"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("ad64b43e-3db1-4e7e-a409-b3f30d34bdee"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("c1f49b0c-7859-4262-a5ae-03b9bc7fc5ca"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("d022720b-d0bb-433d-bc63-945939ee2bcc"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("e815dec8-5406-40da-94b6-99c98d8d21f2"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a3f7e240-b775-49f1-a697-1bd206726af4"));

            migrationBuilder.CreateTable(
                name: "chat_messages",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ticket_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "rooms",
                columns: new[] { "id", "created_at", "description", "is_deleted", "last_updated_at", "name" },
                values: new object[,]
                {
                    { new Guid("07c14ebd-e874-44cd-93a8-765ef3ab9d79"), new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5975), "Biblioteca - Estudos de Filosofia", false, new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5975), "E1" },
                    { new Guid("08e14d3f-b93e-4889-917f-765c0f158a50"), new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5970), "Sala de Seminários - Engenharia Civil", false, new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5970), "D1" },
                    { new Guid("0ee5db7a-a16d-4de9-a5ab-fe069dd93ad0"), new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5973), "Laboratório de Informática - Desenvolvimento de Software", false, new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5973), "D2" },
                    { new Guid("1f70629a-394f-4fcb-abce-17ad18a02f26"), new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5968), "Sala de Projeção - Filmes de Literatura", false, new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5968), "C2" },
                    { new Guid("3b7baa4f-25aa-487a-89e7-4528de7d466f"), new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5965), "Auditório - Palestras de História da Arte", false, new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5965), "C1" },
                    { new Guid("450427b2-aaf0-4a69-ba15-b53aaf2a23fb"), new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5977), "Sala de Reuniões - Administração de Empresas", false, new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5977), "E2" },
                    { new Guid("924ed68e-e3ff-4123-a6c7-5b6780a716ed"), new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5963), "Sala de Estudo em Grupo - Matemática", false, new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5963), "B2" },
                    { new Guid("c302660b-574d-496b-875c-06918939dad3"), new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5951), "Sala de Conferências - Ciências Sociais", false, new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5951), "B1" },
                    { new Guid("d7ccbde3-942c-4c60-a6a2-59de1918eb60"), new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5944), "Sala de Aula - Física Avançada", false, new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5944), "A1" },
                    { new Guid("e46d5bad-cce5-42f0-ac5e-24e4e8e8fb82"), new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5948), "Laboratório de Química Orgânica", false, new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(5948), "A2" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "users",
                columns: new[] { "id", "created_at", "email", "is_deleted", "last_updated_at", "name", "password", "userType" },
                values: new object[] { new Guid("a4bd732b-465c-4525-9bea-4909213d32ff"), new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(6602), "admin@gmail.com.br", false, new DateTime(2024, 4, 28, 0, 48, 31, 688, DateTimeKind.Utc).AddTicks(6602), "admin", "admin123", 2 });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chat_messages",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("07c14ebd-e874-44cd-93a8-765ef3ab9d79"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("08e14d3f-b93e-4889-917f-765c0f158a50"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("0ee5db7a-a16d-4de9-a5ab-fe069dd93ad0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("1f70629a-394f-4fcb-abce-17ad18a02f26"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("3b7baa4f-25aa-487a-89e7-4528de7d466f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("450427b2-aaf0-4a69-ba15-b53aaf2a23fb"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("924ed68e-e3ff-4123-a6c7-5b6780a716ed"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("c302660b-574d-496b-875c-06918939dad3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("d7ccbde3-942c-4c60-a6a2-59de1918eb60"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("e46d5bad-cce5-42f0-ac5e-24e4e8e8fb82"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a4bd732b-465c-4525-9bea-4909213d32ff"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "rooms",
                columns: new[] { "id", "created_at", "description", "is_deleted", "last_updated_at", "name" },
                values: new object[,]
                {
                    { new Guid("27290885-d7c6-400b-a9c6-980778d6834d"), new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7229), "Sala de Conferências - Ciências Sociais", false, new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7229), "B1" },
                    { new Guid("328dc2e2-a7e7-46cd-92f5-8c0e187def3a"), new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7247), "Sala de Projeção - Filmes de Literatura", false, new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7247), "C2" },
                    { new Guid("5ef6fdd4-4c85-4c90-8771-0f2857493c8b"), new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7252), "Laboratório de Informática - Desenvolvimento de Software", false, new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7252), "D2" },
                    { new Guid("78ec12e6-91f2-47f7-bd33-3c47b66651d3"), new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7258), "Sala de Reuniões - Administração de Empresas", false, new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7258), "E2" },
                    { new Guid("9edb91b9-cbf8-40f7-b993-06deb1d51f01"), new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7250), "Sala de Seminários - Engenharia Civil", false, new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7250), "D1" },
                    { new Guid("a81ebf27-bdfc-450d-ae85-5130dee66946"), new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7255), "Biblioteca - Estudos de Filosofia", false, new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7255), "E1" },
                    { new Guid("ad64b43e-3db1-4e7e-a409-b3f30d34bdee"), new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7235), "Auditório - Palestras de História da Arte", false, new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7235), "C1" },
                    { new Guid("c1f49b0c-7859-4262-a5ae-03b9bc7fc5ca"), new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7218), "Sala de Aula - Física Avançada", false, new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7218), "A1" },
                    { new Guid("d022720b-d0bb-433d-bc63-945939ee2bcc"), new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7233), "Sala de Estudo em Grupo - Matemática", false, new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7233), "B2" },
                    { new Guid("e815dec8-5406-40da-94b6-99c98d8d21f2"), new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7225), "Laboratório de Química Orgânica", false, new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(7225), "A2" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "users",
                columns: new[] { "id", "created_at", "email", "is_deleted", "last_updated_at", "name", "password", "userType" },
                values: new object[] { new Guid("a3f7e240-b775-49f1-a697-1bd206726af4"), new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(8249), "admin@gmail.com.br", false, new DateTime(2024, 4, 26, 19, 37, 27, 337, DateTimeKind.Utc).AddTicks(8249), "admin", "admin123", 2 });
        }
    }
}
