﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class AddColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Teacher",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Students",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0108d3be-3bce-45d7-8562-346547af9911"),
                columns: new[] { "Dob", "Image" },
                values: new object[] { new DateTime(2024, 9, 16, 2, 2, 48, 274, DateTimeKind.Local).AddTicks(3157), "" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ac4048f7-4fbd-46d4-beba-acdb2953c518"),
                columns: new[] { "Dob", "Image" },
                values: new object[] { new DateTime(2024, 9, 16, 2, 2, 48, 274, DateTimeKind.Local).AddTicks(3176), "" });

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("493d052a-67a1-4428-981d-4d7831d3d344"),
                columns: new[] { "Dob", "Image" },
                values: new object[] { new DateTime(2024, 9, 16, 2, 2, 48, 274, DateTimeKind.Local).AddTicks(3210), "" });

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"),
                columns: new[] { "Dob", "Image" },
                values: new object[] { new DateTime(2024, 9, 16, 2, 2, 48, 274, DateTimeKind.Local).AddTicks(3205), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0108d3be-3bce-45d7-8562-346547af9911"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 22, 34, 29, 261, DateTimeKind.Local).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ac4048f7-4fbd-46d4-beba-acdb2953c518"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 22, 34, 29, 261, DateTimeKind.Local).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("493d052a-67a1-4428-981d-4d7831d3d344"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 22, 34, 29, 261, DateTimeKind.Local).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 22, 34, 29, 261, DateTimeKind.Local).AddTicks(8937));
        }
    }
}
