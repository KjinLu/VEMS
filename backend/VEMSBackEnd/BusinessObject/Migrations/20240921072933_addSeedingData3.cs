using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addSeedingData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("11085f95-f9ed-43e6-9d1b-41407ab837d8"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("250df612-997c-4bbc-a523-48a87a69401b"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("2a845406-cb48-4760-9471-976ea1ec088a"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("33905b69-1b0f-496f-ba4d-fcbb558117a6"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("359ed02e-4678-40c8-9da6-b593ac6baedc"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("51e5d81b-ca3c-49e2-8b16-39125c2059ce"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("9977531c-7828-4198-ab34-46cd83be9c0f"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("9a842bbc-24a4-406c-92ac-4d82c29a312b"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("e7bb5970-c705-4567-926b-569fd7be7707"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("fb699d9b-9c26-41fc-a6a6-9cdf021e3079"));

            migrationBuilder.InsertData(
                table: "Reasons",
                columns: new[] { "Id", "Description", "ReasonName" },
                values: new object[,]
                {
                    { new Guid("169dcff1-cb19-4fd0-8ae3-f947360207cf"), "", "Công tác, HSG" },
                    { new Guid("17fea884-62f6-4686-b2ae-2a18ae4b2b82"), "", "Đang nằm viện" },
                    { new Guid("23f45441-d948-4a53-8a96-bc8be963b9e2"), "", "Do ốm đau" },
                    { new Guid("71e82443-08e8-4500-90f6-71732fd96ded"), "", "Khám NVQS" },
                    { new Guid("c4990d24-c573-4b40-ad01-c3f39042bad9"), "", "Nhà có việc hữu sự" },
                    { new Guid("e847e40e-e759-413a-adc3-b2a7fe72c128"), "", "Khác" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CitizenID", "ClassroomId", "Dob", "Email", "FullName", "HomeTown", "Image", "ParentPhone", "Password", "Phone", "PublicStudentID", "RefreshToken", "RoleId", "StudentTypeId", "UnionJoinDate", "Username" },
                values: new object[,]
                {
                    { new Guid("25ece093-29c2-41e9-b4f1-be617ea2674f"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "ngo.i@example.com", "Ngô Văn I", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/4_yr3kyt.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU109", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU109" },
                    { new Guid("83541134-3afe-4a7f-a76e-298c1b5e2aeb"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "bui.h@example.com", "Bùi Thị H", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/13_gqcowy.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU108", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU108" },
                    { new Guid("87dfddb3-2010-4b01-9f9d-afc0fef952e7"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "dang.k@example.com", "Đặng Thị K", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/12_wsmqha.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU110", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU110" },
                    { new Guid("8f8a6f6c-deb6-4df5-aa0f-37ac53322530"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "do.g@example.com", "Đỗ Văn G", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/z5852813019059_6493ca13ee06ac935e9889fe51bd2886_ooz29c.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU107", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU107" },
                    { new Guid("a0161202-1286-4883-994e-c520b26fddd2"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "hoang.e@example.com", "Hoàng Văn E", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813011522_e3396b099fec5e01dc56a2331b757d8e_nsrnzc.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU105", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU105" },
                    { new Guid("a0fa53b0-b187-46d6-a527-afe6ecb90b16"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "nguyen.a@example.com", "Nguyễn Văn A", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/7_plw6ns.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU101", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU101" },
                    { new Guid("bb85a664-6640-4af7-aa4f-f950a0b2171c"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "vu.f@example.com", "Vũ Thị F", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/2_hlwinq.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU106", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU106" },
                    { new Guid("c5112cd7-d8bf-4d70-b943-7af9f95a9372"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "le.c@example.com", "Lê Văn C", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813026004_885e224ee4b8dbfbb128e583c278a615_dicbrf.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU103", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU103" },
                    { new Guid("d898d4e0-6b84-43d9-b60c-c0a0270763ab"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "tran.b@example.com", "Trần Thị B", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/6_ydar9m.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU102", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU102" },
                    { new Guid("f43a35fb-c045-4671-836f-632a840fea28"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "pham.d@example.com", "Phạm Thị D", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/5_ek2pks.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU104", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU104" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: new Guid("169dcff1-cb19-4fd0-8ae3-f947360207cf"));

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: new Guid("17fea884-62f6-4686-b2ae-2a18ae4b2b82"));

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: new Guid("23f45441-d948-4a53-8a96-bc8be963b9e2"));

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: new Guid("71e82443-08e8-4500-90f6-71732fd96ded"));

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: new Guid("c4990d24-c573-4b40-ad01-c3f39042bad9"));

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: new Guid("e847e40e-e759-413a-adc3-b2a7fe72c128"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("25ece093-29c2-41e9-b4f1-be617ea2674f"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("83541134-3afe-4a7f-a76e-298c1b5e2aeb"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("87dfddb3-2010-4b01-9f9d-afc0fef952e7"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("8f8a6f6c-deb6-4df5-aa0f-37ac53322530"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("a0161202-1286-4883-994e-c520b26fddd2"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("a0fa53b0-b187-46d6-a527-afe6ecb90b16"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bb85a664-6640-4af7-aa4f-f950a0b2171c"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("c5112cd7-d8bf-4d70-b943-7af9f95a9372"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("d898d4e0-6b84-43d9-b60c-c0a0270763ab"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("f43a35fb-c045-4671-836f-632a840fea28"));

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CitizenID", "ClassroomId", "Dob", "Email", "FullName", "HomeTown", "Image", "ParentPhone", "Password", "Phone", "PublicStudentID", "RefreshToken", "RoleId", "StudentTypeId", "UnionJoinDate", "Username" },
                values: new object[,]
                {
                    { new Guid("11085f95-f9ed-43e6-9d1b-41407ab837d8"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "tran.b@example.com", "Trần Thị B", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/6_ydar9m.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU102", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU102" },
                    { new Guid("250df612-997c-4bbc-a523-48a87a69401b"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "nguyen.a@example.com", "Nguyễn Văn A", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/7_plw6ns.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU101", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU101" },
                    { new Guid("2a845406-cb48-4760-9471-976ea1ec088a"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "ngo.i@example.com", "Ngô Văn I", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/4_yr3kyt.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU109", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU109" },
                    { new Guid("33905b69-1b0f-496f-ba4d-fcbb558117a6"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "dang.k@example.com", "Đặng Thị K", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/12_wsmqha.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU110", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU110" },
                    { new Guid("359ed02e-4678-40c8-9da6-b593ac6baedc"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "bui.h@example.com", "Bùi Thị H", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/13_gqcowy.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU108", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU108" },
                    { new Guid("51e5d81b-ca3c-49e2-8b16-39125c2059ce"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "pham.d@example.com", "Phạm Thị D", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/5_ek2pks.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU104", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU104" },
                    { new Guid("9977531c-7828-4198-ab34-46cd83be9c0f"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "le.c@example.com", "Lê Văn C", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813026004_885e224ee4b8dbfbb128e583c278a615_dicbrf.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU103", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU103" },
                    { new Guid("9a842bbc-24a4-406c-92ac-4d82c29a312b"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "vu.f@example.com", "Vũ Thị F", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/2_hlwinq.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU106", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU106" },
                    { new Guid("e7bb5970-c705-4567-926b-569fd7be7707"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "do.g@example.com", "Đỗ Văn G", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/z5852813019059_6493ca13ee06ac935e9889fe51bd2886_ooz29c.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU107", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU107" },
                    { new Guid("fb699d9b-9c26-41fc-a6a6-9cdf021e3079"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "hoang.e@example.com", "Hoàng Văn E", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813011522_e3396b099fec5e01dc56a2331b757d8e_nsrnzc.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU105", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU105" }
                });
        }
    }
}
