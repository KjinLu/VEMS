using System;
using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class GradeDAO
    {
        private static readonly object InstanceLock = new object();
        private static GradeDAO instance = null;

        public static GradeDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new GradeDAO();
                    }
                    return instance;
                }
            }
        }

        // Get a grade by its ID
        public async Task<Grade> GetGradeByIdAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Grades
                        .AsNoTracking()
                        .FirstOrDefaultAsync(g => g.Id == id)
                        .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching grade by ID: {ex.Message}", ex);
            }
        }

        // Get all grades
        public async Task<List<Grade>> GetAllGradesAsync()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Grades
                        .AsNoTracking()
                        .ToListAsync()
                        .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching all grades: {ex.Message}", ex);
            }
        }

        // Add a new grade
        public async Task AddGradeAsync(Grade grade)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    // Check if grade with the same ID already exists
                    var existingGrade = await GetGradeByIdAsync(grade.Id);
                    if (existingGrade != null)
                    {
                        throw new Exception("A grade with the same ID already exists.");
                    }

                    using (var transaction = await context.Database.BeginTransactionAsync().ConfigureAwait(false))
                    {
                        try
                        {
                            context.Grades.Add(grade);
                            await context.SaveChangesAsync().ConfigureAwait(false);
                            await transaction.CommitAsync().ConfigureAwait(false);
                        }
                        catch (Exception)
                        {
                            await transaction.RollbackAsync().ConfigureAwait(false);
                            throw;
                        }
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while adding the grade. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding grade: {ex.Message}", ex);
            }
        }

        // Update an existing grade
        public async Task UpdateGradeAsync(Grade grade)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingGrade = await GetGradeByIdAsync(grade.Id);
                    if (existingGrade == null)
                    {
                        throw new Exception("Grade not found.");
                    }

                    using (var transaction = await context.Database.BeginTransactionAsync().ConfigureAwait(false))
                    {
                        try
                        {
                            context.Grades.Update(grade);
                            await context.SaveChangesAsync().ConfigureAwait(false);
                            await transaction.CommitAsync().ConfigureAwait(false);
                        }
                        catch (Exception)
                        {
                            await transaction.RollbackAsync().ConfigureAwait(false);
                            throw;
                        }
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while updating the grade. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating grade: {ex.Message}", ex);
            }
        }

        // Delete a grade by its ID
        public async Task DeleteGradeAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var grade = await GetGradeByIdAsync(id);
                    if (grade == null)
                    {
                        throw new Exception("Grade not found.");
                    }

                    using (var transaction = await context.Database.BeginTransactionAsync().ConfigureAwait(false))
                    {
                        try
                        {
                            context.Grades.Remove(grade);
                            await context.SaveChangesAsync().ConfigureAwait(false);
                            await transaction.CommitAsync().ConfigureAwait(false);
                        }
                        catch (Exception)
                        {
                            await transaction.RollbackAsync().ConfigureAwait(false);
                            throw;
                        }
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while deleting the grade. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting grade: {ex.Message}", ex);
            }
        }
    }
}
