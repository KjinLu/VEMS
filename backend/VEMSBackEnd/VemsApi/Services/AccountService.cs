using BusinessObject;
using DataAccess.DTO;
using DataAccess.Repository;
using SchoolMate.Dto.AuthenticationDto;

public interface IAccountService
{
    Task<List<Admin>> GetAllAdminAccountAsync();
    Task<List<Teacher>> GetAllTeacherAccountAsync();
    Task<List<Student>> GetAllStudentAccountAsync();
    Task<CommonAccountType> GetAccountByIdAsync(Guid accountID);
    Task<bool> ChangePassword(ChangePasswordRequest usernameOrEmail);
    Task<List<Student>> RegisterStudent(List<RegisterStudentRequest> request);
    Task<List<Teacher>> RegisterTeacher(List<RegisterTeacherRequest> request);

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

    public Task<bool> ChangePassword(ChangePasswordRequest request)
    {
        return _accountRepository.UpdatePassword(request.AccountID, Hashing(request.NewPassword));
    }

    public string Hashing(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, 6);
    }

    public async Task<List<Student>> RegisterStudent(List<RegisterStudentRequest> request)
    {
        List<Student> newStudentList = new List<Student>();

        foreach (var student in request)
        {
            Student newStudent = new Student
            {
                Username = student.PublicStudentID,
                PublicStudentID = student.PublicStudentID,
                FullName = student.FullName,
                RoleId = student.RoleId,
                ClassroomId = student.ClassroomId,
                Password = Hashing("1")
            };
            newStudentList.Add(newStudent);
        }

        return await this._accountRepository.RegisterStudentAsync(newStudentList);
    }

    public async Task<List<Teacher>> RegisterTeacher(List<RegisterTeacherRequest> request)
    {
        List<Teacher> newTeacherList = new List<Teacher>();

        foreach (var teacher in request)
        {
            Teacher newTeacher = new Teacher
            {
                Username = teacher.Phone,
                Phone = teacher.Phone,
                Email = teacher.Email,
                FullName = teacher.FullName,
                RoleId = teacher.RoleId,
                //ClassroomId = student.ClassroomId,
                Password = Hashing("1")
            };
            newTeacherList.Add(newTeacher);
        }

        return await this._accountRepository.RegisterTeacherAsync(newTeacherList);
    }
}