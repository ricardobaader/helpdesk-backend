using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Common.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("05e51fd4-e2ab-43b9-9d62-2592de23db4d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("28520bf4-6548-4491-8d43-837d3c7e7fa7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("4a36519a-4178-4898-8bc0-470af8a26606"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("6e5cb509-c8a1-4e65-bc7c-e21312c479fc"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("6e8ebf59-8dcc-42e3-afc1-fa3ce7ee68e6"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("73912fb7-50c0-4146-825e-d04a262bda0b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("97967d55-1357-42ba-917d-26d13f753c0b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("a3201571-2643-4efb-a020-23969f6b4d57"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("c97635e5-8c18-429e-8831-46a5a0a3d5f4"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("d5d0cbd9-ed36-4a1c-9897-e2d289e7a263"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("01c5344e-1d9b-4704-88b3-aa86ac16ccef"));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_updated_at",
                schema: "dbo",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_updated_at",
                schema: "dbo",
                table: "tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_updated_at",
                schema: "dbo",
                table: "ticket_images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_updated_at",
                schema: "dbo",
                table: "rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "last_updated_at",
                schema: "dbo",
                table: "users");

            migrationBuilder.DropColumn(
                name: "last_updated_at",
                schema: "dbo",
                table: "tickets");

            migrationBuilder.DropColumn(
                name: "last_updated_at",
                schema: "dbo",
                table: "ticket_images");

            migrationBuilder.DropColumn(
                name: "last_updated_at",
                schema: "dbo",
                table: "rooms");

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
        }
    }
}
