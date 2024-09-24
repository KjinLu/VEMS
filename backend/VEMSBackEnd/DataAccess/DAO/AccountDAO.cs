using BusinessObject;

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

        public object GetAccountByUserName(string username)
        {
            try
            {
                var context = new VemsContext();
                if (context != null)
                {
                    var admin = context.Admins.SingleOrDefault(admin => admin.Username == username);
                    if (admin != null) return admin;

                    var teacher = context.Teacher.SingleOrDefault(teacher => teacher.Username == username);
                    if (teacher != null) return teacher;

                    var student = context.Students.SingleOrDefault(student => student.Username == username);
                    if (student != null) return student;
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

        public object GetAccountByID(Guid accountID)
        {
            try
            {
                var context = new VemsContext();
                //if (context != null)
                //{
                //    var admin = (from a in context.Admins
                //                 join r in context.Roles on a.RoleId equals r.Id into ar
                //                 from role in ar.DefaultIfEmpty()
                //                 where a.Id == accountID
                //                 select new
                //                 {
                //                     Admin = a,
                //                     Role = role
                //                 }).SingleOrDefault();

                //    if (admin != null) return new
                //    {
                //        admin = admin,
                //        roleCode = admin.Role.Code
                //    };

                //    var teacher = (from t in context.Teacher
                //                   join r in context.Roles on t.RoleId equals r.Id into tr
                //                   from role in tr.DefaultIfEmpty()
                //                   where t.Id == accountID
                //                   select new
                //                   {
                //                       Teacher = t,
                //                       Role = role
                //                   }).SingleOrDefault();

                //    if (teacher != null) return new
                //    {
                //        teacher = teacher,
                //        roleCode = teacher.Role.Code
                //    };

                //    var student = (from s in context.Students
                //                   join r in context.Roles on s.RoleId equals r.Id into sr
                //                   from role in sr.DefaultIfEmpty()
                //                   where s.Id == accountID
                //                   select new
                //                   {
                //                       Student = s,
                //                       Role = role
                //                   }).SingleOrDefault();

                //    if (student != null) return new
                //    {
                //        student = student,
                //        roleCode = student.Role.Code
                //    };
                //}
                if (context != null)
                {
                    var admin = context.Admins.SingleOrDefault(admin => admin.Id == accountID);
                    if (admin != null) return admin;

                    var teacher = context.Teacher.SingleOrDefault(teacher => teacher.Id == accountID);
                    if (teacher != null) return teacher;

                    var student = context.Students.SingleOrDefault(student => student.Id == accountID);
                    if (student != null) return student;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
