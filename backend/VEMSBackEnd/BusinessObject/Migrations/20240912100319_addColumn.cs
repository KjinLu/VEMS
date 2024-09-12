using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("2b2a2c55-dfb2-4c80-9ee3-9ce3fc095853"));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "Periods",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Periods",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "Id",
                keyValue: new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 7, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "Id",
                keyValue: new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 14, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("0811126b-4fb3-4e29-b0f6-94b00bf0b98b"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 8, 45, 0, 0), new TimeSpan(0, 8, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("4ebda95f-f406-43d2-a88b-be2b1ddbe1b5"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 45, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("79e57c6a-fae8-42b4-a460-b48447e3e076"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 16, 35, 0, 0), new TimeSpan(0, 15, 50, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("9495ef71-051d-4e1b-9de3-31fa6d238252"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 13, 40, 0, 0), new TimeSpan(0, 14, 55, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("b2e5cc3b-f6f2-427e-9d9e-1f44ee8d2e80"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 9, 50, 0, 0), new TimeSpan(0, 9, 5, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("c5b67725-545f-4edd-8198-05bedcb5b00f"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 14, 45, 0, 0), new TimeSpan(0, 14, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("e1e53de7-7170-46b4-8230-2790c42a7cac"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 16, 45, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("e8b4217f-5a6c-4428-9901-99e62ce1f562"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 10, 40, 0, 0), new TimeSpan(0, 9, 55, 0, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Periods");

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("0811126b-4fb3-4e29-b0f6-94b00bf0b98b"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 8, 35, 0, 0), new TimeSpan(0, 7, 50, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("4ebda95f-f406-43d2-a88b-be2b1ddbe1b5"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 11, 20, 0, 0), new TimeSpan(0, 10, 35, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("79e57c6a-fae8-42b4-a460-b48447e3e076"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 15, 40, 0, 0), new TimeSpan(0, 14, 55, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("9495ef71-051d-4e1b-9de3-31fa6d238252"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 14, 35, 0, 0), new TimeSpan(0, 13, 50, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("b2e5cc3b-f6f2-427e-9d9e-1f44ee8d2e80"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 9, 40, 0, 0), new TimeSpan(0, 8, 55, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("c5b67725-545f-4edd-8198-05bedcb5b00f"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 13, 45, 0, 0), new TimeSpan(0, 13, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("e1e53de7-7170-46b4-8230-2790c42a7cac"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 16, 30, 0, 0), new TimeSpan(0, 15, 45, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: new Guid("e8b4217f-5a6c-4428-9901-99e62ce1f562"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 45, 0, 0) });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "EndTime", "SlotIndex", "StartTime" },
                values: new object[] { new Guid("2b2a2c55-dfb2-4c80-9ee3-9ce3fc095853"), new TimeSpan(0, 17, 20, 0, 0), 10, new TimeSpan(0, 16, 35, 0, 0) });
        }
    }
}
