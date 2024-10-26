using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SlotIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classrooms_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    PeriodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Periods_PeriodID",
                        column: x => x.PeriodID,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    RefreshToken = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClassroomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublicStudentID = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CitizenID = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Dob = table.Column<DateOnly>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Phone = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ParentPhone = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    HomeTown = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RefreshToken = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    UnionJoinDate = table.Column<DateOnly>(type: "date", nullable: true),
                    StudentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClassroomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_studentTypes_StudentTypeId",
                        column: x => x.StudentTypeId,
                        principalTable: "studentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublicTeacherID = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    CitizenID = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Dob = table.Column<DateOnly>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Phone = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    RefreshToken = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    TeacherTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassroomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teacher_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teacher_TeacherTypes_TeacherTypeId",
                        column: x => x.TeacherTypeId,
                        principalTable: "TeacherTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleDetails_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleDetails_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SlotDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SessionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlotID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassroomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlotDetails_Classrooms_ClassroomID",
                        column: x => x.ClassroomID,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SlotDetails_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SlotDetails_Slots_SlotID",
                        column: x => x.SlotID,
                        principalTable: "Slots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SlotDetails_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SlotDetails_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeReport = table.Column<DateTime>(type: "datetime", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_ScheduleDetails_ScheduleDetailId",
                        column: x => x.ScheduleDetailId,
                        principalTable: "ScheduleDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceCharges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceCharges_Attendances_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "Attendances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceCharges_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceStatuses_Attendances_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "Attendances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttendanceStatuses_Reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttendanceStatuses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttendanceStatuses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttendanceStatuses_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExtraActivitiesAttendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    AttendanceAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraActivitiesAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraActivitiesAttendances_Attendances_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "Attendances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraActivitiesAttendances_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraActivitiesAttendances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "GradeName" },
                values: new object[,]
                {
                    { new Guid("11f87b17-a80c-4420-b368-4680920bfe3d"), "10" },
                    { new Guid("afa373a9-b9ab-4561-97b1-549b76f91190"), "11" },
                    { new Guid("b6e0255a-aeee-4df7-8754-55dd27d360b2"), "12" }
                });

            migrationBuilder.InsertData(
                table: "Periods",
                columns: new[] { "Id", "Code", "PeriodName", "StartTime" },
                values: new object[,]
                {
                    { new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b"), "MORNING", "Sáng", new TimeSpan(0, 7, 0, 0, 0) },
                    { new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31"), "AFTERNOON", "Chiều", new TimeSpan(0, 14, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Reasons",
                columns: new[] { "Id", "ReasonName" },
                values: new object[,]
                {
                    { new Guid("169dcff1-cb19-4fd0-8ae3-f947360207cf"), "Công tác, HSG" },
                    { new Guid("17fea884-62f6-4686-b2ae-2a18ae4b2b82"), "Đang nằm viện" },
                    { new Guid("23f45441-d948-4a53-8a96-bc8be963b9e2"), "Do ốm đau" },
                    { new Guid("71e82443-08e8-4500-90f6-71732fd96ded"), "Khám NVQS" },
                    { new Guid("c4990d24-c573-4b40-ad01-c3f39042bad9"), "Nhà có việc hữu sự" },
                    { new Guid("e847e40e-e759-413a-adc3-b2a7fe72c128"), "Khác" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "RoleName" },
                values: new object[,]
                {
                    { new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), "STUDENT", "Học sinh" },
                    { new Guid("04c92fd7-51b1-4852-8b8a-cacbe1511670"), "ADMIN", "Quản trị viên" },
                    { new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"), "TEACHER", "Giáo viên" }
                });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "EndTime", "SlotIndex", "StartTime" },
                values: new object[,]
                {
                    { new Guid("0811126b-4fb3-4e29-b0f6-94b00bf0b98b"), new TimeSpan(0, 8, 45, 0, 0), 2, new TimeSpan(0, 8, 0, 0, 0) },
                    { new Guid("4ebda95f-f406-43d2-a88b-be2b1ddbe1b5"), new TimeSpan(0, 11, 30, 0, 0), 5, new TimeSpan(0, 10, 45, 0, 0) },
                    { new Guid("79e57c6a-fae8-42b4-a460-b48447e3e076"), new TimeSpan(0, 16, 35, 0, 0), 8, new TimeSpan(0, 15, 50, 0, 0) },
                    { new Guid("9495ef71-051d-4e1b-9de3-31fa6d238252"), new TimeSpan(0, 13, 40, 0, 0), 7, new TimeSpan(0, 14, 55, 0, 0) },
                    { new Guid("b2e5cc3b-f6f2-427e-9d9e-1f44ee8d2e80"), new TimeSpan(0, 9, 50, 0, 0), 3, new TimeSpan(0, 9, 5, 0, 0) },
                    { new Guid("c5b67725-545f-4edd-8198-05bedcb5b00f"), new TimeSpan(0, 14, 45, 0, 0), 6, new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("db1085ce-9ba3-4894-a8a0-d417bc6b0774"), new TimeSpan(0, 7, 45, 0, 0), 1, new TimeSpan(0, 7, 0, 0, 0) },
                    { new Guid("e1e53de7-7170-46b4-8230-2790c42a7cac"), new TimeSpan(0, 17, 30, 0, 0), 9, new TimeSpan(0, 16, 45, 0, 0) },
                    { new Guid("e8b4217f-5a6c-4428-9901-99e62ce1f562"), new TimeSpan(0, 10, 40, 0, 0), 4, new TimeSpan(0, 9, 55, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Code", "StatusName" },
                values: new object[,]
                {
                    { new Guid("3e04faa2-5c62-43c6-be78-01f114d01446"), "ABSENTED_WITH_PERMISSION", "Vắng mặt có phép" },
                    { new Guid("ac6ff8a5-2017-402a-8966-9ce59146c689"), "ABSENTED_WITHOUT_PERMISSION", "Vắng mặt không phép" },
                    { new Guid("b16d2725-e2d4-47a8-8709-0c0c1ca3945d"), "NOT_MARKED", "Chưa điểm danh" },
                    { new Guid("f60aaf45-9e88-4818-9ed0-3e8f83bfb66e"), "ATTENDED", "Có mặt" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Code", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("0aaf283b-4d65-42af-a998-938efe370318"), "INFORMATICS", "Tin học" },
                    { new Guid("107f7c24-e063-4dfd-beb8-d955e1fd0f8a"), "MATHEMATICS", "Toán học" },
                    { new Guid("2a739d2f-6b40-4fe4-8cf3-6b2c47967a55"), "FOREIGN_LANGUAGE", "Ngoại ngữ" },
                    { new Guid("4e943f72-a5ee-427f-9594-83598d33f411"), "PHYSICAL_EDUCATION", "Thể dục" },
                    { new Guid("50d08f10-a2b8-4119-8053-e95f00cdf608"), "LITERATURE", "Ngữ văn" },
                    { new Guid("52e87219-4d5c-4d96-a944-a04292e2f617"), "GEOGRAPHY", "Địa lý" },
                    { new Guid("631135bd-81eb-4b70-a779-418af291d138"), "PHYSICS", "Vật lý" },
                    { new Guid("669af09a-9f35-45b5-a2ce-1a9efbeeb476"), "BIOLOGY", "Sinh học" },
                    { new Guid("77faf4ba-c356-4633-9505-91e4c8402800"), "HISTORY", "Lịch sử" },
                    { new Guid("7c756bba-6c1d-43db-8fb7-7c53295019a3"), "TECHNOLOGY", "Công nghệ" },
                    { new Guid("94aa1b88-0fb0-4669-a7d7-73793e453e94"), "CHEMISTRY", "Hóa học" },
                    { new Guid("9e777928-8399-4efe-bd19-164b1f6acc8e"), "FINE_ART", "Mỹ thuật" },
                    { new Guid("a3d3b555-0cf4-4b41-8131-a4c205d9a6f3"), "DEFENSE_EDUCATION", "Giáo dục quốc phòng" },
                    { new Guid("ab569adc-c289-48ee-9286-73cd9863458e"), "CIVIC_EDUCATION", "Giáo dục công dân" },
                    { new Guid("b1d3b555-0cf4-4b41-8131-a4c205d9a6f4"), "SHDC", "SHDC" },
                    { new Guid("c2d3b555-0cf4-4b41-8131-a4c205d9a6f5"), "HDTN_HN", "HĐTN-HN" },
                    { new Guid("d3d3b555-0cf4-4b41-8131-a4c205d9a6f6"), "GDKT_PL", "GDKT-PL" },
                    { new Guid("d3d41c42-c3b4-4713-b231-b2851634f378"), "MUSIC", "Âm nhạc" },
                    { new Guid("e4d3b555-0cf4-4b41-8131-a4c205d9a6f7"), "SHCN", "SHCN" },
                    { new Guid("f5d3b555-0cf4-4b41-8131-a4c205d9a6f8"), "MATH_FRENCH", "Toán Pháp" }
                });

            migrationBuilder.InsertData(
                table: "TeacherTypes",
                columns: new[] { "Id", "Code", "TypeName" },
                values: new object[,]
                {
                    { new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"), "DATA_ENTRY_TEACHER", "Giáo viên nhập liệu" },
                    { new Guid("e5f785e3-4579-4465-b930-39b636a4d818"), "PRIMARY_TEACHER", "Giáo viên chủ nhiệm" }
                });

            migrationBuilder.InsertData(
                table: "studentTypes",
                columns: new[] { "Id", "Code", "TypeName" },
                values: new object[,]
                {
                    { new Guid("468a8e7c-0ad1-465c-b570-5da68f276923"), "CLASS_VICE_MONITOR", "Lớp phó" },
                    { new Guid("cb440230-818a-4ad8-96de-3ae6c403b1ab"), "CLASS_MONITOR", "Lớp trưởng" },
                    { new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), "NORMAL_STUDENT", "Học sinh" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "Password", "RefreshToken", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("5b909d16-c9e6-42bc-b46c-d766280d93b8"), "admin2@email.com", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", new Guid("04c92fd7-51b1-4852-8b8a-cacbe1511670"), "admin2" },
                    { new Guid("b584540e-49d9-4d45-bef4-f779f8e6c973"), "admin1@email.com", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", new Guid("04c92fd7-51b1-4852-8b8a-cacbe1511670"), "admin1" }
                });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "ClassName", "GradeId" },
                values: new object[,]
                {
                    { new Guid("01c6d903-784d-45fb-8511-47e9d6ff7611"), "10A5", new Guid("11f87b17-a80c-4420-b368-4680920bfe3d") },
                    { new Guid("11521ae4-fd95-474c-8d3e-e8ca3cbc21f3"), "12A1", new Guid("b6e0255a-aeee-4df7-8754-55dd27d360b2") },
                    { new Guid("3df0676a-021e-4a1f-a082-fa88b6dbe200"), "11A3", new Guid("afa373a9-b9ab-4561-97b1-549b76f91190") },
                    { new Guid("79dfe9dc-2b47-4222-bce2-7c85e91424d6"), "10A3", new Guid("11f87b17-a80c-4420-b368-4680920bfe3d") },
                    { new Guid("7dbe0c01-40e0-4e8b-8112-0f4c01d6eb2f"), "12A4", new Guid("b6e0255a-aeee-4df7-8754-55dd27d360b2") },
                    { new Guid("88660625-222d-48e7-bef7-aa2fae36d968"), "11A4", new Guid("afa373a9-b9ab-4561-97b1-549b76f91190") },
                    { new Guid("8f3cdace-270e-41bc-8ee5-0d07321c7975"), "11A1", new Guid("afa373a9-b9ab-4561-97b1-549b76f91190") },
                    { new Guid("8fb55a60-4d64-4eb7-9ae1-4202cd25d9e2"), "12A3", new Guid("b6e0255a-aeee-4df7-8754-55dd27d360b2") },
                    { new Guid("9c62f26b-a825-4ee5-9c0a-09cd0aff7409"), "12A5", new Guid("b6e0255a-aeee-4df7-8754-55dd27d360b2") },
                    { new Guid("a71d8e2d-6e7d-44a5-a8be-cd9757f199be"), "11A2", new Guid("afa373a9-b9ab-4561-97b1-549b76f91190") },
                    { new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), "10A4", new Guid("11f87b17-a80c-4420-b368-4680920bfe3d") },
                    { new Guid("b4c997f3-3d75-4b63-bd19-7d849999481c"), "12A6", new Guid("b6e0255a-aeee-4df7-8754-55dd27d360b2") },
                    { new Guid("c7235f3d-8414-4832-b0c5-a97781490a48"), "11A5", new Guid("afa373a9-b9ab-4561-97b1-549b76f91190") },
                    { new Guid("d2a5a5a1-87c6-4714-bbfd-176571ebf89a"), "10A2", new Guid("11f87b17-a80c-4420-b368-4680920bfe3d") },
                    { new Guid("ddd7dda5-a208-4ccc-947e-c96e603a4609"), "12A2", new Guid("b6e0255a-aeee-4df7-8754-55dd27d360b2") },
                    { new Guid("f3bc74d1-04c8-47c9-b569-d9aaf268f195"), "10A1", new Guid("11f87b17-a80c-4420-b368-4680920bfe3d") }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "DayOfWeek", "PeriodID" },
                values: new object[,]
                {
                    { new Guid("02505d8c-8c01-4734-b79c-a053e9c86f9d"), 2, new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b") },
                    { new Guid("2246a4b5-1dc9-4b8b-a6ea-f4e3d2635249"), 4, new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b") },
                    { new Guid("32196bfb-4117-4fc7-a0d7-7c2751544d1e"), 6, new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31") },
                    { new Guid("32f10e78-2737-4cab-a74a-f7986f1c5bca"), 1, new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31") },
                    { new Guid("55987953-39cd-43f7-84ee-84b79170e7fd"), 2, new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31") },
                    { new Guid("5abe297f-e351-4939-bded-ec538c595417"), 5, new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b") },
                    { new Guid("6be09935-4ba1-42e2-9ccc-ab66fe1569a3"), 3, new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31") },
                    { new Guid("6c6b00cc-1030-4029-aaf5-299019bd303d"), 3, new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b") },
                    { new Guid("6fa3d575-2f46-4615-aa63-ab53dc32bd8b"), 1, new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b") },
                    { new Guid("b53c2d5c-bc63-4c0d-84c7-d3a69073879c"), 6, new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b") },
                    { new Guid("c1188b95-fcb3-4d83-8ac0-04c0f26fbb3d"), 4, new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31") },
                    { new Guid("d1f42050-c53b-45bf-8473-ebc14c01d4b7"), 5, new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CitizenID", "ClassroomId", "Dob", "Email", "FullName", "HomeTown", "Image", "ParentPhone", "Password", "Phone", "PublicStudentID", "RefreshToken", "RoleId", "StudentTypeId", "UnionJoinDate", "Username" },
                values: new object[,]
                {
                    { new Guid("008d59cc-74e4-46b9-8bc5-ccfb8a7bc6ff"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "dang.k@example.com", "Đặng Thị K", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/12_wsmqha.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU110", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU110" },
                    { new Guid("35a29aec-31b5-49a3-9a62-f3b39c94f990"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "pham.d@example.com", "Phạm Thị D", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/5_ek2pks.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU104", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU104" },
                    { new Guid("74ee2660-3e46-4c2c-a104-68f4cdab5c2f"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "tran.b@example.com", "Trần Thị B", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/6_ydar9m.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU102", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU102" },
                    { new Guid("84b220ef-5093-414d-9456-7b89b60c1075"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "bui.h@example.com", "Bùi Thị H", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/13_gqcowy.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU108", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU108" },
                    { new Guid("9f3cf5ad-13b3-41d0-83e9-8e2d2f71bfa2"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "le.c@example.com", "Lê Văn C", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813026004_885e224ee4b8dbfbb128e583c278a615_dicbrf.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU103", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU103" },
                    { new Guid("acfb38f1-fe3c-429b-9d79-37b283c37ad9"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "ngo.i@example.com", "Ngô Văn I", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/4_yr3kyt.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU109", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU109" },
                    { new Guid("beba6258-f911-4875-b4f6-12072503acfc"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "do.g@example.com", "Đỗ Văn G", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/z5852813019059_6493ca13ee06ac935e9889fe51bd2886_ooz29c.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU107", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU107" },
                    { new Guid("c5ab0512-eadf-4720-ac1f-1a43f453cc9e"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "vu.f@example.com", "Vũ Thị F", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/2_hlwinq.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU106", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU106" },
                    { new Guid("d7dfdfa2-6c7e-4420-b6b3-0bc4f87cc1f5"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "hoang.e@example.com", "Hoàng Văn E", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813011522_e3396b099fec5e01dc56a2331b757d8e_nsrnzc.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU105", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU105" },
                    { new Guid("eacd23a6-5884-47a4-81bd-c1aedc24b40c"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "nguyen.a@example.com", "Nguyễn Văn A", "", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/7_plw6ns.jpg", "", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "", "MCU101", "", new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"), new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"), null, "MCU101" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Address", "CitizenID", "ClassroomId", "Dob", "Email", "FullName", "Image", "Password", "Phone", "PublicTeacherID", "RefreshToken", "RoleId", "TeacherTypeId", "Username" },
                values: new object[,]
                {
                    { new Guid("493d052a-67a1-4428-981d-4d7831d3d344"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "tranthib@example.com", "Trần Thị B", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900643/z5852812999947_cb79c443d7ad6df3917b4a48111e4158_bpsx1v.jpg", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "0987654321", null, null, new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"), new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"), "0987654321" },
                    { new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "leminhc@example.com", "Lê Minh C", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900642/10_bpqux3.jpg", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "0901234567", null, null, new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"), new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"), "0901234567" },
                    { new Guid("b2c3d4e5-6f7a-8b9c-0d1e-2f3a4b5c6d7e"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "phamthid@example.com", "Phạm Thị D", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900642/9_l4nqzj.jpg", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "0934567890", null, null, new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"), new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"), "0934567890" },
                    { new Guid("c3d4e5f6-7a8b-9c0d-1e2f-3a4b5c6d7e8f"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "hoangvane@example.com", "Hoàng Văn E", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900642/1_pcvqfn.jpg", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "0976543210", null, null, new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"), new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"), "0976543210" },
                    { new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"), "", "", new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), null, "nguyenvana@example.com", "Nguyễn Văn A", "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900643/11_bnerzr.jpg", "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22", "0912345678", null, null, new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"), new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"), "0912345678" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_RoleId",
                table: "Admins",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceCharges_AttendanceId",
                table: "AttendanceCharges",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceCharges_StudentId",
                table: "AttendanceCharges",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_ScheduleDetailId",
                table: "Attendances",
                column: "ScheduleDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceStatuses_AttendanceId",
                table: "AttendanceStatuses",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceStatuses_ReasonId",
                table: "AttendanceStatuses",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceStatuses_StatusId",
                table: "AttendanceStatuses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceStatuses_StudentId",
                table: "AttendanceStatuses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceStatuses_TeacherId",
                table: "AttendanceStatuses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_GradeId",
                table: "Classrooms",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivitiesAttendances_AttendanceId",
                table: "ExtraActivitiesAttendances",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivitiesAttendances_StatusId",
                table: "ExtraActivitiesAttendances",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivitiesAttendances_StudentId",
                table: "ExtraActivitiesAttendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDetails_ScheduleId",
                table: "ScheduleDetails",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDetails_SessionId",
                table: "ScheduleDetails",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClassroomId",
                table: "Schedules",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_PeriodID",
                table: "Sessions",
                column: "PeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_SlotDetails_ClassroomID",
                table: "SlotDetails",
                column: "ClassroomID");

            migrationBuilder.CreateIndex(
                name: "IX_SlotDetails_SessionID",
                table: "SlotDetails",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_SlotDetails_SlotID",
                table: "SlotDetails",
                column: "SlotID");

            migrationBuilder.CreateIndex(
                name: "IX_SlotDetails_SubjectID",
                table: "SlotDetails",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_SlotDetails_TeacherID",
                table: "SlotDetails",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassroomId",
                table: "Students",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoleId",
                table: "Students",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentTypeId",
                table: "Students",
                column: "StudentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ClassroomId",
                table: "Teacher",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_RoleId",
                table: "Teacher",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_TeacherTypeId",
                table: "Teacher",
                column: "TeacherTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AttendanceCharges");

            migrationBuilder.DropTable(
                name: "AttendanceStatuses");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "EmailTokens");

            migrationBuilder.DropTable(
                name: "ExtraActivitiesAttendances");

            migrationBuilder.DropTable(
                name: "SlotDetails");

            migrationBuilder.DropTable(
                name: "Reasons");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "ScheduleDetails");

            migrationBuilder.DropTable(
                name: "studentTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TeacherTypes");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
