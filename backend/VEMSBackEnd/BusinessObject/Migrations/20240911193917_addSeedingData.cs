using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Slots",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Slots",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "EndTime", "SlotIndex", "StartTime" },
                values: new object[,]
                {
                    { new Guid("0811126b-4fb3-4e29-b0f6-94b00bf0b98b"), new TimeSpan(0, 8, 35, 0, 0), 2, new TimeSpan(0, 7, 50, 0, 0) },
                    { new Guid("2b2a2c55-dfb2-4c80-9ee3-9ce3fc095853"), new TimeSpan(0, 17, 20, 0, 0), 10, new TimeSpan(0, 16, 35, 0, 0) },
                    { new Guid("4ebda95f-f406-43d2-a88b-be2b1ddbe1b5"), new TimeSpan(0, 11, 20, 0, 0), 5, new TimeSpan(0, 10, 35, 0, 0) },
                    { new Guid("79e57c6a-fae8-42b4-a460-b48447e3e076"), new TimeSpan(0, 15, 40, 0, 0), 8, new TimeSpan(0, 14, 55, 0, 0) },
                    { new Guid("9495ef71-051d-4e1b-9de3-31fa6d238252"), new TimeSpan(0, 14, 35, 0, 0), 7, new TimeSpan(0, 13, 50, 0, 0) },
                    { new Guid("b2e5cc3b-f6f2-427e-9d9e-1f44ee8d2e80"), new TimeSpan(0, 9, 40, 0, 0), 3, new TimeSpan(0, 8, 55, 0, 0) },
                    { new Guid("c5b67725-545f-4edd-8198-05bedcb5b00f"), new TimeSpan(0, 13, 45, 0, 0), 6, new TimeSpan(0, 13, 0, 0, 0) },
                    { new Guid("db1085ce-9ba3-4894-a8a0-d417bc6b0774"), new TimeSpan(0, 7, 45, 0, 0), 1, new TimeSpan(0, 7, 0, 0, 0) },
                    { new Guid("e1e53de7-7170-46b4-8230-2790c42a7cac"), new TimeSpan(0, 16, 30, 0, 0), 9, new TimeSpan(0, 15, 45, 0, 0) },
                    { new Guid("e8b4217f-5a6c-4428-9901-99e62ce1f562"), new TimeSpan(0, 10, 30, 0, 0), 4, new TimeSpan(0, 9, 45, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("0811126b-4fb3-4e29-b0f6-94b00bf0b98b"));

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("2b2a2c55-dfb2-4c80-9ee3-9ce3fc095853"));

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("4ebda95f-f406-43d2-a88b-be2b1ddbe1b5"));

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("79e57c6a-fae8-42b4-a460-b48447e3e076"));

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("9495ef71-051d-4e1b-9de3-31fa6d238252"));

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("b2e5cc3b-f6f2-427e-9d9e-1f44ee8d2e80"));

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("c5b67725-545f-4edd-8198-05bedcb5b00f"));

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("db1085ce-9ba3-4894-a8a0-d417bc6b0774"));

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("e1e53de7-7170-46b4-8230-2790c42a7cac"));

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("e8b4217f-5a6c-4428-9901-99e62ce1f562"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Slots",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Slots",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }
    }
}
