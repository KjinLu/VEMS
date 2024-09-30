using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class updateExtraActivityTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraActivitiesAttendance_Attendances_AttendanceId",
                table: "ExtraActivitiesAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtraActivitiesAttendance_Statuses_StatusId",
                table: "ExtraActivitiesAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtraActivitiesAttendance_Students_StudentId",
                table: "ExtraActivitiesAttendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExtraActivitiesAttendance",
                table: "ExtraActivitiesAttendance");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0a387706-6232-47bd-b49c-3318d2970537"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0a57da37-88e4-4d2b-aa1e-50bd46a3792b"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("4e975b6f-0fba-45dd-8cae-abfa7a0cbf97"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("5b89dabc-9ded-45d5-be25-d9da42acf2d0"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("722b03c8-0d8f-4d69-a607-9caa6a6700cd"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("970349e1-9484-4855-92f1-183e257253c0"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("aa4afb04-d2a4-45b3-a788-763a3c5ddad0"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("dd5dc1b8-bd82-46d2-a3df-7d931009ad81"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("f7a42436-6ee8-4497-ba55-37fb0ac03ddd"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("fd695574-b7d9-4fae-b7ce-185bab96b445"));

            migrationBuilder.RenameTable(
                name: "ExtraActivitiesAttendance",
                newName: "ExtraActivitiesAttendances");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraActivitiesAttendance_StudentId",
                table: "ExtraActivitiesAttendances",
                newName: "IX_ExtraActivitiesAttendances_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraActivitiesAttendance_StatusId",
                table: "ExtraActivitiesAttendances",
                newName: "IX_ExtraActivitiesAttendances_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraActivitiesAttendance_AttendanceId",
                table: "ExtraActivitiesAttendances",
                newName: "IX_ExtraActivitiesAttendances_AttendanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExtraActivitiesAttendances",
                table: "ExtraActivitiesAttendances",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CitizenID", "ClassroomId", "Dob", "Email", "FullName", "HomeTown", "Image", "ParentPhone", "Password", "Phone", "PublicStudentID", "RefreshToken", "RoleId", "StudentTypeId", "UnionJoinDate", "Username" },
                values: new object[,]
                {
                    { new Guid("0489dfee-ba1a-4743-ad3a-e9bb8c095cd2"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "tran.b@example.com", "Trần Thị B", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/6_ydar9m.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU102", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU102" },
                    { new Guid("24da3d2f-28e5-4b50-b7b6-b99f71c9baa4"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "hoang.e@example.com", "Hoàng Văn E", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813011522_e3396b099fec5e01dc56a2331b757d8e_nsrnzc.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU105", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU105" },
                    { new Guid("3cb17f0c-b58f-404e-85ad-ebfefba3280f"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "ngo.i@example.com", "Ngô Văn I", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/4_yr3kyt.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU109", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU109" },
                    { new Guid("4a90cc9e-9d16-4725-a444-4a5336fb68ed"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "pham.d@example.com", "Phạm Thị D", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/5_ek2pks.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU104", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU104" },
                    { new Guid("5b91495f-0bfc-42bd-9697-5b27bc847573"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "dang.k@example.com", "Đặng Thị K", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/12_wsmqha.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU110", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU110" },
                    { new Guid("80fa7a94-2017-4498-b782-a5d66c62b2c1"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "le.c@example.com", "Lê Văn C", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813026004_885e224ee4b8dbfbb128e583c278a615_dicbrf.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU103", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU103" },
                    { new Guid("8317140f-6413-4413-9306-f86242083b77"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "do.g@example.com", "Đỗ Văn G", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/z5852813019059_6493ca13ee06ac935e9889fe51bd2886_ooz29c.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU107", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU107" },
                    { new Guid("d29a0cb5-5e46-4aa3-8de3-f699aa82f4ed"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "vu.f@example.com", "Vũ Thị F", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/2_hlwinq.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU106", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU106" },
                    { new Guid("d2aeba4b-4835-43ef-bbb5-4d88a14466e2"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "nguyen.a@example.com", "Nguyễn Văn A", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/7_plw6ns.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU101", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU101" },
                    { new Guid("dc202bd3-583a-4f34-8ec0-35252910a71c"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "bui.h@example.com", "Bùi Thị H", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/13_gqcowy.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU108", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU108" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraActivitiesAttendances_Attendances_AttendanceId",
                table: "ExtraActivitiesAttendances",
                column: "AttendanceId",
                principalTable: "Attendances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraActivitiesAttendances_Statuses_StatusId",
                table: "ExtraActivitiesAttendances",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraActivitiesAttendances_Students_StudentId",
                table: "ExtraActivitiesAttendances",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraActivitiesAttendances_Attendances_AttendanceId",
                table: "ExtraActivitiesAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtraActivitiesAttendances_Statuses_StatusId",
                table: "ExtraActivitiesAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtraActivitiesAttendances_Students_StudentId",
                table: "ExtraActivitiesAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExtraActivitiesAttendances",
                table: "ExtraActivitiesAttendances");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0489dfee-ba1a-4743-ad3a-e9bb8c095cd2"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("24da3d2f-28e5-4b50-b7b6-b99f71c9baa4"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("3cb17f0c-b58f-404e-85ad-ebfefba3280f"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("4a90cc9e-9d16-4725-a444-4a5336fb68ed"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("5b91495f-0bfc-42bd-9697-5b27bc847573"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("80fa7a94-2017-4498-b782-a5d66c62b2c1"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("8317140f-6413-4413-9306-f86242083b77"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("d29a0cb5-5e46-4aa3-8de3-f699aa82f4ed"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("d2aeba4b-4835-43ef-bbb5-4d88a14466e2"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("dc202bd3-583a-4f34-8ec0-35252910a71c"));

            migrationBuilder.RenameTable(
                name: "ExtraActivitiesAttendances",
                newName: "ExtraActivitiesAttendance");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraActivitiesAttendances_StudentId",
                table: "ExtraActivitiesAttendance",
                newName: "IX_ExtraActivitiesAttendance_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraActivitiesAttendances_StatusId",
                table: "ExtraActivitiesAttendance",
                newName: "IX_ExtraActivitiesAttendance_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraActivitiesAttendances_AttendanceId",
                table: "ExtraActivitiesAttendance",
                newName: "IX_ExtraActivitiesAttendance_AttendanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExtraActivitiesAttendance",
                table: "ExtraActivitiesAttendance",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CitizenID", "ClassroomId", "Dob", "Email", "FullName", "HomeTown", "Image", "ParentPhone", "Password", "Phone", "PublicStudentID", "RefreshToken", "RoleId", "StudentTypeId", "UnionJoinDate", "Username" },
                values: new object[,]
                {
                    { new Guid("0a387706-6232-47bd-b49c-3318d2970537"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "ngo.i@example.com", "Ngô Văn I", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/4_yr3kyt.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU109", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU109" },
                    { new Guid("0a57da37-88e4-4d2b-aa1e-50bd46a3792b"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "le.c@example.com", "Lê Văn C", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813026004_885e224ee4b8dbfbb128e583c278a615_dicbrf.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU103", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU103" },
                    { new Guid("4e975b6f-0fba-45dd-8cae-abfa7a0cbf97"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "hoang.e@example.com", "Hoàng Văn E", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813011522_e3396b099fec5e01dc56a2331b757d8e_nsrnzc.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU105", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU105" },
                    { new Guid("5b89dabc-9ded-45d5-be25-d9da42acf2d0"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "tran.b@example.com", "Trần Thị B", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/6_ydar9m.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU102", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU102" },
                    { new Guid("722b03c8-0d8f-4d69-a607-9caa6a6700cd"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "pham.d@example.com", "Phạm Thị D", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/5_ek2pks.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU104", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU104" },
                    { new Guid("970349e1-9484-4855-92f1-183e257253c0"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "nguyen.a@example.com", "Nguyễn Văn A", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/7_plw6ns.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU101", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU101" },
                    { new Guid("aa4afb04-d2a4-45b3-a788-763a3c5ddad0"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "dang.k@example.com", "Đặng Thị K", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/12_wsmqha.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU110", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU110" },
                    { new Guid("dd5dc1b8-bd82-46d2-a3df-7d931009ad81"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "do.g@example.com", "Đỗ Văn G", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/z5852813019059_6493ca13ee06ac935e9889fe51bd2886_ooz29c.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU107", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU107" },
                    { new Guid("f7a42436-6ee8-4497-ba55-37fb0ac03ddd"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "vu.f@example.com", "Vũ Thị F", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/2_hlwinq.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU106", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU106" },
                    { new Guid("fd695574-b7d9-4fae-b7ce-185bab96b445"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "bui.h@example.com", "Bùi Thị H", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/13_gqcowy.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU108", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU108" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraActivitiesAttendance_Attendances_AttendanceId",
                table: "ExtraActivitiesAttendance",
                column: "AttendanceId",
                principalTable: "Attendances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraActivitiesAttendance_Statuses_StatusId",
                table: "ExtraActivitiesAttendance",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraActivitiesAttendance_Students_StudentId",
                table: "ExtraActivitiesAttendance",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
