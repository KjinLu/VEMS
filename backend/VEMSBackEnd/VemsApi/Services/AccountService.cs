using BusinessObject;
using DataAccess.Repository;

public interface IAccountService
{
    List<Admin> GetAllAdminAccount();
    List<Teacher> GetAllTeacherAccount();
    List<Student> GetAllStudentAccount();

    object GetById(Guid id);

}

public class AccountService : IAccountService
{

    private readonly IAccountRepository _accountRepository;
    public AccountService()
    {
        _accountRepository = new AccountRepository();
    }
    public List<Admin> GetAllAdminAccount()
    {
        return _accountRepository.GetAllAdmin();
    }

    public List<Student> GetAllStudentAccount()
    {
        return _accountRepository.GetAllStudent();
}

    public List<Teacher> GetAllTeacherAccount()
    {
    return _accountRepository.GetAllTeacher();
    }

    public object GetById(Guid id)
    {
        return _accountRepository.GetAccountByID(id);
    }
}