using System;
using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class GradeDAO
    {
        private readonly VemsContext _context;

        public GradeDAO()
        {
            _context = new VemsContext();
        }

        // Lấy Grade theo Id
        public async Task<Grade> GetGradeByIdAsync(Guid id)
        {
            try
            {
                return await _context.Grades.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy khối theo Id: {ex.Message}", ex);
            }
        }

        // Lấy tất cả Grades
        public async Task<List<Grade>> GetAllGradesAsync()
        {
            try
            {
                return await _context.Grades.AsNoTracking().ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy tất cả các khối: {ex.Message}", ex);
            }
        }


    }
}
