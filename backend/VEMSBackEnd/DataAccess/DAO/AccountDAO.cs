using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Admin> GetAllAdmin() {
            List<Admin> list = null;
            try
            {
                var context = new VemsContext();
                if(context != null)
                {
                    list = context.Admins.ToList();
                }
                return list;
            }
            catch (Exception ex) {
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
    }
}
