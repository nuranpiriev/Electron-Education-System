using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class lastTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonCount",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonNumber",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4eae0a20-db82-49a4-8326-ea32c00b0a6f", "AQAAAAIAAYagAAAAEP1jpPMrIOUxucxlSD8wyeqRFdhfCXGn4Bnc6FQKvXT1m1BPJp4lE3p7WB9J2Nl9iQ==", "8cb96796-2bce-4033-b349-9f5dda5715b0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonCount",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LessonNumber",
                table: "Attendances");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "598caaa7-825d-4651-8cd2-dd11fa4169e5", "AQAAAAIAAYagAAAAEFRPq6rO6QedzQvvX9Nsfg2sY7+DmEn1AHSYg3SIXw2QNKSL/1LqSIW//oVO3SR8Gg==", "6468884b-139e-4130-8241-3041fcbcedd4" });
        }
    }
}
