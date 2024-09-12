using BusinessObject;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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

        public List<Admin> GetAllAdmin()
        {
            List<Admin> list = null;
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    list = context.Admins.ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Admin GetAdminById(Guid id)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return context.Admins.FirstOrDefault(admin => admin.Id == id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Admin GetAdminByUsername(string username)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return context.Admins.FirstOrDefault(admin => admin.Username == username);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Admin GetAdminByEmail(string email)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return context.Admins.FirstOrDefault(admin => admin.Email == email);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Student> GetAllStudent()
        {
            List<Student> list = null;
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    list = context.Students.ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Student GetStudentById(Guid id)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return context.Students.FirstOrDefault(student => student.Id == id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Student GetStudentByUsername(string username)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return context.Students.FirstOrDefault(student => student.Username == username);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Student GetStudentByEmail(string email)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return context.Students.FirstOrDefault(student => student.Email == email);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Teacher> GetAllTeacher()
        {
            List<Teacher> list = null;
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    list = context.Teacher.ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Teacher GetTeacherById(Guid id)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return context.Teacher.FirstOrDefault(teacher => teacher.Id == id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Teacher GetTeacherByUsername(string username)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return context.Teacher.FirstOrDefault(teacher => teacher.Username == username);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Teacher GetTeacherByEmail(string email)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    return context.Teacher.FirstOrDefault(teacher => teacher.Email == email);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public object GetAccountByEmail(string email)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    var admin = context.Admins.SingleOrDefault(admin => admin.Email == email);
                    if (admin != null) return admin;

                    var teacher = context.Teacher.SingleOrDefault(teacher => teacher.Email == email);
                    if (teacher != null) return teacher;

                    var student = context.Students.SingleOrDefault(student => student.Email == email);
                    if (student != null) return student;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CommonAccountType GetAccountByID(Guid accountID)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    var admin = (from a in context.Admins
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
                                 }).FirstOrDefault();


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

                    var teacher = (from a in context.Teacher
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
                                   }).FirstOrDefault();

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

                    var student = (from a in context.Students
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
                                   }).FirstOrDefault();

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

        public CommonAccountType GetAccountByUsername(string username)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    var admin = (from a in context.Admins
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
                                 }).FirstOrDefault();


                    if (admin != null) return new CommonAccountType
                    {
                        AccountID = admin .AccountID,
                        Email = admin .Email,
                        RefreshToken = admin .RefreshToken,
                        Password = admin .Password,
                        RoleID = admin.RoleID,
                        RoleName = admin.RoleName,
                        Username = admin.Username
                        
                    };

                    var teacher = (from a in context.Teacher
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
                                   }).FirstOrDefault();

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

                    var student = (from a in context.Students
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
                                   }).FirstOrDefault();

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

        public bool UpdateRefreshToken(Guid AccountId, string token)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    var admin = context.Admins.SingleOrDefault(admin => admin.Id == AccountId);
                    if (admin != null)
                    {
                        admin.RefreshToken = token;
                        context.Entry<Admin>(admin).State = EntityState.Modified;
                        context.SaveChanges();
                        return true;
                    }

                    var teacher = context.Teacher.SingleOrDefault(teacher => teacher.Id == AccountId);
                    if (teacher != null)
                    {
                        teacher.RefreshToken = token;
                        context.Entry<Teacher>(teacher).State = EntityState.Modified;
                        context.SaveChanges();
                        return true;
                    }

                    var student = context.Students.SingleOrDefault(student => student.Id == AccountId);
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
    }

}
