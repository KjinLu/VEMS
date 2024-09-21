using BusinessObject.Seeding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
  public class VemsContext : DbContext
  {

    public VemsContext() : base()
    {
    }

    public VemsContext(DbContextOptions<VemsContext> options) : base(options)
    {
    }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Period> Periods { get; set; }
    public DbSet<Reason> Reasons { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Slot> Slots { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentType> studentTypes { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<TeacherType> TeacherTypes { get; set; }
    public DbSet<ScheduleDetail> ScheduleDetails { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<AttendanceCharge> AttendanceCharges { get; set; }
    public DbSet<AttendanceStatus> AttendanceStatuses { get; set; }
    public DbSet<SlotDetail> SlotDetails { get; set; }
    public DbSet<EmailToken> EmailTokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=THANHDUONG03\\DUONGNT;User ID=sa;Password=1;Database=VEMS;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
      {
        relationship.DeleteBehavior = DeleteBehavior.Restrict;
      }

      modelBuilder.SeedingRole();
      modelBuilder.SeedingReason();
      modelBuilder.SeedingPeriod();
      modelBuilder.SeedingGrade();
      modelBuilder.SeedingStudentType();
      modelBuilder.SeedingTeacherType();
      modelBuilder.SeedingStatus();
      modelBuilder.SeedingSubject();
      modelBuilder.SeedingSlot();

      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Admin>()
            .HasOne(a => a.Role)
            .WithMany(r => r.Admins)
            .HasForeignKey(a => a.RoleId);

      modelBuilder.Entity<Classroom>()
             .HasOne(a => a.Grade)
             .WithMany(r => r.Classrooms)
             .HasForeignKey(a => a.GradeId);

      modelBuilder.Entity<Session>()
            .HasOne(a => a.Period)
            .WithMany(r => r.Sessions)
            .HasForeignKey(a => a.PeriodID);

      modelBuilder.Entity<Teacher>()
           .HasOne(a => a.TeacherType)
           .WithMany(r => r.Teachers)
           .HasForeignKey(a => a.TeacherTypeId);

      modelBuilder.Entity<Teacher>()
            .HasOne(a => a.Role)
            .WithMany(r => r.Teachers)
            .HasForeignKey(a => a.RoleId);

      modelBuilder.Entity<Student>()
           .HasOne(a => a.Role)
           .WithMany(r => r.Students)
           .HasForeignKey(a => a.RoleId);

      modelBuilder.Entity<Student>()
           .HasOne(a => a.Classroom)
           .WithMany(r => r.Students)
           .HasForeignKey(a => a.ClassroomId);

      modelBuilder.Entity<Schedule>()
          .HasOne(a => a.Classroom)
          .WithMany(r => r.Schedules)
          .HasForeignKey(a => a.ClassroomId);

      modelBuilder.Entity<ScheduleDetail>()
          .HasOne(a => a.Session)
          .WithMany(r => r.ScheduleDetails)
          .HasForeignKey(a => a.SessionId);

      modelBuilder.Entity<ScheduleDetail>()
         .HasOne(a => a.Schedule)
         .WithMany(r => r.ScheduleDetails)
         .HasForeignKey(a => a.ScheduleId);

      modelBuilder.Entity<Attendance>()
         .HasOne(a => a.ScheduleDetail)
         .WithMany(r => r.Attendances)
         .HasForeignKey(a => a.ScheduleDetailId);

      modelBuilder.Entity<AttendanceCharge>()
        .HasOne(a => a.Student)
        .WithMany(r => r.AttendanceCharges)
        .HasForeignKey(a => a.StudentId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<AttendanceCharge>()
        .HasOne(a => a.Attendance)
        .WithMany(r => r.AttendanceCharges)
        .HasForeignKey(a => a.AttendanceId)
        .OnDelete(DeleteBehavior.Cascade);


      modelBuilder.Entity<AttendanceStatus>()
         .HasOne(a => a.Attendance)
         .WithMany(r => r.AttendanceStatuses)
         .HasForeignKey(a => a.AttendanceId);

      modelBuilder.Entity<AttendanceStatus>()
          .HasOne(a => a.Status)
          .WithMany(r => r.AttendanceStatuses)
          .HasForeignKey(a => a.StatusId);

      modelBuilder.Entity<AttendanceStatus>()
          .HasOne(a => a.Reason)
          .WithMany(r => r.AttendanceStatuses)
          .HasForeignKey(a => a.ReasonId);

      modelBuilder.Entity<AttendanceStatus>()
          .HasOne(a => a.Teacher)
          .WithMany(r => r.AttendanceStatuses)
          .HasForeignKey(a => a.TeacherId);

      modelBuilder.Entity<SlotDetail>()
         .HasOne(a => a.Slot)
         .WithMany(r => r.SlotDetails)
         .HasForeignKey(a => a.SlotID);

      modelBuilder.Entity<SlotDetail>()
        .HasOne(a => a.Teacher)
        .WithMany(r => r.SlotDetails)
        .HasForeignKey(a => a.TeacherID);

      modelBuilder.Entity<SlotDetail>()
         .HasOne(a => a.Subject)
         .WithMany(r => r.SlotDetails)
         .HasForeignKey(a => a.SubjectID);

      modelBuilder.Entity<SlotDetail>()
        .HasOne(a => a.Session)
        .WithMany(r => r.SlotDetails)
        .HasForeignKey(a => a.SessionID);


      modelBuilder.SeedingClassroom();
      modelBuilder.SeedingAdmins();
      modelBuilder.SeedingStudent();
      modelBuilder.SeedingTeacher();
    }
  }
}
