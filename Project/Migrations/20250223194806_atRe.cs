using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class atRe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecord_Attendances_AttendanceId",
                table: "AttendanceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecord_Students_StudentId",
                table: "AttendanceRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendanceRecord",
                table: "AttendanceRecord");

            migrationBuilder.RenameTable(
                name: "AttendanceRecord",
                newName: "AttendanceRecords");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceRecord_StudentId",
                table: "AttendanceRecords",
                newName: "IX_AttendanceRecords_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceRecord_AttendanceId",
                table: "AttendanceRecords",
                newName: "IX_AttendanceRecords_AttendanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendanceRecords",
                table: "AttendanceRecords",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63300388-5bac-4880-933b-0a78d4e40e40", "AQAAAAIAAYagAAAAEFsiS3bLQ6pFhUFqsZPEWFvQShna8cDOVKescMGSnV+JNTPpCNQPp+ip5FFYQn+8hw==", "c3c418d3-9c9d-456a-baed-89dce46dca52" });

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecords_Attendances_AttendanceId",
                table: "AttendanceRecords",
                column: "AttendanceId",
                principalTable: "Attendances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecords_Students_StudentId",
                table: "AttendanceRecords",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecords_Attendances_AttendanceId",
                table: "AttendanceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecords_Students_StudentId",
                table: "AttendanceRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendanceRecords",
                table: "AttendanceRecords");

            migrationBuilder.RenameTable(
                name: "AttendanceRecords",
                newName: "AttendanceRecord");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceRecords_StudentId",
                table: "AttendanceRecord",
                newName: "IX_AttendanceRecord_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceRecords_AttendanceId",
                table: "AttendanceRecord",
                newName: "IX_AttendanceRecord_AttendanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendanceRecord",
                table: "AttendanceRecord",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e509505-fe92-4e5f-ac5e-3f322a576323", "AQAAAAIAAYagAAAAEFJ1RAZrcMrmJqSAsiW5BJcLva6FJ3ldc1rT3oH0KupzAhP19QFUDSlQ4ZI6bvijRg==", "c31e72d6-a836-4bd5-8b08-3bf7f1e97fb3" });

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecord_Attendances_AttendanceId",
                table: "AttendanceRecord",
                column: "AttendanceId",
                principalTable: "Attendances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecord_Students_StudentId",
                table: "AttendanceRecord",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
