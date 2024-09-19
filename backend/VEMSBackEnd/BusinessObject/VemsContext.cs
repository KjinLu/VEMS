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
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceCharge> AttendanceCharges { get; set; }
        public DbSet<AttendanceStatus> AttendanceStatuses { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleDetail> scheduleDetails { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<SlotDetail> SlotDetails { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentType> StudentTypes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherType> TeacherTypes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=THANHDUONG03\\DUONGNT;User ID=sa;Password=1;Database=VEMS;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Attendance>().ToTable("Attendance");
            modelBuilder.Entity<AttendanceCharge>().ToTable("AttendanceCharge");
            modelBuilder.Entity<AttendanceStatus>().ToTable("AttendanceStatus");
            modelBuilder.Entity<Classroom>().ToTable("Classroom");
            modelBuilder.Entity<Device>().ToTable("Device");
            modelBuilder.Entity<Grade>().ToTable("Grade");
            modelBuilder.Entity<Period>().ToTable("Period");
            modelBuilder.Entity<Reason>().ToTable("Reason");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Schedule>().ToTable("Schedule");
            modelBuilder.Entity<ScheduleDetail>().ToTable("ScheduleDetail");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<StudentType>().ToTable("StudentType");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<TeacherType>().ToTable("TeacherType");

            //modelBuilder.Entity<Admin>()
            //  .HasOne(a => a.Role)
            //  .WithMany(r => r.Admins)
            //  .HasForeignKey(a => a.RoleId);
        }
    }
}
