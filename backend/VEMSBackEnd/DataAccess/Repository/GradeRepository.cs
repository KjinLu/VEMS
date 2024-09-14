using System;
using BusinessObject;
using DataAccess.DAO;

namespace DataAccess.Repository;


public interface IGradeRepository
{
    Task<Grade> GetGradeByIdAsync(Guid id);  // Get a grade by its ID
    Task<List<Grade>> GetAllGradesAsync();  // Get all grades
    Task AddGradeAsync(Grade grade); // Add a new grade
    Task UpdateGradeAsync(Grade grade); // Update an existing grade
    Task DeleteGradeAsync(Guid id); // Delete a grade by its ID
}

public class GradeRepository : IGradeRepository
{
    public Task<Grade> GetGradeByIdAsync(Guid id)
        => GradeDAO.Instance.GetGradeByIdAsync(id);
    public Task<List<Grade>> GetAllGradesAsync()
        => GradeDAO.Instance.GetAllGradesAsync();
    public Task AddGradeAsync(Grade grade)
        => GradeDAO.Instance.AddGradeAsync(grade);
    public Task UpdateGradeAsync(Grade grade)
        => GradeDAO.Instance.UpdateGradeAsync(grade);
    public Task DeleteGradeAsync(Guid id)
         => GradeDAO.Instance.DeleteGradeAsync(id);
}

