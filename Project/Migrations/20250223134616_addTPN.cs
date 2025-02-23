using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class addTPN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0c9247a-78b0-424b-ad88-9ef827a715cb", "AQAAAAIAAYagAAAAEIN7q87FdJX6ii9pMHM2AfIkPe0hD2QEeEOPYrFXNK0wdSurH2M799xNbVUpvpknPQ==", "0ab2371c-b0ce-4330-8062-badcb2185cb2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Teachers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55537397-0fb6-4993-ac87-f245b489ea41", "AQAAAAIAAYagAAAAEAfzUN/89sAR1EdmPXT/zG77pvc3XbF9U+VCzuZ8pQagSYMIO2bEskQardA5/bHtNg==", "4733c4b3-ef07-4808-892a-896fcbb9229f" });
        }
    }
}
