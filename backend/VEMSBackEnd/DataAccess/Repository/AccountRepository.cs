using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess.DAO;

namespace DataAccess.Repository
{

    public interface IAccountRepository
    {
        public List<Admin> GetAllAdmin();
        public Admin GetAdminById(Guid accountID);
        public Admin GetAdminByUsername(string username);
        public Admin GetAdminByEmail(string email);
        public List<Student> GetAllStudent();
        public Student GetStudentById(Guid accountID);
        public Student GetStudentByUsername(string username);
        public Student GetStudentByEmail(string email);
        public List<Teacher> GetAllTeacher();
        public Teacher GetTeacherById(Guid accountID);
        public Teacher GetTeacherByUsername(string username);
        public Teacher GetTeacherByEmail(string email);
        public object GetAccountByUserName(string username);
        public object GetAccountByEmail(string username);
        public object GetAccountByID(Guid accountID);
    }

    public class AccountRepository : IAccountRepository
    {

        public List<Admin> GetAllAdmin() => AccountDAO.Instance.GetAllAdmin();

        public List<Student> GetAllStudent() => AccountDAO.Instance.GetAllStudent();

        public List<Teacher> GetAllTeacher() => AccountDAO.Instance.GetAllTeacher();

        public object GetAccountByID(Guid accountID) => AccountDAO.Instance.GetAccountByID(accountID);

        public object GetAccountByUserName(string username) => AccountDAO.Instance.GetAccountByUserName(username);

        public object GetAccountByEmail(string email) => AccountDAO.Instance.GetAccountByEmail(email);

        public Admin GetAdminByEmail(string email) => AccountDAO.Instance.GetAdminByEmail(email);

        public Admin GetAdminById(Guid accountID) => AccountDAO.Instance.GetAdminById(accountID);

        public Admin GetAdminByUsername(string username) => AccountDAO.Instance.GetAdminByUsername(username);

        public Student GetStudentByEmail(string email) => AccountDAO.Instance.GetStudentByEmail(email);

        public Student GetStudentById(Guid accountID) => AccountDAO.Instance.GetStudentById(accountID);

        public Student GetStudentByUsername(string username) => AccountDAO.Instance.GetStudentByUsername(username);

        public Teacher GetTeacherByEmail(string email) => AccountDAO.Instance.GetTeacherByEmail(email);

        public Teacher GetTeacherById(Guid accountID) => AccountDAO.Instance.GetTeacherById(accountID);

        public Teacher GetTeacherByUsername(string username) => AccountDAO.Instance.GetTeacherByUsername(username);
    }
}
