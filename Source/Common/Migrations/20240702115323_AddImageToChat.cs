using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Common.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("341d68bf-ebfb-4e3c-8749-e716827f48bd"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("5551bdbf-9c2e-495c-97c6-c2a68ebf3b1a"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("5d1164ca-3b93-4b4c-9281-2e8868fbe151"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("9d88d8e3-f41b-4dbe-a4e3-58a67bff9771"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("d042c31a-5454-4bef-890c-aa06db7333cc"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("dee09be6-a2f8-4ac1-a68c-15f0e5b1ede9"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("e1f047ea-a10e-4622-8927-752ab8f4874d"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("e270a034-caea-492c-a3f5-d01c74e8ca21"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("e42bae84-0ef7-4888-8984-5761fd5a2076"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("ea78e078-1e9f-433c-9977-567ce3c4c240"));

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "chat_messages",
                type: "bytea",
                nullable: true);

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "id", "created_at", "description", "is_deleted", "last_updated_at", "name", "qr_code" },
                values: new object[,]
                {
                    { new Guid("03aa902d-b38c-439d-8387-2ab0b8b2a75e"), new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6510), "Laboratório de Informática - Desenvolvimento de Software", false, new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6510), "D2", null },
                    { new Guid("63cbd89b-178a-4f3b-942e-22892adba81c"), new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6507), "Sala de Seminários - Engenharia Civil", false, new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6507), "D1", null },
                    { new Guid("77fc5044-b6dd-4f56-9516-e70c635276e3"), new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6514), "Biblioteca - Estudos de Filosofia", false, new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6514), "E1", null },
                    { new Guid("80b8739f-d01c-4260-b909-1685ebdb3cea"), new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6470), "Laboratório de Química Orgânica", false, new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6470), "A2", null },
                    { new Guid("a7ff053b-8281-402e-bb23-cf7e8ca0a5de"), new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6479), "Sala de Estudo em Grupo - Matemática", false, new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6479), "B2", null },
                    { new Guid("bfbacc9c-a23a-48eb-a822-8406b1b231e2"), new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6457), "Sala de Aula - Física Avançada", false, new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6457), "A1", null },
                    { new Guid("ce52e35f-a4f0-4c02-b295-6edfd10e8f6d"), new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6496), "Auditório - Palestras de História da Arte", false, new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6496), "C1", null },
                    { new Guid("d65e2029-c280-4971-909c-de8e76db3e82"), new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6503), "Sala de Projeção - Filmes de Literatura", false, new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6503), "C2", null },
                    { new Guid("e7668f60-9994-42a4-ac82-d686a504674a"), new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6519), "Sala de Reuniões - Administração de Empresas", false, new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6519), "E2", null },
                    { new Guid("eb2404ee-b64e-49db-84e4-31fa221bc94a"), new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6475), "Sala de Conferências - Ciências Sociais", false, new DateTime(2024, 7, 2, 11, 53, 23, 363, DateTimeKind.Utc).AddTicks(6475), "B1", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("03aa902d-b38c-439d-8387-2ab0b8b2a75e"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("63cbd89b-178a-4f3b-942e-22892adba81c"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("77fc5044-b6dd-4f56-9516-e70c635276e3"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("80b8739f-d01c-4260-b909-1685ebdb3cea"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("a7ff053b-8281-402e-bb23-cf7e8ca0a5de"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("bfbacc9c-a23a-48eb-a822-8406b1b231e2"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("ce52e35f-a4f0-4c02-b295-6edfd10e8f6d"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("d65e2029-c280-4971-909c-de8e76db3e82"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("e7668f60-9994-42a4-ac82-d686a504674a"));

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("eb2404ee-b64e-49db-84e4-31fa221bc94a"));

            migrationBuilder.DropColumn(
                name: "image",
                table: "chat_messages");

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
        }
    }
}
