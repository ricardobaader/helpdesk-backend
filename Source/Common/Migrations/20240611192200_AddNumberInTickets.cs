using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Common.Migrations
{
    /// <inheritdoc />
    public partial class AddNumberInTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("07f1493c-e98b-4f4f-a2b5-a6c68fb14e07"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("0ea275ed-d6cd-4726-92ab-78248c01fa43"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("6a0d0881-06ef-49de-909e-572818b21c38"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("6eb98a68-9ad7-42df-ae8a-bb8594aa69fc"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("85db8813-a85f-4649-af21-635e434794bb"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("9dc044e0-c191-4a2c-a2b7-57eb3f6ca23f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("9e9c5f20-7018-4c72-832c-961691f6f367"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("b8f60cef-2bed-49db-a91c-158dad34fad7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("eb025dab-52fa-4e60-939d-21408afc172c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("fe22f544-2160-4e9e-9a80-68c2a8604877"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("d1611669-2928-480a-bd97-2bec86f7773d"));

            migrationBuilder.AddColumn<int>(
                name: "number",
                schema: "dbo",
                table: "tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "rooms",
                columns: new[] { "id", "created_at", "description", "is_deleted", "last_updated_at", "name", "qr_code" },
                values: new object[,]
                {
                    { new Guid("131b3d6d-127c-4ae8-8bb7-8659d376c3ed"), new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4413), "Laboratório de Informática - Desenvolvimento de Software", false, new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4413), "D2", null },
                    { new Guid("9b8c4e26-ab56-4d2c-b6b6-11f9b7e65a69"), new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4378), "Sala de Aula - Física Avançada", false, new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4378), "A1", null },
                    { new Guid("bd9e1f5c-ad57-4f1e-abb9-0b788599c26d"), new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4414), "Biblioteca - Estudos de Filosofia", false, new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4414), "E1", null },
                    { new Guid("c125a836-4b58-4f38-926a-fbcd85952fde"), new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4416), "Sala de Reuniões - Administração de Empresas", false, new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4416), "E2", null },
                    { new Guid("c3dc1db7-12fa-402c-bb1f-338393d3a05f"), new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4410), "Sala de Seminários - Engenharia Civil", false, new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4410), "D1", null },
                    { new Guid("c8f8dacb-8a69-4f55-9935-de4f109bccda"), new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4396), "Auditório - Palestras de História da Arte", false, new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4396), "C1", null },
                    { new Guid("c99f75f3-4a5f-4050-8564-3a81ce3aba16"), new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4389), "Laboratório de Química Orgânica", false, new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4389), "A2", null },
                    { new Guid("cc21211a-32a3-4e8a-9305-8c69e040166a"), new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4394), "Sala de Estudo em Grupo - Matemática", false, new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4394), "B2", null },
                    { new Guid("d5bea611-86ba-46da-b058-91f54607150e"), new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4391), "Sala de Conferências - Ciências Sociais", false, new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4391), "B1", null },
                    { new Guid("f82a7e52-e264-417c-9302-ab76b54b3142"), new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4399), "Sala de Projeção - Filmes de Literatura", false, new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(4399), "C2", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "users",
                columns: new[] { "id", "created_at", "email", "is_deleted", "last_updated_at", "name", "password", "userType" },
                values: new object[] { new Guid("2f495bc3-ed01-4fac-9cd7-750b7b9b9844"), new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(5204), "admin@gmail.com.br", false, new DateTime(2024, 6, 11, 19, 22, 0, 754, DateTimeKind.Utc).AddTicks(5204), "admin", "admin123", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("131b3d6d-127c-4ae8-8bb7-8659d376c3ed"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("9b8c4e26-ab56-4d2c-b6b6-11f9b7e65a69"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("bd9e1f5c-ad57-4f1e-abb9-0b788599c26d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("c125a836-4b58-4f38-926a-fbcd85952fde"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("c3dc1db7-12fa-402c-bb1f-338393d3a05f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("c8f8dacb-8a69-4f55-9935-de4f109bccda"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("c99f75f3-4a5f-4050-8564-3a81ce3aba16"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("cc21211a-32a3-4e8a-9305-8c69e040166a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("d5bea611-86ba-46da-b058-91f54607150e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("f82a7e52-e264-417c-9302-ab76b54b3142"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("2f495bc3-ed01-4fac-9cd7-750b7b9b9844"));

            migrationBuilder.DropColumn(
                name: "number",
                schema: "dbo",
                table: "tickets");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "rooms",
                columns: new[] { "id", "created_at", "description", "is_deleted", "last_updated_at", "name", "qr_code" },
                values: new object[,]
                {
                    { new Guid("07f1493c-e98b-4f4f-a2b5-a6c68fb14e07"), new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8394), "Auditório - Palestras de História da Arte", false, new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8394), "C1", null },
                    { new Guid("0ea275ed-d6cd-4726-92ab-78248c01fa43"), new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8406), "Sala de Reuniões - Administração de Empresas", false, new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8406), "E2", null },
                    { new Guid("6a0d0881-06ef-49de-909e-572818b21c38"), new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8398), "Sala de Seminários - Engenharia Civil", false, new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8398), "D1", null },
                    { new Guid("6eb98a68-9ad7-42df-ae8a-bb8594aa69fc"), new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8391), "Sala de Estudo em Grupo - Matemática", false, new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8391), "B2", null },
                    { new Guid("85db8813-a85f-4649-af21-635e434794bb"), new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8388), "Sala de Conferências - Ciências Sociais", false, new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8388), "B1", null },
                    { new Guid("9dc044e0-c191-4a2c-a2b7-57eb3f6ca23f"), new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8369), "Sala de Aula - Física Avançada", false, new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8369), "A1", null },
                    { new Guid("9e9c5f20-7018-4c72-832c-961691f6f367"), new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8396), "Sala de Projeção - Filmes de Literatura", false, new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8396), "C2", null },
                    { new Guid("b8f60cef-2bed-49db-a91c-158dad34fad7"), new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8403), "Biblioteca - Estudos de Filosofia", false, new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8403), "E1", null },
                    { new Guid("eb025dab-52fa-4e60-939d-21408afc172c"), new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8401), "Laboratório de Informática - Desenvolvimento de Software", false, new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8401), "D2", null },
                    { new Guid("fe22f544-2160-4e9e-9a80-68c2a8604877"), new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8374), "Laboratório de Química Orgânica", false, new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(8374), "A2", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "users",
                columns: new[] { "id", "created_at", "email", "is_deleted", "last_updated_at", "name", "password", "userType" },
                values: new object[] { new Guid("d1611669-2928-480a-bd97-2bec86f7773d"), new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(9076), "admin@gmail.com.br", false, new DateTime(2024, 5, 25, 2, 36, 36, 412, DateTimeKind.Utc).AddTicks(9076), "admin", "admin123", 2 });
        }
    }
}
