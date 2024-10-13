using System;
using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class ClassroomDAO
    {
        private readonly VemsContext _context;

        public ClassroomDAO()
        {
            _context = new VemsContext();
        }

        // Lấy Classroom theo Id
        public async Task<Classroom> GetClassroomByIdAsync(Guid id)
        {
            try
            {
                return await _context.Classrooms.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy lớp học theo Id: {ex.Message}", ex);
            }
        }

        // Lấy tất cả Classrooms
        public async Task<List<Classroom>> GetAllClassroomsAsync()
        {
            try
            {
                return await _context.Classrooms.AsNoTracking().ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy tất cả các lớp học: {ex.Message}", ex);
            }
        }

        // Thêm Classroom
        public async Task AddClassroomAsync(Classroom classroom)
        {
            try
            {
                // Kiểm tra nếu gradeId đã tồn tại
                if (!await IsGradeExists(classroom.GradeId))
                {
                    throw new InvalidOperationException("Khối không tồn tại.");
                }

                // Kiểm tra nếu classroomId đã tồn tại
                if (await IsClassroomExists(classroom.Id))
                {
                    throw new InvalidOperationException("ID của lớp học đã tồn tại.");
                }

                _context.Classrooms.Add(classroom);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Xảy ra lỗi đồng thời khi tạo lớp học. Vui lòng thử lại.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm lớp học: {ex.Message}", ex);
            }
        }

        // Cập nhật Classroom
        public async Task UpdateClassroomAsync(Classroom classroom)
        {
            try
            {
                // Kiểm tra nếu gradeId đã tồn tại
                if (!await IsGradeExists(classroom.GradeId))
                {
                    throw new InvalidOperationException("Khối không tồn tại.");
                }

                // Kiểm tra nếu classroomId đã tồn tại
                if (!await IsClassroomExists(classroom.Id))
                {
                    throw new InvalidOperationException("Không tìm thấy lớp học.");
                }

                _context.Classrooms.Update(classroom);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Xảy ra lỗi đồng thời khi cập nhật lớp học. Vui lòng thử lại.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật lớp học: {ex.Message}", ex);
            }
        }

        // Xóa Classroom
        public async Task DeleteClassroomAsync(Guid id)
        {
            try
            {
                var classroom = await GetClassroomByIdAsync(id);
                if (classroom == null)
                {
                    throw new InvalidOperationException("Không tìm thấy lớp học.");
                }

                _context.Classrooms.Remove(classroom);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Xảy ra lỗi đồng thời khi xóa lớp học. Vui lòng thử lại.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa lớp học: {ex.Message}", ex);
            }
        }


        // Kiểm tra nếu Classroom tồn tại
        private async Task<bool> IsClassroomExists(Guid id)
        {
            return await _context.Classrooms
                .AsNoTracking()
                .AnyAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        // Kiểm tra nếu Grade tồn tại
        private async Task<bool> IsGradeExists(Guid gradeId)
        {
            return await _context.Grades
                .AsNoTracking()
                .AnyAsync(g => g.Id == gradeId)
                .ConfigureAwait(false);
        }
    }
}
