using BusinessObject;
using DataAccess.DTO;
using DataAccess.Repository;

public interface IAccountService
{
    Task<List<Admin>> GetAllAdminAccountAsync();
    Task<List<Teacher>> GetAllTeacherAccountAsync();
    Task<List<Student>> GetAllStudentAccountAsync();
    Task<CommonAccountType> GetAccountByIdAsync(Guid accountID);

}

public class AccountService : IAccountService
{

    private readonly IAccountRepository _accountRepository;
    public AccountService()
    {
        _accountRepository = new AccountRepository();
    }

    public async Task<List<Admin>> GetAllAdminAccountAsync()
    {
        return await _accountRepository.GetAllAdminAsync();
    }


    public async Task<List<Student>> GetAllStudentAccountAsync()
    {
        return await _accountRepository.GetAllStudentAsync();
    }

    public async Task<List<Teacher>> GetAllTeacherAccountAsync()
    {
        return await _accountRepository.GetAllTeacherAsync();
    }

    public async Task<CommonAccountType> GetAccountByIdAsync(Guid accountID)
    {
        return await _accountRepository.GetAccountByIDAsync(accountID);
    }
}