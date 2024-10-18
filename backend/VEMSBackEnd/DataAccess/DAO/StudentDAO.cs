using System;
using BusinessObject;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO;

public class StudentDAO
{
    private readonly VemsContext _context;

    public StudentDAO()
    {
        _context = new VemsContext();
    }

    // Lấy Student theo Id
    public async Task<StudentResponse> GetStudentByIdAsync(Guid id)
    {
        try
        {
            var studentResponse = await (from student in _context.Students
                                         join classroom in _context.Classrooms on student.ClassroomId equals classroom.Id
                                         join studentType in _context.studentTypes on student.StudentTypeId equals studentType.Id
                                         where student.Id == id
                                         select new StudentResponse
                                         {
                                             Id = student.Id,
                                             PublicStudentID = student.PublicStudentID,
                                             FullName = student.FullName,
                                             CitizenID = student.CitizenID,
                                             Username = student.Username,
                                             Password = student.Password,
                                             Email = student.Email,
                                             Dob = student.Dob,
                                             Address = student.Address,
                                             Image = student.Image,
                                             Phone = student.Phone,
                                             ParentPhone = student.ParentPhone,
                                             HomeTown = student.HomeTown,
                                             UnionJoinDate = student.UnionJoinDate,
                                             StudentTypeName = studentType.TypeName,
                                             ClassRoom = classroom.ClassName
                                         }).AsNoTracking().FirstOrDefaultAsync().ConfigureAwait(false);

            return studentResponse;
        }
        catch (Exception ex)
        {
            throw new Exception($"Lỗi khi lấy học sinh theo Id: {ex.Message}", ex);
        }
    }

    // Lấy tất cả Students
    public async Task<List<Student>> GetAllStudentsAsync()
    {
        try
        {
            return await _context.Students.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw new Exception($"Lỗi khi lấy tất cả các học sinh: {ex.Message}", ex);
        }
    }


    public async Task<List<StudentInClassResponse>> GetAllStudentsByClassroomAsync(Guid classID)
    {
        try
        {
            return await _context.Students.Where(x => x.ClassroomId == classID).Select(item => new StudentInClassResponse
            {
                PublicStudentID = item.PublicStudentID,
                StudentID = item.Id,
                StudentName = item.FullName,
            }).AsNoTracking().ToListAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw new Exception($"Lỗi khi lấy tất cả các học sinh trong lớp: {ex.Message}", ex);
        }
    }

    // // Thêm Student
    // public async Task AddStudentAsync(Student student)
    // {
    //     try
    //     {
    //         if (await IsStudentExisted(student.Id))
    //         {
    //             throw new InvalidOperationException("Id học sinh đã tồn tại");
    //         }

    //         if (!await IsStudentTypeExisted(student.StudentTypeId))
    //         {
    //             throw new InvalidOperationException("Loại học sinh không tồn tại.");
    //         }


    //         if (!await IsClassroomExisted(student.ClassroomId))
    //         {
    //             throw new InvalidOperationException("Lớp học không tồn tại");
    //         }

    //         if (!await IsRoleExisted(student.RoleId))
    //         {
    //             throw new InvalidOperationException("Vai trò học sinh không tồn tại");
    //         }

    //         _context.Students.Add(student);
    //         await _context.SaveChangesAsync().ConfigureAwait(false);
    //     }
    //     catch (DbUpdateConcurrencyException ex)
    //     {
    //         throw new Exception("Xảy ra lỗi đồng thời khi tạo học sinh. Vui lòng thử lại.", ex);
    //     }
    //     catch (InvalidOperationException ex)
    //     {
    //         throw;
    //     }
    //     catch (Exception ex)
    //     {
    //         throw new Exception($"Lỗi khi thêm học sinh: {ex.Message}", ex);
    //     }
    // }

    // // Cập nhật Student
    // public async Task UpdateStudentAsync(Student student)
    // {
    //     try
    //     {
    //         if (!await IsStudentExisted(student.Id))
    //         {
    //             throw new InvalidOperationException("Id học sinh không tồn tại");
    //         }

    //         if (!await IsStudentTypeExisted(student.StudentTypeId))
    //         {
    //             throw new InvalidOperationException("Loại học sinh không tồn tại.");
    //         }


    //         if (!await IsClassroomExisted(student.ClassroomId))
    //         {
    //             throw new InvalidOperationException("Lớp học không tồn tại");
    //         }

    //         if (!await IsRoleExisted(student.RoleId))
    //         {
    //             throw new InvalidOperationException("Vai trò học sinh không tồn tại");
    //         }

    //         _context.Students.Update(student);
    //         await _context.SaveChangesAsync().ConfigureAwait(false);
    //     }
    //     catch (DbUpdateConcurrencyException ex)
    //     {
    //         throw new Exception("Xảy ra lỗi đồng thời khi cập nhật học sinh. Vui lòng thử lại.", ex);
    //     }
    //     catch (InvalidOperationException ex)
    //     {
    //         throw;
    //     }
    //     catch (Exception ex)
    //     {
    //         throw new Exception($"Lỗi khi cập nhật học sinh: {ex.Message}", ex);
    //     }
    // }

    // // Xóa Student
    // public async Task DeleteStudentAsync(Guid id)
    // {
    //     try
    //     {
    //         var student = await GetStudentByIdAsync(id);
    //         if (student == null)
    //         {
    //             throw new InvalidOperationException("Không tìm thấy học sinh.");
    //         }

    //         _context.Students.Remove(student);
    //         await _context.SaveChangesAsync().ConfigureAwait(false);
    //     }
    //     catch (DbUpdateConcurrencyException ex)
    //     {
    //         throw new Exception("Xảy ra lỗi đồng thời khi xóa học sinh. Vui lòng thử lại.", ex);
    //     }
    //     catch (InvalidOperationException ex)
    //     {
    //         throw;
    //     }
    //     catch (Exception ex)
    //     {
    //         throw new Exception($"Lỗi khi xóa học sinh: {ex.Message}", ex);
    //     }
    // }

    // private async Task<bool> IsStudentExisted(Guid id)
    // {
    //     return await _context.Students
    //       .AsNoTracking()
    //       .AnyAsync(x => x.Id == id)
    //       .ConfigureAwait(false);
    // }

    // private async Task<bool> IsStudentTypeExisted(Guid? id)
    // {
    //     return await _context.Students
    //       .AsNoTracking()
    //       .AnyAsync(x => x.StudentTypeId == id)
    //       .ConfigureAwait(false);
    // }

    // private async Task<bool> IsClassroomExisted(Guid id)
    // {
    //     return await _context.Students
    //       .AsNoTracking()
    //       .AnyAsync(x => x.ClassroomId == id)
    //       .ConfigureAwait(false);
    // }

    // private async Task<bool> IsRoleExisted(Guid id)
    // {
    //     return await _context.Students
    //         .AsNoTracking()
    //         .AnyAsync(x => x.RoleId == id)
    //         .ConfigureAwait(false);
    // }
}
