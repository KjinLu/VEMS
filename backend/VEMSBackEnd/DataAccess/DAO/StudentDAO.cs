using System;
using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO;

public class StudentDAO
{
    private readonly VemsContext _context;

    public StudentDAO()
    {
        _context = new VemsContext();
    }

    // // Lấy Student theo Id
    // public async Task<Student> GetStudentByIdAsync(Guid id)
    // {
    //     try
    //     {
    //         return await _context.Students.AsNoTracking()
    //             .FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
    //     }
    //     catch (Exception ex)
    //     {
    //         throw new Exception($"Lỗi khi lấy học sinh theo Id: {ex.Message}", ex);
    //     }
    // }

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
