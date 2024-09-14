using System;
using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO;

public class ClassroomDAO
{
    private static readonly object InstanceLock = new object();
    private static ClassroomDAO instance = null;

    public static ClassroomDAO Instance
    {
        get
        {
            lock (InstanceLock)
            {
                if (instance == null)
                {
                    instance = new ClassroomDAO();
                }
                return instance;
            }
        }
    }

    // Get Classroom by Id
    public async Task<Classroom> GetClassroomByIdAsync(Guid id)
    {
        try
        {
            using (var context = new VemsContext())
            {
                return await context.Classrooms.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            }
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
            using (var context = new VemsContext())
            {
                return await context.Classrooms.AsNoTracking().ToListAsync().ConfigureAwait(false);
            }
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
            using (var context = new VemsContext())
            {
                var existingClassroom = await GetClassroomByIdAsync(classroom.Id);
                if (existingClassroom != null)
                {
                    throw new Exception("A classroom with the same ID already exists.");
                }

                using (var transaction = await context.Database.BeginTransactionAsync().ConfigureAwait(false))
                {
                    try
                    {
                        context.Classrooms.Add(classroom);
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
            using (var context = new VemsContext())
            {
                var existingClassroom = await GetClassroomByIdAsync(classroom.Id);
                if (existingClassroom == null)
                {
                    throw new Exception("Classroom not found.");
                }

                using (var transaction = await context.Database.BeginTransactionAsync().ConfigureAwait(false))
                {
                    try
                    {
                        context.Classrooms.Update(classroom);
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
            using (var context = new VemsContext())
            {
                var classroom = await GetClassroomByIdAsync(id);
                if (classroom == null)
                {
                    throw new Exception("Classroom not found.");
                }

                using (var transaction = await context.Database.BeginTransactionAsync().ConfigureAwait(false))
                {
                    try
                    {
                        context.Classrooms.Remove(classroom);
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
            throw new Exception("A concurrency error occurred while deleting the classroom. Please try again.", ex);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting classroom: {ex.Message}", ex);
        }
    }
}
