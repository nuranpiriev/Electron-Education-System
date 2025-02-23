using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "36f92c7f-a6e4-48b1-96e9-f3b284c6a5b7", "90f58f47-7bd6-4005-b6ee-e40f632a8fc3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "90f58f47-7bd6-4005--b6ee-e40f632a8fc3", 0, "9c68f1e2-119c-4884-9864-67c8b9730e23", null, false, false, null, null, "Nuran", "AQAAAAIAAYagAAAAEHbFWvXw/8w53uzSDy16mOI78UGhafKVB/Pvy5g+A9RnuOQ+VfTn6XVGTYXXWd9b7g==", null, false, "a928eef1-f42a-415c-8d37-daa1a7a41d4b", false, "nuran" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "36f92c7f-a6e4-48b1-96e9-f3b284c6a5b7", "90f58f47-7bd6-4005--b6ee-e40f632a8fc3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "36f92c7f-a6e4-48b1-96e9-f3b284c6a5b7", "90f58f47-7bd6-4005--b6ee-e40f632a8fc3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005--b6ee-e40f632a8fc3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "90f58f47-7bd6-4005-b6ee-e40f632a8fc3", 0, "d40cb179-7915-49c1-b057-ca43797b9f42", null, false, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEPU5yGkHW4cGJZd/u7cF+zpRIrUtnBrp793fdXnfoPYpyM0lnwzw4T+T72OU2gMDyw==", null, false, "8d961fe3-ffd9-4efb-b2f1-40e46872ab58", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "36f92c7f-a6e4-48b1-96e9-f3b284c6a5b7", "90f58f47-7bd6-4005-b6ee-e40f632a8fc3" });
        }
    }
}
