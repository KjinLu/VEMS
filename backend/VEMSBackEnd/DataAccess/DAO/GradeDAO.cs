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


        // Get Grade by Id
        public async Task<Grade> GetGradeByIdAsync(Guid id)
        {
            try
            {
                return await _context.Grades.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching grade by Id: {ex.Message}", ex);
            }
        }

        // Get All Grades
        public async Task<List<Grade>> GetAllGradesAsync()
        {
            try
            {
                return await _context.Grades.AsNoTracking().ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching all grades: {ex.Message}", ex);
            }
        }

    }
}
