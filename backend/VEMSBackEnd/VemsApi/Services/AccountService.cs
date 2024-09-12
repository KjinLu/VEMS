using BusinessObject;
using DataAccess.DTO;
using DataAccess.Repository;

public interface IAccountService
{
    List<Admin> GetAllAdminAccount();
    List<Teacher> GetAllTeacherAccount();
    List<Student> GetAllStudentAccount();
    CommonAccountType GetAccountById(Guid accountID);

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

    public CommonAccountType GetAccountById(Guid accountID)
    {
        return _accountRepository.GetAccountByID(accountID);
    }
}