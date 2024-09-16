using System;
using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class ClassroomDAO
    {
        private readonly VemsContext _context;

        // Inject VemsContext instead of creating it manually
        public ClassroomDAO()
        {
            _context = new VemsContext();
        }

        // Get Classroom by Id
        public async Task<Classroom> GetClassroomByIdAsync(Guid id)
        {
            try
            {
                return await _context.Classrooms.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching classroom by Id: {ex.Message}", ex);
            }
        }

        // Get All Classrooms
        public async Task<List<Classroom>> GetAllClassroomsAsync()
        {
            try
            {
                return await _context.Classrooms.AsNoTracking().ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching all classrooms: {ex.Message}", ex);
            }
        }

        // Add Classroom
        public async Task AddClassroomAsync(Classroom classroom)
        {
            try
            {
                var existingClassroom = await GetClassroomByIdAsync(classroom.Id);
                if (existingClassroom != null)
                {
                    throw new InvalidOperationException("A classroom with the same ID already exists.");
                }

                _context.Classrooms.Add(classroom);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while creating the classroom. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding classroom: {ex.Message}", ex);
            }
        }

        // Update Classroom
        public async Task UpdateClassroomAsync(Classroom classroom)
        {
            try
            {
                var existingClassroom = await GetClassroomByIdAsync(classroom.Id);
                if (existingClassroom == null)
                {
                    throw new InvalidOperationException("Classroom not found.");
                }

                _context.Classrooms.Update(classroom);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while updating the classroom. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating classroom: {ex.Message}", ex);
            }
        }

        // Delete Classroom
        public async Task DeleteClassroomAsync(Guid id)
        {
            try
            {
                var classroom = await GetClassroomByIdAsync(id);
                if (classroom == null)
                {
                    throw new InvalidOperationException("Classroom not found.");
                }

                _context.Classrooms.Remove(classroom);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while deleting the classroom. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting classroom: {ex.Message}", ex);
            }
        }
    }
}
