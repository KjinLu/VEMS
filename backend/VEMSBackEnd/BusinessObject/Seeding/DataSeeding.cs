using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Seeding
{
    public static class DataSeeding
    {
        public static void SeedingRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = new Guid("04c92fd7-51b1-4852-8b8a-cacbe1511670"),
                    RoleName = "Quản trị viên",
                    Code = "ADMIN"

                },
                new Role
                {
                    Id = new Guid("81b3444c-c9fd-4efc-a774-e1e3fc3c3e53"),
                    RoleName = "Giáo viên",
                    Code = "TEACHER"
                },
                new Role
                {
                    Id = new Guid("01e27b7c-93ca-47f6-a09b-c7015717e2ed"),
                    RoleName = "Học sinh",
                    Code = "STUDENT"
                }
            );
        }

        public static void SeedingReason(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reason>().HasData(
               new Reason
               {
                   Id = new Guid("23f45441-d948-4a53-8a96-bc8be963b9e2"),
                   ReasonName = "Do ốm đau"
               },
                new Reason
                {
                    Id = new Guid("17fea884-62f6-4686-b2ae-2a18ae4b2b82"),
                    ReasonName = "Đang nằm viện"
                },
                new Reason
                {
                    Id = new Guid("c4990d24-c573-4b40-ad01-c3f39042bad9"),
                    ReasonName = "Nhà có việc hữu sự"
                },
                new Reason
                {
                    Id = new Guid("169dcff1-cb19-4fd0-8ae3-f947360207cf"),
                    ReasonName = "Công tác, HSG"
                },
                new Reason
                {
                    Id = new Guid("71e82443-08e8-4500-90f6-71732fd96ded"),
                    ReasonName = "Khám NVQS"
                },
                new Reason
                {
                    Id = new Guid("e847e40e-e759-413a-adc3-b2a7fe72c128"),
                    ReasonName = "Khác"
                }
            );
        }

        public static void SeedingPeriod(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Period>().HasData(
                new Period
                {
                    Id = new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b"),
                    PeriodName = "Sáng",
                    Code = "MORNING",
                    StartTime = new TimeSpan(7, 0, 0)  // 7:00 AM


                },
                new Period
                {
                    Id = new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31"),
                    PeriodName = "Chiều",
                    Code = "AFTERNOON",
                    StartTime = new TimeSpan(14, 0, 0)  // 1:00 PM
                }
            );
        }

        public static void SeedingStudentType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentType>().HasData(
                new StudentType
                {
                    Id = new Guid("d5c14f0e-b4e9-4b88-b804-511bad973115"),
                    TypeName = "Học sinh",
                    Code = "NORMAL_STUDENT"
                },
                new StudentType
                {
                    Id = new Guid("cb440230-818a-4ad8-96de-3ae6c403b1ab"),
                    TypeName = "Lớp trưởng",
                    Code = "CLASS_MONITOR"
                },
                new StudentType
                {
                    Id = new Guid("468a8e7c-0ad1-465c-b570-5da68f276923"),
                    TypeName = "Lớp phó",
                    Code = "CLASS_VICE_MONITOR"
                }
            );
        }

        public static void SeedingTeacherType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherType>().HasData(
                 new TeacherType
                 {
                     Id = new Guid("a8afb982-710b-4637-bcc7-babeee1e0599"),
                     TypeName = "Giáo viên nhập liệu",
                     Code = "DATA_ENTRY_TEACHER"
                 },
                 new TeacherType
                 {
                     Id = new Guid("e5f785e3-4579-4465-b930-39b636a4d818"),
                     TypeName = "Giáo viên chủ nhiệm",
                     Code = "PRIMARY_TEACHER"
                 }
            );
        }

        public static void SeedingStatus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                 new Status
                 {
                     Id = new Guid("b16d2725-e2d4-47a8-8709-0c0c1ca3945d"),
                     StatusName = "Chưa điểm danh",
                     Code = "NOT_MARKED"
                 },
                 new Status
                 {
                     Id = new Guid("f60aaf45-9e88-4818-9ed0-3e8f83bfb66e"),
                     StatusName = "Có mặt",
                     Code = "ATTENDED"
                 },
                 new Status
                 {
                     Id = new Guid("ac6ff8a5-2017-402a-8966-9ce59146c689"),
                     StatusName = "Vắng mặt không phép",
                     Code = "ABSENTED_WITHOUT_PERMISSION"
                 },
                 new Status
                 {
                     Id = new Guid("3e04faa2-5c62-43c6-be78-01f114d01446"),
                     StatusName = "Vắng mặt có phép",
                     Code = "ABSENTED_WITH_PERMISSION"
                 }
            );
        }

        public static void SeedingGrade(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>().HasData(
                new Grade
                {
                    Id = new Guid("11f87b17-a80c-4420-b368-4680920bfe3d"),
                    GradeName = "10"
                },
                new Grade
                {
                    Id = new Guid("afa373a9-b9ab-4561-97b1-549b76f91190"),
                    GradeName = "11"
                },
                new Grade
                {
                    Id = new Guid("b6e0255a-aeee-4df7-8754-55dd27d360b2"),
                    GradeName = "12"
                }
            );
        }
        public static void SeedingClassroom(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classroom>().HasData(
                new Classroom
                {
                    Id = new Guid("f3bc74d1-04c8-47c9-b569-d9aaf268f195"),
                    ClassName = "10A1",
                    GradeId = new Guid("11f87b17-a80c-4420-b368-4680920bfe3d")

                },
                new Classroom
                {
                    Id = new Guid("d2a5a5a1-87c6-4714-bbfd-176571ebf89a"),
                    ClassName = "10A2",
                    GradeId = new Guid("11f87b17-a80c-4420-b368-4680920bfe3d")
                },
                new Classroom
                {
                    Id = new Guid("79dfe9dc-2b47-4222-bce2-7c85e91424d6"),
                    ClassName = "10A3",
                    GradeId = new Guid("11f87b17-a80c-4420-b368-4680920bfe3d")
                },
                new Classroom
                {
                    Id = new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"),
                    ClassName = "10A4",
                    GradeId = new Guid("11f87b17-a80c-4420-b368-4680920bfe3d")
                },
                new Classroom
                {
                    Id = new Guid("01c6d903-784d-45fb-8511-47e9d6ff7611"),
                    ClassName = "10A5",
                    GradeId = new Guid("11f87b17-a80c-4420-b368-4680920bfe3d")
                },
                new Classroom
                {
                    Id = new Guid("8f3cdace-270e-41bc-8ee5-0d07321c7975"),
                    ClassName = "11A1",
                    GradeId = new Guid("AFA373A9-B9AB-4561-97B1-549B76F91190")
                },
                new Classroom
                {
                    Id = new Guid("a71d8e2d-6e7d-44a5-a8be-cd9757f199be"),
                    ClassName = "11A2",
                    GradeId = new Guid("AFA373A9-B9AB-4561-97B1-549B76F91190")
                },
                new Classroom
                {
                    Id = new Guid("3df0676a-021e-4a1f-a082-fa88b6dbe200"),
                    ClassName = "11A3",
                    GradeId = new Guid("AFA373A9-B9AB-4561-97B1-549B76F91190")
                },
                new Classroom
                {
                    Id = new Guid("88660625-222d-48e7-bef7-aa2fae36d968"),
                    ClassName = "11A4",
                    GradeId = new Guid("AFA373A9-B9AB-4561-97B1-549B76F91190")
                },
                new Classroom
                {
                    Id = new Guid("c7235f3d-8414-4832-b0c5-a97781490a48"),
                    ClassName = "11A5",
                    GradeId = new Guid("AFA373A9-B9AB-4561-97B1-549B76F91190")
                },
                new Classroom
                {
                    Id = new Guid("11521ae4-fd95-474c-8d3e-e8ca3cbc21f3"),
                    ClassName = "12A1",
                    GradeId = new Guid("B6E0255A-AEEE-4DF7-8754-55DD27D360B2")
                },
                new Classroom
                {
                    Id = new Guid("ddd7dda5-a208-4ccc-947e-c96e603a4609"),
                    ClassName = "12A2",
                    GradeId = new Guid("B6E0255A-AEEE-4DF7-8754-55DD27D360B2")
                },
                new Classroom
                {
                    Id = new Guid("8fb55a60-4d64-4eb7-9ae1-4202cd25d9e2"),
                    ClassName = "12A3",
                    GradeId = new Guid("B6E0255A-AEEE-4DF7-8754-55DD27D360B2")
                },
                new Classroom
                {
                    Id = new Guid("7dbe0c01-40e0-4e8b-8112-0f4c01d6eb2f"),
                    ClassName = "12A4",
                    GradeId = new Guid("B6E0255A-AEEE-4DF7-8754-55DD27D360B2")
                },
                new Classroom
                {
                    Id = new Guid("9c62f26b-a825-4ee5-9c0a-09cd0aff7409"),
                    ClassName = "12A5",
                    GradeId = new Guid("B6E0255A-AEEE-4DF7-8754-55DD27D360B2")
                }
                ,
                new Classroom
                {
                    Id = new Guid("b4c997f3-3d75-4b63-bd19-7d849999481c"),
                    ClassName = "12A6",
                    GradeId = new Guid("B6E0255A-AEEE-4DF7-8754-55DD27D360B2")
                }
            );
        }

        public static void SeedingSubject(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = new Guid("107f7c24-e063-4dfd-beb8-d955e1fd0f8a"),
                    SubjectName = "Toán học",
                    Code = "MATHEMATICS"
                },
                 new Subject
                 {
                     Id = new Guid("50d08f10-a2b8-4119-8053-e95f00cdf608"),
                     SubjectName = "Ngữ văn",
                     Code = "LITERATURE"
                 },
                 new Subject
                 {
                     Id = new Guid("631135bd-81eb-4b70-a779-418af291d138"),
                     SubjectName = "Vật lý",
                     Code = "PHYSICS"
                 },
                 new Subject
                 {
                     Id = new Guid("94aa1b88-0fb0-4669-a7d7-73793e453e94"),
                     SubjectName = "Hóa học",
                     Code = "CHEMISTRY"
                 },
                 new Subject
                 {
                     Id = new Guid("669af09a-9f35-45b5-a2ce-1a9efbeeb476"),
                     SubjectName = "Sinh học",
                     Code = "BIOLOGY"
                 },
                 new Subject
                 {
                     Id = new Guid("77faf4ba-c356-4633-9505-91e4c8402800"),
                     SubjectName = "Lịch sử",
                     Code = "HISTORY"
                 },
                 new Subject
                 {
                     Id = new Guid("52e87219-4d5c-4d96-a944-a04292e2f617"),
                     SubjectName = "Địa lý",
                     Code = "GEOGRAPHY"
                 },
                 new Subject
                 {
                     Id = new Guid("ab569adc-c289-48ee-9286-73cd9863458e"),
                     SubjectName = "Giáo dục công dân",
                     Code = "CIVIC_EDUCATION"
                 },
                 new Subject
                 {
                     Id = new Guid("2a739d2f-6b40-4fe4-8cf3-6b2c47967a55"),
                     SubjectName = "Ngoại ngữ",
                     Code = "FOREIGN_LANGUAGE"
                 },
                 new Subject
                 {
                     Id = new Guid("0aaf283b-4d65-42af-a998-938efe370318"),
                     SubjectName = "Tin học",
                     Code = "INFORMATICS"
                 },
                 new Subject
                 {
                     Id = new Guid("7c756bba-6c1d-43db-8fb7-7c53295019a3"),
                     SubjectName = "Công nghệ",
                     Code = "TECHNOLOGY"
                 },
                 new Subject
                 {
                     Id = new Guid("4e943f72-a5ee-427f-9594-83598d33f411"),
                     SubjectName = "Thể dục",
                     Code = "PHYSICAL_EDUCATION"
                 },
                 new Subject
                 {
                     Id = new Guid("d3d41c42-c3b4-4713-b231-b2851634f378"),
                     SubjectName = "Âm nhạc",
                     Code = "MUSIC"
                 },
                 new Subject
                 {
                     Id = new Guid("9e777928-8399-4efe-bd19-164b1f6acc8e"),
                     SubjectName = "Mỹ thuật",
                     Code = "FINE_ART"
                 },
                 new Subject
                 {
                     Id = new Guid("a3d3b555-0cf4-4b41-8131-a4c205d9a6f3"),
                     SubjectName = "Giáo dục quốc phòng",
                     Code = "DEFENSE_EDUCATION"
                 },
                new Subject
                {
                    Id = new Guid("b1d3b555-0cf4-4b41-8131-a4c205d9a6f4"),
                    SubjectName = "SHDC",
                    Code = "SHDC"
                },
                new Subject
                {
                    Id = new Guid("c2d3b555-0cf4-4b41-8131-a4c205d9a6f5"),
                    SubjectName = "HĐTN-HN",
                    Code = "HDTN_HN"
                },
                new Subject
                {
                    Id = new Guid("d3d3b555-0cf4-4b41-8131-a4c205d9a6f6"),
                    SubjectName = "GDKT-PL",
                    Code = "GDKT_PL"
                },
                new Subject
                {
                    Id = new Guid("e4d3b555-0cf4-4b41-8131-a4c205d9a6f7"),
                    SubjectName = "SHCN",
                    Code = "SHCN"
                },
                new Subject
                {
                    Id = new Guid("f5d3b555-0cf4-4b41-8131-a4c205d9a6f8"),
                    SubjectName = "Toán Pháp",
                    Code = "MATH_FRENCH"
                }
            );
        }
        public static void SeedingSlot(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slot>().HasData(
                new Slot
                {
                    Id = new Guid("db1085ce-9ba3-4894-a8a0-d417bc6b0774"),
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(7, 45, 0),
                    SlotIndex = 1
                },
                new Slot
                {
                    Id = new Guid("0811126b-4fb3-4e29-b0f6-94b00bf0b98b"),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(8, 45, 0),
                    SlotIndex = 2
                },
                new Slot
                {
                    Id = new Guid("b2e5cc3b-f6f2-427e-9d9e-1f44ee8d2e80"),
                    StartTime = new TimeSpan(9, 05, 0),
                    EndTime = new TimeSpan(9, 50, 0),
                    SlotIndex = 3
                },
                new Slot
                {
                    Id = new Guid("e8b4217f-5a6c-4428-9901-99e62ce1f562"),
                    StartTime = new TimeSpan(9, 55, 0),
                    EndTime = new TimeSpan(10, 40, 0),
                    SlotIndex = 4
                },
                new Slot
                {
                    Id = new Guid("4ebda95f-f406-43d2-a88b-be2b1ddbe1b5"),
                    StartTime = new TimeSpan(10, 45, 0),
                    EndTime = new TimeSpan(11, 30, 0),
                    SlotIndex = 5
                },
                new Slot
                {
                    Id = new Guid("c5b67725-545f-4edd-8198-05bedcb5b00f"),
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(14, 45, 0),
                    SlotIndex = 6
                },
                new Slot
                {
                    Id = new Guid("9495ef71-051d-4e1b-9de3-31fa6d238252"),
                    StartTime = new TimeSpan(14, 55, 0),
                    EndTime = new TimeSpan(13, 40, 0),
                    SlotIndex = 7
                },
                new Slot
                {
                    Id = new Guid("79e57c6a-fae8-42b4-a460-b48447e3e076"),
                    StartTime = new TimeSpan(15, 50, 0),
                    EndTime = new TimeSpan(16, 35, 0),
                    SlotIndex = 8
                },
                new Slot
                {
                    Id = new Guid("e1e53de7-7170-46b4-8230-2790c42a7cac"),
                    StartTime = new TimeSpan(16, 45, 0),
                    EndTime = new TimeSpan(17, 30, 0),
                    SlotIndex = 9
                }
            );
        }

        public static void SeedingAdmins(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = new Guid("b584540e-49d9-4d45-bef4-f779f8e6c973"),
                    Username = "admin1",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    Email = "admin1@email.com",
                    RoleId = new Guid("04c92fd7-51b1-4852-8b8a-cacbe1511670")
                },
                new Admin
                {
                    Id = new Guid("5b909d16-c9e6-42bc-b46c-d766280d93b8"),
                    Username = "admin2",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    Email = "admin2@email.com",
                    RoleId = new Guid("04c92fd7-51b1-4852-8b8a-cacbe1511670")
                }
            );
        }

        public static void SeedingTeacher(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = new Guid("fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d"),
                    Username = "0912345678",
                    Phone = "0912345678",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Nguyễn Văn A",
                    Email = "nguyenvana@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900643/11_bnerzr.jpg",
                    TeacherTypeId = new Guid("A8AFB982-710B-4637-BCC7-BABEEE1E0599"),
                    RoleId = new Guid("81B3444C-C9FD-4EFC-A774-E1E3FC3C3E53"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3")
                },
                new Teacher
                {
                    Id = new Guid("493d052a-67a1-4428-981d-4d7831d3d344"),
                    Username = "0987654321",
                    Phone = "0987654321",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Trần Thị B",
                    Email = "tranthib@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900643/z5852812999947_cb79c443d7ad6df3917b4a48111e4158_bpsx1v.jpg",
                    TeacherTypeId = new Guid("A8AFB982-710B-4637-BCC7-BABEEE1E0599"),
                    RoleId = new Guid("81B3444C-C9FD-4EFC-A774-E1E3FC3C3E53"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3")
                },
                new Teacher
                {
                    Id = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                    Username = "0901234567",
                    Phone = "0901234567",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Lê Minh C",
                    Email = "leminhc@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900642/10_bpqux3.jpg",
                    TeacherTypeId = new Guid("A8AFB982-710B-4637-BCC7-BABEEE1E0599"),
                    RoleId = new Guid("81B3444C-C9FD-4EFC-A774-E1E3FC3C3E53"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3")
                },
                new Teacher
                {
                    Id = new Guid("b2c3d4e5-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
                    Username = "0934567890",
                    Phone = "0934567890",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Phạm Thị D",
                    Email = "phamthid@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900642/9_l4nqzj.jpg",
                    TeacherTypeId = new Guid("A8AFB982-710B-4637-BCC7-BABEEE1E0599"),
                    RoleId = new Guid("81B3444C-C9FD-4EFC-A774-E1E3FC3C3E53"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3")
                },
                new Teacher
                {
                    Id = new Guid("c3d4e5f6-7a8b-9c0d-1e2f-3a4b5c6d7e8f"),
                    Username = "0976543210",
                    Phone = "0976543210",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Hoàng Văn E",
                    Email = "hoangvane@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900642/1_pcvqfn.jpg",
                    TeacherTypeId = new Guid("A8AFB982-710B-4637-BCC7-BABEEE1E0599"),
                    RoleId = new Guid("81B3444C-C9FD-4EFC-A774-E1E3FC3C3E53"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3")
                }
            );

        }

        public static void SeedingStudent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                  new Student
                  {
                      Id = Guid.NewGuid(),
                      PublicStudentID = "MCU101",
                      Username = "MCU101",
                      Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                      FullName = "Nguyễn Văn A",
                      Email = "nguyen.a@example.com",
                      Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/7_plw6ns.jpg",
                      StudentTypeId = new Guid("D5C14F0E-B4E9-4B88-B804-511BAD973115"),
                      ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3"),
                      RoleId = new Guid("01E27B7C-93CA-47F6-A09B-C7015717E2ED")
                  },
                new Student
                {
                    Id = Guid.NewGuid(),
                    PublicStudentID = "MCU102",
                    Username = "MCU102",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Trần Thị B",
                    Email = "tran.b@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/6_ydar9m.jpg",
                    StudentTypeId = new Guid("D5C14F0E-B4E9-4B88-B804-511BAD973115"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3"),
                    RoleId = new Guid("01E27B7C-93CA-47F6-A09B-C7015717E2ED")
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    PublicStudentID = "MCU103",
                    Username = "MCU103",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Lê Văn C",
                    Email = "le.c@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813026004_885e224ee4b8dbfbb128e583c278a615_dicbrf.jpg",
                    StudentTypeId = new Guid("D5C14F0E-B4E9-4B88-B804-511BAD973115"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3"),
                    RoleId = new Guid("01E27B7C-93CA-47F6-A09B-C7015717E2ED")
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    PublicStudentID = "MCU104",
                    Username = "MCU104",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Phạm Thị D",
                    Email = "pham.d@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/5_ek2pks.jpg",
                    StudentTypeId = new Guid("D5C14F0E-B4E9-4B88-B804-511BAD973115"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3"),
                    RoleId = new Guid("01E27B7C-93CA-47F6-A09B-C7015717E2ED")
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    PublicStudentID = "MCU105",
                    Username = "MCU105",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Hoàng Văn E",
                    Email = "hoang.e@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900641/z5852813011522_e3396b099fec5e01dc56a2331b757d8e_nsrnzc.jpg",
                    StudentTypeId = new Guid("D5C14F0E-B4E9-4B88-B804-511BAD973115"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3"),
                    RoleId = new Guid("01E27B7C-93CA-47F6-A09B-C7015717E2ED")
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    PublicStudentID = "MCU106",
                    Username = "MCU106",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Vũ Thị F",
                    Email = "vu.f@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/2_hlwinq.jpg",
                    StudentTypeId = new Guid("D5C14F0E-B4E9-4B88-B804-511BAD973115"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3"),
                    RoleId = new Guid("01E27B7C-93CA-47F6-A09B-C7015717E2ED")
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    PublicStudentID = "MCU107",
                    Username = "MCU107",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Đỗ Văn G",
                    Email = "do.g@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/z5852813019059_6493ca13ee06ac935e9889fe51bd2886_ooz29c.jpg",
                    StudentTypeId = new Guid("D5C14F0E-B4E9-4B88-B804-511BAD973115"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3"),
                    RoleId = new Guid("01E27B7C-93CA-47F6-A09B-C7015717E2ED")
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    PublicStudentID = "MCU108",
                    Username = "MCU108",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Bùi Thị H",
                    Email = "bui.h@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/13_gqcowy.jpg",
                    StudentTypeId = new Guid("D5C14F0E-B4E9-4B88-B804-511BAD973115"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3"),
                    RoleId = new Guid("01E27B7C-93CA-47F6-A09B-C7015717E2ED")
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    PublicStudentID = "MCU109",
                    Username = "MCU109",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Ngô Văn I",
                    Email = "ngo.i@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900640/4_yr3kyt.jpg",
                    StudentTypeId = new Guid("D5C14F0E-B4E9-4B88-B804-511BAD973115"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3"),
                    RoleId = new Guid("01E27B7C-93CA-47F6-A09B-C7015717E2ED")
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    PublicStudentID = "MCU110",
                    Username = "MCU110",
                    Password = "$2y$06$usOR86Leu51BU3l2hmdjOeUBTmtJTG6OcFlFUZIwTiDtNcrGrdp22",
                    FullName = "Đặng Thị K",
                    Email = "dang.k@example.com",
                    Image = "https://res.cloudinary.com/duxrv1jlj/image/upload/v1726900639/12_wsmqha.jpg",
                    StudentTypeId = new Guid("D5C14F0E-B4E9-4B88-B804-511BAD973115"),
                    ClassroomId = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3"),
                    RoleId = new Guid("01E27B7C-93CA-47F6-A09B-C7015717E2ED")
                }
            );
        }

        public static void SeedingSession(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>().HasData(
                              new Session
                              {
                                  Id = new Guid("6fa3d575-2f46-4615-aa63-ab53dc32bd8b"),
                                  DayOfWeek = 1,
                                  PeriodID = new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b")
                              },
                              new Session
                              {
                                  Id = new Guid("32f10e78-2737-4cab-a74a-f7986f1c5bca"),
                                  DayOfWeek = 1,
                                  PeriodID = new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31")
                              },
                                new Session
                                {
                                    Id = new Guid("02505d8c-8c01-4734-b79c-a053e9c86f9d"),
                                    DayOfWeek = 2,
                                    PeriodID = new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b")
                                },
                              new Session
                              {
                                  Id = new Guid("55987953-39cd-43f7-84ee-84b79170e7fd"),
                                  DayOfWeek = 2,
                                  PeriodID = new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31")
                              },
                                new Session
                                {
                                    Id = new Guid("6c6b00cc-1030-4029-aaf5-299019bd303d"),
                                    DayOfWeek = 3,
                                    PeriodID = new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b")
                                },
                              new Session
                              {
                                  Id = new Guid("6be09935-4ba1-42e2-9ccc-ab66fe1569a3"),
                                  DayOfWeek = 3,
                                  PeriodID = new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31")
                              },
                                new Session
                                {
                                    Id = new Guid("2246a4b5-1dc9-4b8b-a6ea-f4e3d2635249"),
                                    DayOfWeek = 4,
                                    PeriodID = new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b")
                                },
                              new Session
                              {
                                  Id = new Guid("c1188b95-fcb3-4d83-8ac0-04c0f26fbb3d"),
                                  DayOfWeek = 4,
                                  PeriodID = new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31")
                              },
                                new Session
                                {
                                    Id = new Guid("5abe297f-e351-4939-bded-ec538c595417"),
                                    DayOfWeek = 5,
                                    PeriodID = new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b")
                                },
                              new Session
                              {
                                  Id = new Guid("d1f42050-c53b-45bf-8473-ebc14c01d4b7"),
                                  DayOfWeek = 5,
                                  PeriodID = new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31")
                              },
                                new Session
                                {
                                    Id = new Guid("b53c2d5c-bc63-4c0d-84c7-d3a69073879c"),
                                    DayOfWeek = 6,
                                    PeriodID = new Guid("064eaf1f-a520-4eda-b179-a2c38811ad0b")
                                },
                              new Session
                              {
                                  Id = new Guid("32196bfb-4117-4fc7-a0d7-7c2751544d1e"),
                                  DayOfWeek = 6,
                                  PeriodID = new Guid("2b5e92f3-430b-4b48-8048-ca2ca8d0ef31")
                              }
                              );
        }
    }
}
