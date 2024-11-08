﻿using Azure.Core;
using BusinessObject;
using DataAccess.Dto.ClassroomDto;
using DataAccess.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess.DAO
{


    public class AccountDAO
    {
        private static readonly object InstanceLock = new object();
        private static AccountDAO instance = null;

        public static AccountDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<List<Admin>> GetAllAdminAsync()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Admins.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Admin> GetAdminByIdAsync(Guid id)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return await context.Admins.FirstOrDefaultAsync(admin => admin.Id == id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Admin> GetAdminByUsernameAsync(string username)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return await context.Admins.FirstOrDefaultAsync(admin => admin.Username == username);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Admin> GetAdminByEmailAsync(string email)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return await context.Admins.FirstOrDefaultAsync(admin => admin.Email == email);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<StudentResponse>> GetAllStudentAsync()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Students
                        .Include(s => s.Classroom) // Bao gồm Classroom
                        .Include(s => s.StudentType) // Bao gồm StudentType
                        .Select(s => new StudentResponse
                        {
                            Id = s.Id,
                            PublicStudentID = s.PublicStudentID,
                            FullName = s.FullName,
                            CitizenID = s.CitizenID,
                            Username = s.Username,
                            Password = s.Password, // Chỉ nên trả về khi cần thiết
                            Email = s.Email,
                            Dob = s.Dob,
                            Address = s.Address,
                            Image = s.Image,
                            Phone = s.Phone,
                            ParentPhone = s.ParentPhone,
                            HomeTown = s.HomeTown,
                            UnionJoinDate = s.UnionJoinDate,
                            StudentTypeName = s.StudentType.TypeName,
                            ClassRoom = s.Classroom.ClassName
                        })
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Student> GetStudentByIdAsync(Guid id)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return await context.Students.AsNoTracking().FirstOrDefaultAsync(student => student.Id == id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Student> GetStudentByUsernameAsync(string username)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return await context.Students.FirstOrDefaultAsync(student => student.Username == username);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return await context.Students.FirstOrDefaultAsync(student => student.Email == email);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TeacherResponse>> GetAllTeacherAsync()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Teacher
               .Include(t => t.TeacherType) // Nếu cần, bao gồm TeacherType
               .Include(t => t.Classroom) // Nếu cần, bao gồm Classroom
               .Select(t => new TeacherResponse
               {
                   Id = t.Id,
                   PublicTeacherID = t.PublicTeacherID,
                   FullName = t.FullName,
                   CitizenID = t.CitizenID,
                   Username = t.Username,
                   Email = t.Email,
                   Dob = t.Dob,
                   Address = t.Address,
                   Image = t.Image,
                   Phone = t.Phone,
                   TeacherTypeName = t.TeacherType.TypeName,
                   ClassRoom = t.Classroom.ClassName
               })
               .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Teacher> GetTeacherByIdAsync(Guid id)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return await context.Teacher.FirstOrDefaultAsync(teacher => teacher.Id == id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Teacher> GetTeacherByUsernameAsync(string username)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return await context.Teacher.FirstOrDefaultAsync(teacher => teacher.Username == username);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Teacher> GetTeacherByEmailAsync(string email)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return await context.Teacher.FirstOrDefaultAsync(teacher => teacher.Email == email);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CommonAccountType> GetAccountByEmailAsync(string email)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    var admin = await (from a in context.Admins
                                       join r in context.Roles on a.RoleId equals r.Id
                                       where a.Email == email
                                       select new
                                       {
                                           AccountID = a.Id,
                                           Username = a.Username,
                                           Password = a.Password,
                                           Email = a.Email,
                                           RefreshToken = a.RefreshToken,
                                           RoleID = r.Id,
                                           RoleName = r.Code
                                       }).FirstOrDefaultAsync();


                    if (admin != null) return new CommonAccountType
                    {
                        AccountID = admin.AccountID,
                        Email = admin.Email,
                        RefreshToken = admin.RefreshToken,
                        Password = admin.Password,
                        RoleID = admin.RoleID,
                        RoleName = admin.RoleName,
                        Username = admin.Username

                    };

                    var teacher = await (from a in context.Teacher
                                         join r in context.Roles on a.RoleId equals r.Id
                                         where a.Email == email
                                         select new
                                         {
                                             AccountID = a.Id,
                                             Username = a.Username,
                                             Password = a.Password,
                                             Image = a.Image,
                                             Email = a.Email,
                                             RefreshToken = a.RefreshToken,
                                             RoleID = r.Id,
                                             RoleName = r.Code
                                         }).FirstOrDefaultAsync();

                    if (teacher != null) return new CommonAccountType
                    {
                        AccountID = teacher.AccountID,
                        Email = teacher.Email,
                        RefreshToken = teacher.RefreshToken,
                        Password = teacher.Password,
                        Image = teacher.Image,
                        RoleID = teacher.RoleID,
                        RoleName = teacher.RoleName,
                        Username = teacher.Username

                    };

                    var student = await (from a in context.Students
                                         join r in context.Roles on a.RoleId equals r.Id
                                         where a.Email == email
                                         select new
                                         {
                                             AccountID = a.Id,
                                             Username = a.Username,
                                             Password = a.Password,
                                             Email = a.Email,
                                             RefreshToken = a.RefreshToken,
                                             Image = a.Image,
                                             RoleID = r.Id,
                                             RoleName = r.Code

                                         }).FirstOrDefaultAsync();

                    if (student != null) return new CommonAccountType
                    {
                        AccountID = student.AccountID,
                        Email = student.Email,
                        RefreshToken = student.RefreshToken,
                        Password = student.Password,
                        Image = student.Image,
                        RoleID = student.RoleID,
                        RoleName = student.RoleName,
                        Username = student.Username


                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CommonAccountType> GetAccountByIDAsync(Guid accountID)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    var admin = await (from a in context.Admins
                                       join r in context.Roles on a.RoleId equals r.Id
                                       where a.Id == accountID
                                       select new
                                       {
                                           AccountID = a.Id,
                                           Username = a.Username,
                                           Password = a.Password,
                                           Email = a.Email,
                                           RefreshToken = a.RefreshToken,
                                           RoleID = r.Id,
                                           RoleName = r.Code
                                       }).FirstOrDefaultAsync();


                    if (admin != null) return new CommonAccountType
                    {
                        AccountID = admin.AccountID,
                        Email = admin.Email,
                        RefreshToken = admin.RefreshToken,
                        Password = admin.Password,
                        RoleID = admin.RoleID,
                        RoleName = admin.RoleName,
                        Username = admin.Username

                    };

                    var teacher = await (from a in context.Teacher
                                         join r in context.Roles on a.RoleId equals r.Id
                                         join t in context.TeacherTypes on a.TeacherTypeId equals t.Id
                                         where a.Id == accountID
                                         select new
                                         {
                                             AccountID = a.Id,
                                             Username = a.Username,
                                             Password = a.Password,
                                             Image = a.Image,
                                             Email = a.Email,
                                             RefreshToken = a.RefreshToken,
                                             RoleID = r.Id,
                                             RoleName = r.Code,
                                             TeacherType = t.Code,
                                             FullName = a.FullName,
                                             ClassID = a.ClassroomId,
                                         }).FirstOrDefaultAsync();

                    if (teacher != null) return new CommonAccountType
                    {
                        AccountID = teacher.AccountID,
                        Email = teacher.Email,
                        RefreshToken = teacher.RefreshToken,
                        Password = teacher.Password,
                        RoleID = teacher.RoleID,
                        RoleName = teacher.RoleName,
                        Username = teacher.Username,
                        Image = teacher.Image,
                        FullName = teacher.FullName,
                        TeacherType = teacher.TeacherType,
                        ClassroomID = teacher.ClassID,
                    };

                    var student = await (from a in context.Students
                                         join r in context.Roles on a.RoleId equals r.Id
                                         join c in context.Classrooms on a.ClassroomId equals c.Id
                                         join t in context.studentTypes on a.StudentTypeId equals t.Id
                                         where a.Id == accountID
                                         select new
                                         {
                                             AccountID = a.Id,
                                             Username = a.Username,
                                             Password = a.Password,
                                             Email = a.Email,
                                             RefreshToken = a.RefreshToken,
                                             RoleID = r.Id,
                                             RoleName = r.Code,
                                             ClassroomID = a.ClassroomId,
                                             ClassroomName = c.ClassName,
                                             FullName = a.FullName,
                                             StudentType = t.Code,
                                             Image = a.Image,

                                         }).FirstOrDefaultAsync();

                    if (student != null) return new CommonAccountType
                    {
                        AccountID = student.AccountID,
                        Email = student.Email,
                        RefreshToken = student.RefreshToken,
                        Password = student.Password,
                        RoleID = student.RoleID,
                        RoleName = student.RoleName,
                        Username = student.Username,
                        ClassroomID = student.ClassroomID,
                        FullName = student.FullName,
                        StudentType = student.StudentType,
                        Image = student.Image
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CommonAccountType> GetAccountByUsernameAsync(string username)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    var admin = await (from a in context.Admins
                                       join r in context.Roles on a.RoleId equals r.Id
                                       where a.Username == username
                                       select new
                                       {
                                           AccountID = a.Id,
                                           Username = a.Username,
                                           Password = a.Password,
                                           Email = a.Email,
                                           RefreshToken = a.RefreshToken,
                                           RoleID = r.Id,
                                           RoleName = r.Code
                                       }).FirstOrDefaultAsync();


                    if (admin != null) return new CommonAccountType
                    {
                        AccountID = admin.AccountID,
                        Email = admin.Email,
                        RefreshToken = admin.RefreshToken,
                        Password = admin.Password,
                        RoleID = admin.RoleID,
                        RoleName = admin.RoleName,
                        Username = admin.Username

                    };

                    var teacher = await (from a in context.Teacher
                                         join r in context.Roles on a.RoleId equals r.Id
                                         where a.Username == username
                                         select new
                                         {
                                             AccountID = a.Id,
                                             Username = a.Username,
                                             Password = a.Password,
                                             Image = a.Image,
                                             Email = a.Email,
                                             RefreshToken = a.RefreshToken,
                                             RoleID = r.Id,
                                             RoleName = r.Code
                                         }).FirstOrDefaultAsync();

                    if (teacher != null) return new CommonAccountType
                    {
                        AccountID = teacher.AccountID,
                        Email = teacher.Email,
                        RefreshToken = teacher.RefreshToken,
                        Password = teacher.Password,
                        Image = teacher.Image,
                        RoleID = teacher.RoleID,
                        RoleName = teacher.RoleName,
                        Username = teacher.Username

                    };

                    var student = await (from a in context.Students
                                         join r in context.Roles on a.RoleId equals r.Id
                                         where a.Username == username
                                         select new
                                         {
                                             AccountID = a.Id,
                                             Username = a.Username,
                                             Password = a.Password,
                                             Email = a.Email,
                                             RefreshToken = a.RefreshToken,
                                             Image = a.Image,
                                             RoleID = r.Id,
                                             RoleName = r.Code,
                                             ClassID = a.ClassroomId,
                                         }).FirstOrDefaultAsync();

                    if (student != null) return new CommonAccountType
                    {
                        AccountID = student.AccountID,
                        Email = student.Email,
                        RefreshToken = student.RefreshToken,
                        Password = student.Password,
                        Image = student.Image,
                        RoleID = student.RoleID,
                        RoleName = student.RoleName,
                        Username = student.Username,
                        ClassroomID = student.ClassID,

                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateRefreshTokenAsync(Guid AccountId, string token)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    var admin = await context.Admins.SingleOrDefaultAsync(admin => admin.Id == AccountId);
                    if (admin != null)
                    {
                        admin.RefreshToken = token;
                        context.Entry<Admin>(admin).State = EntityState.Modified;
                        context.SaveChanges();
                        return true;
                    }

                    var teacher = await context.Teacher.SingleOrDefaultAsync(teacher => teacher.Id == AccountId);
                    if (teacher != null)
                    {
                        teacher.RefreshToken = token;
                        context.Entry<Teacher>(teacher).State = EntityState.Modified;
                        context.SaveChanges();
                        return true;
                    }

                    var student = await context.Students.SingleOrDefaultAsync(student => student.Id == AccountId);
                    if (student != null)
                    {
                        student.RefreshToken = token;
                        context.Entry<Student>(student).State = EntityState.Modified;
                        context.SaveChanges();
                        return true;
                    }
                }
                return false;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Student>> RegisterStudentAsync(List<Student> requests)
        {
            try
            {
                List<Student> registeredStudents = new List<Student>();

                using (var context = new VemsContext())
                {
                    foreach (var request in requests)
                    {
                        var checkStudentUsername = await context.Students
                            .FirstOrDefaultAsync(s => s.Username == request.PublicStudentID);

                        if (checkStudentUsername != null)
                        {
                            // Skip this student if the username is already used
                            continue;
                        }
                        var studentCreated = context.Students.Add(request).Entity;
                        registeredStudents.Add(studentCreated);
                    }

                    await context.SaveChangesAsync();
                }

                return registeredStudents;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Teacher>> RegisterTeacherAsync(List<Teacher> requests)
        {
            try
            {
                List<Teacher> registeredTeachers = new List<Teacher>();

                using (var context = new VemsContext())
                {
                    foreach (var request in requests)
                    {
                        var checkPhoneNumber = await context.Teacher
                            .FirstOrDefaultAsync(s => s.Username == request.Phone);

                        if (checkPhoneNumber != null)
                        {
                            continue;
                        }
                        var teacherCreated = context.Teacher.Add(request).Entity;
                        registeredTeachers.Add(teacherCreated);
                    }
                    await context.SaveChangesAsync();
                }
                return registeredTeachers;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> ChangePassword(Guid AccountId, string newPassword)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    var admin = await context.Admins.SingleOrDefaultAsync(admin => admin.Id == AccountId);
                    if (admin != null)
                    {
                        admin.Password = newPassword;
                        context.Entry<Admin>(admin).State = EntityState.Modified;
                        context.SaveChanges();
                        return true;
                    }

                    var teacher = await context.Teacher.SingleOrDefaultAsync(teacher => teacher.Id == AccountId);
                    if (teacher != null)
                    {
                        teacher.Password = newPassword;
                        context.Entry<Teacher>(teacher).State = EntityState.Modified;
                        context.SaveChanges();
                        return true;
                    }

                    var student = await context.Students.SingleOrDefaultAsync(student => student.Id == AccountId);
                    if (student != null)
                    {
                        student.Password = newPassword;
                        context.Entry<Student>(student).State = EntityState.Modified;
                        context.SaveChanges();
                        return true;
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Student> CreateAStudentAccount(Student student)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var checkStudentUsername = await context.Students
                        .FirstOrDefaultAsync(s => s.Username == student.Username);

                    if (checkStudentUsername != null)
                    {
                        throw new Exception("Tên đăng nhập đã được sử dụng!");
                    }
                    var studentCreated = context.Students.Add(student).Entity;
                    await context.SaveChangesAsync();
                    return studentCreated;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi tạo tài khoản!");
            }
        }

        public async Task<bool> UpdateStudentProfile(Student student)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var dbStudent = await context.Students.AsNoTracking()
                        .FirstOrDefaultAsync(s => s.Id == student.Id);

                    if (dbStudent == null) throw new Exception("Thông tin tài khoản không tồn tại!");

                    context.Entry<Student>(student).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi cập nhật tài khoản!");
            }
        }

        public async Task<Teacher> CreateATeacherAccount(Teacher teacher)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var checkStudentUsername = await context.Teacher
                        .FirstOrDefaultAsync(s => s.Username == teacher.Username);

                    if (checkStudentUsername != null)
                    {
                        throw new Exception("Tên đăng nhập đã được sử dụng!");
                    }
                    var teacherCreated = context.Teacher.Add(teacher).Entity;
                    await context.SaveChangesAsync();
                    return teacherCreated;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi tạo tài khoản!");
            }
        }

        public async Task<bool> UpdateTeacherProfile(Teacher teacher)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var dbStudent = await context.Teacher.AsNoTracking()
                        .FirstOrDefaultAsync(s => s.Id == teacher.Id);

                    if (dbStudent == null) throw new Exception("Thông tin tài khoản không tồn tại!");

                    context.Entry<Teacher>(teacher).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi cập nhật tài khoản!");
            }
        }

        public async Task<bool> UpdateAvatarAsync(Guid AccountId, string imageLink)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {

                    var teacher = await context.Teacher.SingleOrDefaultAsync(teacher => teacher.Id == AccountId);
                    if (teacher != null)
                    {
                        teacher.Image = imageLink;
                        context.Entry<Teacher>(teacher).State = EntityState.Modified;
                        context.SaveChanges();
                        return true;
                    }

                    var student = await context.Students.SingleOrDefaultAsync(student => student.Id == AccountId);
                    if (student != null)
                    {
                        student.Image = imageLink;
                        context.Entry<Student>(student).State = EntityState.Modified;
                        context.SaveChanges();
                        return true;
                    }
                }
                return false;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Lấy teacher theo Id
        public async Task<TeacherResponse?> GetTeacherProfileByIdAsync(Guid id)
        {
            try
            {
                var _context = new VemsContext();
                var teacherResponse = await (from teacher in _context.Teacher
                                             join classroom in _context.Classrooms on teacher.ClassroomId equals classroom.Id into classLeftJoin
                                             from classroom in classLeftJoin.DefaultIfEmpty()
                                             join teacherType in _context.TeacherTypes on teacher.TeacherTypeId equals teacherType.Id
                                             where teacher.Id == id
                                             select new TeacherResponse
                                             {
                                                 Id = teacher.Id,
                                                 PublicTeacherID = teacher.PublicTeacherID,
                                                 FullName = teacher.FullName,
                                                 CitizenID = teacher.CitizenID,
                                                 Username = teacher.Username,
                                                 Password = teacher.Password,
                                                 Email = teacher.Email,
                                                 Dob = teacher.Dob,
                                                 Address = teacher.Address,
                                                 Image = teacher.Image,
                                                 Phone = teacher.Phone,
                                                 TeacherTypeName = teacherType.TypeName,
                                                 ClassRoom = classroom.ClassName
                                             }).AsNoTracking().FirstOrDefaultAsync().ConfigureAwait(false);

                return teacherResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy học sinh theo Id: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateTeacherHomeRoom(UpdateTeacherHomeroomRequest teacherHomeroom)
        {
            using (var context = new VemsContext())
            {
                if (string.IsNullOrEmpty(teacherHomeroom.ClassId))
                {
                    var dbTeacher = await context.Teacher.AsNoTracking()
                        .FirstOrDefaultAsync(s => s.Id == teacherHomeroom.TeacherId);

                    if (dbTeacher != null)
                    {
                        if (dbTeacher.ClassroomId != null)
                        {
                            dbTeacher.ClassroomId = null;
                            dbTeacher.TeacherTypeId = await context.TeacherTypes
                                .Where(tt => tt.Code == "DATA_ENTRY_TEACHER")
                                .Select(tt => tt.Id)
                                .FirstOrDefaultAsync();

                            context.Entry(dbTeacher).State = EntityState.Modified;
                            await context.SaveChangesAsync();
                        }
                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Không tìm thấy giáo viên với ID {teacherHomeroom.TeacherId}");
                    }
                }

                // Chuyển đổi ClassId thành Guid
                var classId = new Guid(teacherHomeroom.ClassId);

                var className = await context.Classrooms
                    .Where(c => c.Id == classId)
                    .Select(c => c.ClassName)
                    .FirstOrDefaultAsync();

                if (className != null)
                {
                    var exists = await context.Teacher
                        .AnyAsync(t => t.ClassroomId == classId);

                    if (!exists)
                    {
                        var dbTeacher = await context.Teacher.AsNoTracking()
                            .FirstOrDefaultAsync(s => s.Id == teacherHomeroom.TeacherId);

                        if (dbTeacher != null)
                        {
                            dbTeacher.ClassroomId = classId;
                            dbTeacher.TeacherTypeId = await context.TeacherTypes
                                .Where(tt => tt.Code == "PRIMARY_TEACHER")
                                .Select(tt => tt.Id)
                                .FirstOrDefaultAsync();

                            context.Entry(dbTeacher).State = EntityState.Modified;
                            await context.SaveChangesAsync();
                            return true;
                        }
                        else
                        {
                            throw new InvalidOperationException($"Không tìm thấy giáo viên với ID {teacherHomeroom.TeacherId}");
                        }
                    }
                    else
                    {
                        var teacherName = await context.Teacher
                            .Where(t => t.ClassroomId == classId)
                            .Select(t => t.FullName)
                            .FirstOrDefaultAsync();

                        throw new InvalidOperationException($"Lớp {className} đã được giáo viên {teacherName} làm chủ nhiệm");
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Lớp {classId} chưa có trong danh sách lớp");
                }
            }
        }
    }
}
