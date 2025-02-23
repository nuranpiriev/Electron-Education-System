using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class nextTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3607b0c-7129-427b-947a-f98fcc8ec7b8", "AQAAAAIAAYagAAAAEHm4SiS1QOtTf4fZRedSQqN+4BfHpE0U/cx7xex0hhFsM9rmnQIV14PXLzBZSkgIfA==", "780c7b29-60f3-4931-bd37-31d829532bf2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4eae0a20-db82-49a4-8326-ea32c00b0a6f", "AQAAAAIAAYagAAAAEP1jpPMrIOUxucxlSD8wyeqRFdhfCXGn4Bnc6FQKvXT1m1BPJp4lE3p7WB9J2Nl9iQ==", "8cb96796-2bce-4033-b349-9f5dda5715b0" });
        }
    }
}
