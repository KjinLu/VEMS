using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class editSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("5b909d16-c9e6-42bc-b46c-d766280d93b8"),
                column: "Password",
                value: "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("b584540e-49d9-4d45-bef4-f779f8e6c973"),
                column: "Password",
                value: "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0108d3be-3bce-45d7-8562-346547af9911"),
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateTime(2024, 9, 12, 22, 34, 29, 261, DateTimeKind.Local).AddTicks(8894), "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ac4048f7-4fbd-46d4-beba-acdb2953c518"),
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateTime(2024, 9, 12, 22, 34, 29, 261, DateTimeKind.Local).AddTicks(8910), "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22" });

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("493d052a-67a1-4428-981d-4d7831d3d344"),
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateTime(2024, 9, 12, 22, 34, 29, 261, DateTimeKind.Local).AddTicks(8943), "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22" });

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"),
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateTime(2024, 9, 12, 22, 34, 29, 261, DateTimeKind.Local).AddTicks(8937), "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("5b909d16-c9e6-42bc-b46c-d766280d93b8"),
                column: "Password",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("b584540e-49d9-4d45-bef4-f779f8e6c973"),
                column: "Password",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0108d3be-3bce-45d7-8562-346547af9911"),
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateTime(2024, 9, 12, 22, 29, 17, 268, DateTimeKind.Local).AddTicks(137), "1" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ac4048f7-4fbd-46d4-beba-acdb2953c518"),
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateTime(2024, 9, 12, 22, 29, 17, 268, DateTimeKind.Local).AddTicks(157), "1" });

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("493d052a-67a1-4428-981d-4d7831d3d344"),
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateTime(2024, 9, 12, 22, 29, 17, 268, DateTimeKind.Local).AddTicks(193), "1" });

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"),
                columns: new[] { "Dob", "Password" },
                values: new object[] { new DateTime(2024, 9, 12, 22, 29, 17, 268, DateTimeKind.Local).AddTicks(186), "1" });
        }
    }
}
