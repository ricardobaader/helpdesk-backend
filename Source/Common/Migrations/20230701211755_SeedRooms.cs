using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Common.Migrations
{
    /// <inheritdoc />
    public partial class SeedRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "rooms",
                columns: new[] { "id", "is_deleted", "name" },
                values: new object[,]
                {
                    { new Guid("17a0910f-3b6d-42cf-b7ed-d6b243d43eb2"), false, "D1" },
                    { new Guid("1803fe74-ec77-4636-ba82-62218d67ec6d"), false, "A2" },
                    { new Guid("22427b3c-e652-4d93-9b9a-76369e56a5f6"), false, "D2" },
                    { new Guid("2b773451-1765-494d-be0a-860939938b57"), false, "C2" },
                    { new Guid("76c18967-ff4b-4af1-9b87-83bc99076579"), false, "E1" },
                    { new Guid("7a866c5b-ccf9-4dab-9355-1d6a22c092c5"), false, "C1" },
                    { new Guid("841e259d-cd5d-4997-8812-7e5f410fd4fa"), false, "A1" },
                    { new Guid("87d43a76-e5e3-45f9-8c5a-84ddc9d22352"), false, "E2" },
                    { new Guid("8bfc63ea-deec-40bf-a54c-9343b29ca851"), false, "B1" },
                    { new Guid("b1285d62-db5d-4a0e-894b-4aeee67480af"), false, "B2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("17a0910f-3b6d-42cf-b7ed-d6b243d43eb2"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("1803fe74-ec77-4636-ba82-62218d67ec6d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("22427b3c-e652-4d93-9b9a-76369e56a5f6"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("2b773451-1765-494d-be0a-860939938b57"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("76c18967-ff4b-4af1-9b87-83bc99076579"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("7a866c5b-ccf9-4dab-9355-1d6a22c092c5"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("841e259d-cd5d-4997-8812-7e5f410fd4fa"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("87d43a76-e5e3-45f9-8c5a-84ddc9d22352"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("8bfc63ea-deec-40bf-a54c-9343b29ca851"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "rooms",
                keyColumn: "id",
                keyValue: new Guid("b1285d62-db5d-4a0e-894b-4aeee67480af"));
        }
    }
}
