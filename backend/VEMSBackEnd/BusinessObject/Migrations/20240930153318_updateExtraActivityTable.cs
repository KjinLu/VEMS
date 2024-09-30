using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class updateExtraActivityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "AttendanceAt",
                table: "ExtraActivitiesAttendance",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "ExtraActivitiesAttendance",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "AttendanceAt",
                table: "ExtraActivitiesAttendance");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "ExtraActivitiesAttendance");

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
        }
    }
}
