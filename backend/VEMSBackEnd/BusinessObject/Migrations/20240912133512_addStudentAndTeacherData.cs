using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addStudentAndTeacherData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CitizenID",
                table: "Teacher",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CitizenID", "ClassroomId", "Dob", "Email", "FullName", "HomeTown", "ParentPhone", "Password", "Phone", "PublicStudentID", "RefreshToken", "RoleId", "StudentTypeId", "Username" },
                values: new object[,]
                {
                    { new Guid("0108d3be-3bce-45d7-8562-346547af9911"), "", "1", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), new DateTime(2024, 9, 12, 20, 35, 11, 846, DateTimeKind.Local).AddTicks(9336), "student1@email.com", "Stu 1", "", "", "1", "", "1", "", new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), "student1" },
                    { new Guid("ac4048f7-4fbd-46d4-beba-acdb2953c518"), "", "1", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), new DateTime(2024, 9, 12, 20, 35, 11, 846, DateTimeKind.Local).AddTicks(9352), "student2@email.com", "", "", "", "1", "", "1", "", new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), "student2" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Address", "CitizenID", "Dob", "Email", "FullName", "Password", "Phone", "PublicTeacherID", "RefreshToken", "RoleId", "TeacherTypeId", "Username" },
                values: new object[,]
                {
                    { new Guid("493d052a-67a1-4428-981d-4d7831d3d344"), "", "1", new DateTime(2024, 9, 12, 20, 35, 11, 846, DateTimeKind.Local).AddTicks(9415), "teacher2@email.com", "Tea 1", "1", "", "1", "", new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"), new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"), "teacher2" },
                    { new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"), "", "1", new DateTime(2024, 9, 12, 20, 35, 11, 846, DateTimeKind.Local).AddTicks(9410), "teacher1@email.com", "Tea 1", "1", "", "1", "", new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"), new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"), "teacher1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0108d3be-3bce-45d7-8562-346547af9911"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ac4048f7-4fbd-46d4-beba-acdb2953c518"));

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("493d052a-67a1-4428-981d-4d7831d3d344"));

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"));

            migrationBuilder.DropColumn(
                name: "CitizenID",
                table: "Teacher");
        }
    }
}
