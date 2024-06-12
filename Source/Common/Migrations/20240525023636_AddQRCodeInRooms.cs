using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Common.Migrations
{
    /// <inheritdoc />
    public partial class AddQRCodeInRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("01e790b9-cf98-434f-938b-8cb35fe1cd2f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("0c4dc28c-6da2-4f9a-9988-4f2f91184411"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("3c98991a-13f6-4915-bb7d-0ea7fc30628d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("6bde5fa1-b7c3-4db0-8c4a-145f50e2853f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("749d0d36-265d-4a58-bb1d-a26a5dc33619"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("7cf046c2-40b2-4b63-b097-eb88f08fbb88"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("916ab47c-8152-4da8-9f07-aa86f1deebe1"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("c0271f70-2609-4d2d-b9db-2d5542359048"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("e3b4a787-d2c6-41a4-8495-ca73efb58b8f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("e95114c2-fa39-445f-9b4b-6daf3bdde121"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("d05c7c01-8786-46c1-a03b-87808caa1e54"));

            migrationBuilder.AddColumn<byte[]>(
                name: "qr_code",
                schema: "dbo",
                table: "rooms",
                type: "bytea",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "qr_code",
                schema: "dbo",
                table: "rooms");

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
        }
    }
}
