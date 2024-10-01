using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addExtraActivityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("30186686-58a8-4ec8-829c-d3bb817a41ae"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("3ac83462-064f-49b0-9391-d294ba6568a0"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("3ad2c238-d8ac-4f76-902a-cc56cd22a4b9"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("3e2ba796-3f68-4217-9dc6-065f9f249ea7"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("50940423-c421-4f8c-a527-76f213ce631d"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("5eee0482-91cf-4959-897b-804603d7b0cb"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("8f84fbe7-d1bd-4c15-b973-39d6653718dd"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("99514a00-8851-4c53-9472-8eebc5f59787"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("b04ccefd-1057-4789-a72b-e688212a8d45"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eb66491b-fe37-4d13-bf9b-722fd5404c96"));

            migrationBuilder.CreateTable(
                name: "ExtraActivitiesAttendance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraActivitiesAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraActivitiesAttendance_Attendances_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "Attendances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtraActivitiesAttendance_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtraActivitiesAttendance_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CitizenID", "ClassroomId", "Dob", "Email", "FullName", "HomeTown", "Image", "ParentPhone", "Password", "Phone", "PublicStudentID", "RefreshToken", "RoleId", "StudentTypeId", "UnionJoinDate", "Username" },
                values: new object[,]
                {
                    { new Guid("18a1bf8b-d2c0-470a-82d2-0de480288f63"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "pham.d@example.com", "Phạm Thị D", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/5_ek2pks.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU104", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU104" },
                    { new Guid("20f345ad-9d6b-4321-9a1e-66c98dd64260"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "nguyen.a@example.com", "Nguyễn Văn A", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/7_plw6ns.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU101", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU101" },
                    { new Guid("2c855ab0-0400-4096-8fb2-e3c1af379d79"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "vu.f@example.com", "Vũ Thị F", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/2_hlwinq.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU106", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU106" },
                    { new Guid("4020ad3b-b166-443c-8168-690c9a5df2d0"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "ngo.i@example.com", "Ngô Văn I", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/4_yr3kyt.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU109", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU109" },
                    { new Guid("477fc670-bac3-4d48-a8c8-7276533f70ca"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "tran.b@example.com", "Trần Thị B", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/6_ydar9m.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU102", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU102" },
                    { new Guid("507926c3-5cb2-46a3-97ad-20f9d8833ef8"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "hoang.e@example.com", "Hoàng Văn E", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813011522_e3396b099fec5e01dc56a2331b757d8e_nsrnzc.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU105", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU105" },
                    { new Guid("56dbe702-deac-4924-8cc1-4ce4a8874749"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "do.g@example.com", "Đỗ Văn G", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/z5852813019059_6493ca13ee06ac935e9889fe51bd2886_ooz29c.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU107", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU107" },
                    { new Guid("58bfdde3-6928-44f2-b14a-24ea33a58ebe"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "dang.k@example.com", "Đặng Thị K", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/12_wsmqha.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU110", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU110" },
                    { new Guid("89066593-29bc-48ff-9a31-532cd4c4c5b6"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "bui.h@example.com", "Bùi Thị H", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/13_gqcowy.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU108", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU108" },
                    { new Guid("ca597e9a-4ea1-4ad6-b8d4-b882ec559a52"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "le.c@example.com", "Lê Văn C", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813026004_885e224ee4b8dbfbb128e583c278a615_dicbrf.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU103", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU103" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivitiesAttendance_AttendanceId",
                table: "ExtraActivitiesAttendance",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivitiesAttendance_StatusId",
                table: "ExtraActivitiesAttendance",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivitiesAttendance_StudentId",
                table: "ExtraActivitiesAttendance",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraActivitiesAttendance");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("18a1bf8b-d2c0-470a-82d2-0de480288f63"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("20f345ad-9d6b-4321-9a1e-66c98dd64260"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("2c855ab0-0400-4096-8fb2-e3c1af379d79"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("4020ad3b-b166-443c-8168-690c9a5df2d0"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("477fc670-bac3-4d48-a8c8-7276533f70ca"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("507926c3-5cb2-46a3-97ad-20f9d8833ef8"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("56dbe702-deac-4924-8cc1-4ce4a8874749"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("58bfdde3-6928-44f2-b14a-24ea33a58ebe"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("89066593-29bc-48ff-9a31-532cd4c4c5b6"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ca597e9a-4ea1-4ad6-b8d4-b882ec559a52"));

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CitizenID", "ClassroomId", "Dob", "Email", "FullName", "HomeTown", "Image", "ParentPhone", "Password", "Phone", "PublicStudentID", "RefreshToken", "RoleId", "StudentTypeId", "UnionJoinDate", "Username" },
                values: new object[,]
                {
                    { new Guid("30186686-58a8-4ec8-829c-d3bb817a41ae"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "tran.b@example.com", "Trần Thị B", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/6_ydar9m.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU102", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU102" },
                    { new Guid("3ac83462-064f-49b0-9391-d294ba6568a0"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "nguyen.a@example.com", "Nguyễn Văn A", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/7_plw6ns.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU101", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU101" },
                    { new Guid("3ad2c238-d8ac-4f76-902a-cc56cd22a4b9"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "vu.f@example.com", "Vũ Thị F", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/2_hlwinq.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU106", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU106" },
                    { new Guid("3e2ba796-3f68-4217-9dc6-065f9f249ea7"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "ngo.i@example.com", "Ngô Văn I", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/4_yr3kyt.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU109", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU109" },
                    { new Guid("50940423-c421-4f8c-a527-76f213ce631d"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "le.c@example.com", "Lê Văn C", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813026004_885e224ee4b8dbfbb128e583c278a615_dicbrf.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU103", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU103" },
                    { new Guid("5eee0482-91cf-4959-897b-804603d7b0cb"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "bui.h@example.com", "Bùi Thị H", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/13_gqcowy.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU108", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU108" },
                    { new Guid("8f84fbe7-d1bd-4c15-b973-39d6653718dd"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "do.g@example.com", "Đỗ Văn G", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/z5852813019059_6493ca13ee06ac935e9889fe51bd2886_ooz29c.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU107", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU107" },
                    { new Guid("99514a00-8851-4c53-9472-8eebc5f59787"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "hoang.e@example.com", "Hoàng Văn E", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813011522_e3396b099fec5e01dc56a2331b757d8e_nsrnzc.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU105", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU105" },
                    { new Guid("b04ccefd-1057-4789-a72b-e688212a8d45"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "pham.d@example.com", "Phạm Thị D", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/5_ek2pks.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU104", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU104" },
                    { new Guid("eb66491b-fe37-4d13-bf9b-722fd5404c96"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "dang.k@example.com", "Đặng Thị K", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/12_wsmqha.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU110", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU110" }
                });
        }
    }
}
