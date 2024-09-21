using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class editSeedingData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("0108d3be-3bce-45d7-8562-346547af9911"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ac4048f7-4fbd-46d4-beba-acdb2953c518"));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Teacher",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherID",
                table: "SlotDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Code", "StatusName" },
                values: new object[] { new Guid("b16d2725-e2d4-47a8-8709-0c0c1ca3945d"), "NOT_MARKED", "Chưa điểm danh" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CitizenID", "ClassroomId", "Dob", "Email", "FullName", "HomeTown", "Image", "ParentPhone", "Password", "Phone", "PublicStudentID", "RefreshToken", "RoleId", "StudentTypeId", "UnionJoinDate", "Username" },
                values: new object[,]
                {
                    { new Guid("020cba84-d830-40b1-9616-2182408757cf"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "nguyen.a@example.com", "Nguyễn Văn A", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/7_plw6ns.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU101", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU101" },
                    { new Guid("4e4f1166-1404-4526-804c-899c637654b0"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "ngo.i@example.com", "Ngô Văn I", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/4_yr3kyt.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU109", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU109" },
                    { new Guid("706fc17a-1487-4dda-834f-1c7eba7946d6"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "le.c@example.com", "Lê Văn C", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813026004_885e224ee4b8dbfbb128e583c278a615_dicbrf.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU103", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU103" },
                    { new Guid("75f3ffb9-196a-42cc-96bb-b8c957c6a49f"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "hoang.e@example.com", "Hoàng Văn E", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813011522_e3396b099fec5e01dc56a2331b757d8e_nsrnzc.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU105", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU105" },
                    { new Guid("8049b935-be2a-4360-b711-27215880ae17"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "bui.h@example.com", "Bùi Thị H", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/13_gqcowy.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU108", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU108" },
                    { new Guid("ab11a661-ccf0-4d90-ac91-0f087ff46ad8"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "do.g@example.com", "Đỗ Văn G", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/z5852813019059_6493ca13ee06ac935e9889fe51bd2886_ooz29c.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU107", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU107" },
                    { new Guid("acf3d324-0c47-4c42-ace2-2fdb2783f178"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "vu.f@example.com", "Vũ Thị F", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/2_hlwinq.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU106", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU106" },
                    { new Guid("bc9217df-eb7e-4e1a-bf05-0b118e85281f"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "dang.k@example.com", "Đặng Thị K", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/12_wsmqha.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU110", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU110" },
                    { new Guid("e6c0a8cd-6990-462c-8a91-a53383105821"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "pham.d@example.com", "Phạm Thị D", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/5_ek2pks.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU104", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU104" },
                    { new Guid("f5ee02fb-ac94-4caf-9ad0-0e21544d6a3c"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "tran.b@example.com", "Trần Thị B", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/6_ydar9m.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU102", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU102" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Code", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("b1d3b555-0cf4-4b41-8131-a4c205d9a6f4"), "SHDC", "SHDC" },
                    { new Guid("c2d3b555-0cf4-4b41-8131-a4c205d9a6f5"), "HDTN_HN", "HĐTN-HN" },
                    { new Guid("d3d3b555-0cf4-4b41-8131-a4c205d9a6f6"), "GDKT_PL", "GDKT-PL" },
                    { new Guid("e4d3b555-0cf4-4b41-8131-a4c205d9a6f7"), "SHCN", "SHCN" },
                    { new Guid("f5d3b555-0cf4-4b41-8131-a4c205d9a6f8"), "MATH_FRENCH", "Toán Pháp" }
                });

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("493d052a-67a1-4428-981d-4d7831d3d344"),
                columns: new[] { "CitizenID", "Dob", "Email", "FullName", "Image", "Phone", "PublicTeacherID", "RefreshToken", "Username" },
                values: new object[] { "", null, "tranthib@example.com", "Trần Thị B", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900643/z5852812999947_cb79c443d7ad6df3917b4a48111e4158_bpsx1v.jpg", "0987654321", null, null, "0987654321" });

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"),
                columns: new[] { "CitizenID", "Dob", "Email", "FullName", "Image", "Phone", "PublicTeacherID", "RefreshToken", "Username" },
                values: new object[] { "", null, "nguyenvana@example.com", "Nguyễn Văn A", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900643/11_bnerzr.jpg", "0912345678", null, null, "0912345678" });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Address", "CitizenID", "Dob", "Email", "FullName", "Image", "Password", "Phone", "PublicTeacherID", "RefreshToken", "RoleId", "TeacherTypeId", "Username" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "", "", null, "leminhc@example.com", "Lê Minh C", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900642/10_bpqux3.jpg", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "0901234567", null, null, new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"), new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"), "0901234567" },
                    { new Guid("b2c3d4e5-6f7a-8b9c-0d1e-2f3a4b5c6d7e"), "", "", null, "phamthid@example.com", "Phạm Thị D", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900642/9_l4nqzj.jpg", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "0934567890", null, null, new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"), new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"), "0934567890" },
                    { new Guid("c3d4e5f6-7a8b-9c0d-1e2f-3a4b5c6d7e8f"), "", "", null, "hoangvane@example.com", "Hoàng Văn E", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900642/1_pcvqfn.jpg", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "0976543210", null, null, new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"), new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"), "0976543210" }
                });

            migrationBuilder.UpdateData(
                table: "TeacherTypes",
                keyColumn: "Id",
                keyValue: new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"),
                columns: new[] { "Code", "TypeName" },
                values: new object[] { "DATA_ENTRY_TEACHER", "Giáo viên nhập liệu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("b16d2725-e2d4-47a8-8709-0c0c1ca3945d"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("020cba84-d830-40b1-9616-2182408757cf"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("4e4f1166-1404-4526-804c-899c637654b0"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("706fc17a-1487-4dda-834f-1c7eba7946d6"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("75f3ffb9-196a-42cc-96bb-b8c957c6a49f"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("8049b935-be2a-4360-b711-27215880ae17"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ab11a661-ccf0-4d90-ac91-0f087ff46ad8"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("acf3d324-0c47-4c42-ace2-2fdb2783f178"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bc9217df-eb7e-4e1a-bf05-0b118e85281f"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("e6c0a8cd-6990-462c-8a91-a53383105821"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("f5ee02fb-ac94-4caf-9ad0-0e21544d6a3c"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("b1d3b555-0cf4-4b41-8131-a4c205d9a6f4"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("c2d3b555-0cf4-4b41-8131-a4c205d9a6f5"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("d3d3b555-0cf4-4b41-8131-a4c205d9a6f6"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("e4d3b555-0cf4-4b41-8131-a4c205d9a6f7"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("f5d3b555-0cf4-4b41-8131-a4c205d9a6f8"));

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5c6d"));

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-6f7a-8b9c-0d1e-2f3a4b5c6d7e"));

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-7a8b-9c0d-1e2f-3a4b5c6d7e8f"));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Teacher",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherID",
                table: "SlotDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CitizenID", "ClassroomId", "Dob", "Email", "FullName", "HomeTown", "Image", "ParentPhone", "Password", "Phone", "PublicStudentID", "RefreshToken", "RoleId", "StudentTypeId", "UnionJoinDate", "Username" },
                values: new object[,]
                {
                    { new Guid("0108d3be-3bce-45d7-8562-346547af9911"), "", "1", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), new DateOnly(2009, 1, 1), "student1@email.com", "Stu 1", "", "", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "1", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "student1" },
                    { new Guid("ac4048f7-4fbd-46d4-beba-acdb2953c518"), "", "1", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), new DateOnly(2009, 1, 1), "student2@email.com", "", "", "", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "1", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "student2" }
                });

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("493d052a-67a1-4428-981d-4d7831d3d344"),
                columns: new[] { "CitizenID", "Dob", "Email", "FullName", "Image", "Phone", "PublicTeacherID", "RefreshToken", "Username" },
                values: new object[] { "1", new DateOnly(1996, 1, 1), "teacher2@email.com", "Tea 1", "", "", "1", "", "teacher2" });

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"),
                columns: new[] { "CitizenID", "Dob", "Email", "FullName", "Image", "Phone", "PublicTeacherID", "RefreshToken", "Username" },
                values: new object[] { "1", new DateOnly(1996, 1, 1), "teacher1@email.com", "Tea 1", "", "", "1", "", "teacher1" });

            migrationBuilder.UpdateData(
                table: "TeacherTypes",
                keyColumn: "Id",
                keyValue: new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"),
                columns: new[] { "Code", "TypeName" },
                values: new object[] { "NORMAL_TEACHER", "Giáo viên bộ môn" });
        }
    }
}
