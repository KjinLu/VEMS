using BusinessObject;
using DataAccess.DTO;
using DataAccess.Repository;

public interface IAccountService
{
    Task<object> GetAllAdminAccountAsync(PaginationRequest request);
    Task<object> GetAllTeacherAccountAsync(PaginationRequest request);
    Task<object> GetAllStudentAccountAsync(PaginationRequest request);
    Task<CommonAccountType> GetAccountByIdAsync(Guid accountID);
    Task<bool> ChangePassword(ChangePasswordRequest usernameOrEmail);
    Task<List<Student>> RegisterStudent(List<RegisterStudentRequest> request);
    Task<List<Teacher>> RegisterTeacher(List<RegisterTeacherRequest> request);
    Task<Student> CreateStudentAccount(CreateStudentRequest request);
    Task<Teacher> CreateTeacherAccount(CreateTeacherRequest request);
    Task<bool> AdminUpdateStudentAccount(AdminUpdateStudent request);
    Task<bool> AdminUpdateTeacherAccount(AdminUpdateTeacher request);


}

public class AccountService : IAccountService
{

    private readonly IAccountRepository _accountRepository;
    public AccountService()
    {
        _accountRepository = new AccountRepository();
    }

    public async Task<object> GetAllAdminAccountAsync(PaginationRequest request)
    {
        int pageNumber = request.PageNumber;
        int pageSize = request.PageSize;

        var admins = await _accountRepository.GetAllAdminAsync();
        var dataPaginate = admins.Select(a => a).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        int totalRecord = admins.Count();

        int totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);

        return new
        {
            totalPage,
            totalRecord,
            pageNumber,
            pageSize,
            pageData = dataPaginate
        };
    }


    public async Task<object> GetAllStudentAccountAsync(PaginationRequest request)
    {
        int pageNumber = request.PageNumber;
        int pageSize = request.PageSize;

        var students = await _accountRepository.GetAllStudentAsync();
        var dataPaginate = students.Select(a => a).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();


        int totalRecord = students.Count();

        int totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);

        return new
        {
            totalPage,
            totalRecord,
            pageNumber,
            pageSize,
            pageData = dataPaginate
        };
    }

    public async Task<object>  GetAllTeacherAccountAsync(PaginationRequest request)
    {
        int pageNumber = request.PageNumber;
        int pageSize = request.PageSize;

        var teachers = await _accountRepository.GetAllTeacherAsync();
        var dataPaginate = teachers.Select(a => a).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();


        int totalRecord = teachers.Count();

        int totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);

        return new
        {
            totalPage,
            totalRecord,
            pageNumber,
            pageSize,
            pageData = dataPaginate
        };
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
                RoleId = new Guid("81B3444C-C9FD-4EFC-A774-E1E3FC3C3E53"),
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
                FullName = teacher.FullName,
                RoleId = new Guid("81B3444C-C9FD-4EFC-A774-E1E3FC3C3E53"),
                ClassroomId = teacher.ClassID != null ? teacher.ClassID : null,
                //ClassroomId = student.ClassroomId,
                Password = Hashing("1")
            };
            newTeacherList.Add(newTeacher);
        }

        return await this._accountRepository.RegisterTeacherAsync(newTeacherList);
    }

    public async Task<Student> CreateStudentAccount(CreateStudentRequest request)
    {
        Student newStudent = new Student
        {
            PublicStudentID = request.PublicStudentID,
            FullName = request.FullName,
            CitizenID = request.CitizenID,
            Username = request.Phone,
            Password = Hashing(request.Password),
            Email = request.Email,
            Dob= DateOnly.Parse(request.Dob),
            Address = request.Address,
            Phone = request.Phone,
            ParentPhone = request.ParentPhone,
            HomeTown = request.HomeTown,
            UnionJoinDate = DateOnly.Parse(request.UnionJoinDate),
            StudentTypeId = request.StudentTypeId,
            ClassroomId = request.ClassroomId,
            RoleId = request.RoleId,
        };

        return await this._accountRepository.CreateAStudentAccount(newStudent);
    }

    public async Task<Teacher> CreateTeacherAccount(CreateTeacherRequest request)
    {
        Teacher newTeacher = new Teacher
        {
            PublicTeacherID = request.PublicTeacherID,
            CitizenID = request.CitizenID,
            Username = request.Phone,
            Password = Hashing(request.Password),
            FullName = request.FullName,
            Email = request.Email,
            Dob = DateOnly.Parse(request.Dob),
            Address = request.Address,
            Phone = request.Phone,
            TeacherTypeId = request.TeacherTypeId,
            RoleId = request.RoleId,
        };

        return await this._accountRepository.CreateTeacherAccount(newTeacher);
    }

    public async Task<bool> AdminUpdateStudentAccount(AdminUpdateStudent request)
    {
        var account = await _accountRepository.GetStudentByIdAsync(request.StudentID);

        if (account == null) return false;

        account.PublicStudentID= request.PublicStudentID;
        account.FullName = request.FullName;
        account.CitizenID = request.CitizenID;
        account.Username = request.Username;
        account.Password = Hashing(request.Password);
        account.Email = request.Email;
        account.Dob = DateOnly.Parse(request.Dob);
        account.Address = request.Address;
        account.Phone = request.Phone;
        account.ParentPhone = request.ParentPhone;
        account.HomeTown = request.HomeTown;
        account.UnionJoinDate = DateOnly.Parse(request.UnionJoinDate);
        account.StudentTypeId = request.StudentTypeId;
        account.ClassroomId = request.ClassroomId;

        return await _accountRepository.UpdateStudentProfile(account);
    }

    public async Task<bool> AdminUpdateTeacherAccount(AdminUpdateTeacher request)
    {
        var account = await _accountRepository.GetTeacherByIdAsync(request.TeacherID);

        if (account == null) return false;

        account.FullName = request.FullName;
        account.PublicTeacherID = request.PublicTeacherID;
        account.CitizenID = request.CitizenID;
        account.Username = request.Username;
        account.Password = Hashing(request.Password);
        account.Email = request.Email;
        account.Dob = DateOnly.Parse(request.Dob);
        account.Address = request.Address;
        account.Phone = request.Phone;
        account.TeacherTypeId = request.TeacherTypeId;

        return await _accountRepository.UpdateTeacherProfile(account);
    }
}