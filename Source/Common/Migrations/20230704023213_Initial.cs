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
                    room = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_tickets_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "rooms",
                columns: new[] { "id", "is_deleted", "name" },
                values: new object[,]
                {
                    { new Guid("39911d57-a14d-4a63-981e-b9e9b841adfa"), false, "E2" },
                    { new Guid("419d345f-91f3-43b9-8de9-46b12a642fb9"), false, "B2" },
                    { new Guid("444e105d-2891-4753-8927-e24eed8a0a30"), false, "C1" },
                    { new Guid("53f23e7c-52d5-4a81-ba69-43401fa4d55b"), false, "D2" },
                    { new Guid("59fd13c4-db67-441f-8f07-e91c53288c56"), false, "A2" },
                    { new Guid("93941f7f-7f17-456d-85b1-76ddf4ebe745"), false, "E1" },
                    { new Guid("b6838ce3-9e09-4b88-a379-587647b9adfb"), false, "A1" },
                    { new Guid("c21d566a-3785-493c-bcb8-9c24265885d6"), false, "B1" },
                    { new Guid("d5b5b097-251d-420b-88be-194180a9d80b"), false, "C2" },
                    { new Guid("dd61a4df-2c49-44bd-a01c-9dbd50f77c02"), false, "D1" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "users",
                columns: new[] { "id", "email", "is_deleted", "name", "password", "userType" },
                values: new object[] { new Guid("e8a672fd-6a60-47b1-8768-c9acb4d6abf5"), "admin@gmail.com.br", false, "admin", "admin123", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_rooms_id_is_deleted",
                schema: "dbo",
                table: "rooms",
                columns: new[] { "id", "is_deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_id_is_deleted",
                schema: "dbo",
                table: "tickets",
                columns: new[] { "id", "is_deleted" },
                unique: true);

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
                name: "rooms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tickets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "users",
                schema: "dbo");
        }
    }
}
