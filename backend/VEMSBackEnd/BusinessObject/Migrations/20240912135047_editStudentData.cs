using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class editStudentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0108d3be-3bce-45d7-8562-346547af9911"),
                columns: new[] { "Dob", "RoleId" },
                values: new object[] { new DateTime(2024, 9, 12, 20, 50, 46, 585, DateTimeKind.Local).AddTicks(9306), new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ac4048f7-4fbd-46d4-beba-acdb2953c518"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 20, 50, 46, 585, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("493d052a-67a1-4428-981d-4d7831d3d344"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 20, 50, 46, 585, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 20, 50, 46, 585, DateTimeKind.Local).AddTicks(9347));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0108d3be-3bce-45d7-8562-346547af9911"),
                columns: new[] { "Dob", "RoleId" },
                values: new object[] { new DateTime(2024, 9, 12, 20, 35, 11, 846, DateTimeKind.Local).AddTicks(9336), new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53") });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ac4048f7-4fbd-46d4-beba-acdb2953c518"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 20, 35, 11, 846, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("493d052a-67a1-4428-981d-4d7831d3d344"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 20, 35, 11, 846, DateTimeKind.Local).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"),
                column: "Dob",
                value: new DateTime(2024, 9, 12, 20, 35, 11, 846, DateTimeKind.Local).AddTicks(9410));
        }
    }
}
