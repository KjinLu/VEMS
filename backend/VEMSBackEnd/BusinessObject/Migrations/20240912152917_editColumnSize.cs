using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class editColumnSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Teacher",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Students",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Admins",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldMaxLength: 80);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0108d3be-3bce-45d7-8562-346547af9911"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 22, 29, 17, 268, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ac4048f7-4fbd-46d4-beba-acdb2953c518"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 22, 29, 17, 268, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("493d052a-67a1-4428-981d-4d7831d3d344"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 22, 29, 17, 268, DateTimeKind.Local).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 22, 29, 17, 268, DateTimeKind.Local).AddTicks(186));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Teacher",
                type: "varchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Students",
                type: "varchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Admins",
                type: "varchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0108d3be-3bce-45d7-8562-346547af9911"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 20, 52, 50, 92, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ac4048f7-4fbd-46d4-beba-acdb2953c518"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 20, 52, 50, 92, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("493d052a-67a1-4428-981d-4d7831d3d344"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 20, 52, 50, 92, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 20, 52, 50, 92, DateTimeKind.Local).AddTicks(3061));
        }
    }
}
