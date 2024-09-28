using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addAdminData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Periods");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "Password", "RefreshToken", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("5b909d16-c9e6-42bc-b46c-d766280d93b8"), "admin2@email.com", "1", "", new Guid("04c92fd7-51b1-4852-8b8a-cacbe1511670"), "admin2" },
                    { new Guid("b584540e-49d9-4d45-bef4-f779f8e6c973"), "admin1@email.com", "1", "", new Guid("04c92fd7-51b1-4852-8b8a-cacbe1511670"), "admin1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("5b909d16-c9e6-42bc-b46c-d766280d93b8"));

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("b584540e-49d9-4d45-bef4-f779f8e6c973"));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "Periods",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "Id",
                keyValue: new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b"),
                column: "EndTime",
                value: new TimeSpan(0, 11, 30, 0, 0));

            migrationBuilder.UpdateData(
                table: "Periods",
                keyColumn: "Id",
                keyValue: new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31"),
                column: "EndTime",
                value: new TimeSpan(0, 17, 30, 0, 0));
        }
    }
}
