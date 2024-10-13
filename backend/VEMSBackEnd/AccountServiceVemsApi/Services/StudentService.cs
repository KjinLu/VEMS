using BusinessObject;
using DataAccess.DTO;
using DataAccess.Repository;


    public interface IStudentService
    {
        Task<object> GetAllStudents(PaginationRequest request);

        Task<List<StudentInClassResponse>> GetAllStudentByClassroom(Guid classId);
        Task<bool> UpdateProfile(UpdateStudentProfileRequest request);
        Task<bool> ChangePassword(ChangePasswordRequest request);

        Task<bool> UploadAvatar(UploadAvatartRequest request);

        Task<bool> DeleteAvatar(DeleteAvatarRequest request);
    }

    public class StudentService : IStudentService
    {

        private readonly IAccountRepository _accountRepository;
        private readonly IStudentRepository _studentRepository;
        public StudentService()
        {
            _accountRepository = new AccountRepository();
            _studentRepository = new StudentRepository();
        }
        public async Task<bool> UpdateProfile(UpdateStudentProfileRequest request)
        {
            var account = await _accountRepository.GetStudentByIdAsync(request.StudentId);

            if (account == null) return false;

            account.FullName = request.FullName;
            account.CitizenID = request.CitizenID;
            account.Email = request.Email;
            account.Dob = DateOnly.Parse(request.Dob);
            account.Address = request.Address;
            account.Phone = request.Phone;
            account.ParentPhone = request.ParentPhone;
            account.HomeTown = request.HomeTown;
            account.UnionJoinDate = DateOnly.Parse(request.UnionJoinDate);

            return await _accountRepository.UpdateStudentProfile(account);
        }

        public async Task<bool> ChangePassword(ChangePasswordRequest request)
        {
            return await _accountRepository.UpdatePassword(request.AccountID, Hashing(request.NewPassword));
        }

        public string Hashing(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 6);
        }

        public async Task<bool> UploadAvatar(UploadAvatartRequest request)
        {
            var a = ImageExtension.UploadFile(request.file);
            return await _accountRepository.UpdateAvatar(request.AccountID, a);
        }

        public async Task<bool> DeleteAvatar(DeleteAvatarRequest request)
        {
            return await _accountRepository.UpdateAvatar(request.AccountID, "");
        }

        public async Task<object> GetAllStudents(PaginationRequest request)
        {
            int pageNumber = request.PageNumber;
            int pageSize = request.PageSize;

            // Get all grades and count
            IEnumerable<Student> students = await _studentRepository.GetAllStudents();
            IEnumerable<StudentResponse> studentDto = students.Select(student => new StudentResponse
            {
                Id = student.Id,
                FullName = student.FullName,
                CitizenID = student.CitizenID,
                Email = student.Email,
                Dob = student.Dob,
                Address = student.Address,
                Phone = student.Phone,
                ParentPhone = student.ParentPhone,
                HomeTown = student.HomeTown,
                UnionJoinDate = student.UnionJoinDate
            }).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            int totalRecord = students.Count();

            int totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);

            return new
            {
                totalPage,
                totalRecord,
                pageNumber,
                pageSize,
                pageData = studentDto
            };
        }

        public async Task<List<StudentInClassResponse>> GetAllStudentByClassroom(Guid classId)
        {
            // Get all grades and count
            return await _studentRepository.GetAllStudentsByClassroom(classId);
        }

    }

