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
<<<<<<< HEAD
                    return await context.Students.AsNoTracking().FirstOrDefaultAsync(student => student.Id == id);
=======
                    return context.Students.FirstOrDefault(student => student.Id == id);
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96
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
<<<<<<< HEAD

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

=======
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96
    }
}
