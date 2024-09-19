using Azure.Core;
using BusinessObject;
using DataAccess.DTO;
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

        public async Task<List<Student>> GetAllStudentAsync()
        {
            try
            {

                using (var context = new VemsContext())
                {
                    return await context.Students.ToListAsync();
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
                    return await context.Students.FirstOrDefaultAsync(student => student.Id == id);
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

        public async Task<List<Teacher>> GetAllTeacherAsync()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Teacher.ToListAsync();
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

        public async Task<object> GetAccountByEmailAsync(string email)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    var admin = await context.Admins.SingleOrDefaultAsync(admin => admin.Email == email);
                    if (admin != null) return admin;

                    var teacher = await context.Teacher.SingleOrDefaultAsync(teacher => teacher.Email == email);
                    if (teacher != null) return teacher;

                    var student = await context.Students.SingleOrDefaultAsync(student => student.Email == email);
                    if (student != null) return student;
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

                    if (teacher != null) return new CommonAccountType
                    {
                        AccountID = teacher.AccountID,
                        Email = teacher.Email,
                        RefreshToken = teacher.RefreshToken,
                        Password = teacher.Password,
                        RoleID = teacher.RoleID,
                        RoleName = teacher.RoleName,
                        Username = teacher.Username

                    };

                    var student = await (from a in context.Students
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

                    if (student != null) return new CommonAccountType
                    {
                        AccountID = student.AccountID,
                        Email = student.Email,
                        RefreshToken = student.RefreshToken,
                        Password = student.Password,
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
                        Password= admin.Password,
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
                                             RoleName = r.Code
                                         }).FirstOrDefaultAsync();

                    if (student != null) return new CommonAccountType
                    {
                        AccountID = student.AccountID,
                        Email = student.Email,
                        RefreshToken = student.RefreshToken,
                        Password= student.Password,
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
    }
}
