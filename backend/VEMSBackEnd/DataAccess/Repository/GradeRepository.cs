using System;
using BusinessObject;
using DataAccess.DAO;

namespace DataAccess.Repository;


public interface IGradeRepository
{
    Task<Grade> GetGradeById(Guid id);  // Get a grade by its ID
    Task<List<Grade>> GetAllGrades();  // Get all grades

    //Not Using
    //Task AddGrade(Grade grade); // Add a new grade   
    //Task UpdateGrade(Grade grade); // Update an existing grade
    //Task DeleteGrade(Guid id); // Delete a grade by its ID
}

public class GradeRepository : IGradeRepository
{
    private readonly GradeDAO _dao;

    public GradeRepository()
    {
        _dao = new GradeDAO();
    }
    public Task<Grade> GetGradeById(Guid id)
        => _dao.GetGradeByIdAsync(id);
    public Task<List<Grade>> GetAllGrades()
        => _dao.GetAllGradesAsync();

    //public Task AddGrade(Grade grade)
    //    => GradeDAO.Instance.AddGradeAsync(grade);
    //public Task UpdateGrade(Grade grade)
    //    => GradeDAO.Instance.UpdateGradeAsync(grade);
    //public Task DeleteGrade(Guid id)
    //     => GradeDAO.Instance.DeleteGradeAsync(id);
}

