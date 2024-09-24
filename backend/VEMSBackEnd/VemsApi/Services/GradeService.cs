using System;
using BusinessObject;
using DataAccess.Repository;
using VemsApi.Dto.GradeDto;
using VemsApi.Dto.PaginationDto;

namespace VemsApi.Services;

public interface IGradeService
{

    Task<object> GetGradeById(Guid id);
    Task<object> GetAllGrades(PaginationRequest request); // Retrieve all grades
    //Task AddGrade(GradeResponse grade); // Add a new grade
    //Task UpdateGrade(Grade grade); // Update an existing grade
    //Task DeleteGrade(Guid id); // Delete a grade by Id



}

public class GradeService : IGradeService
{

    private readonly IGradeRepository _repository;
    public GradeService()
    {
        _repository = new GradeRepository();
    }


    public async Task<object> GetAllGrades(PaginationRequest request)
    {
        int pageNumber = request.PageNumber;
        int pageSize = request.PageSize;

        // Get all grades and count
        IEnumerable<Grade> grades = await _repository.GetAllGrades();
        IEnumerable<GradeResponse> gradeDtos = grades.Select(grade => new GradeResponse
        {
            Id = grade.Id,
            GradeName = grade.GradeName
        }).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        int totalRecord = grades.Count();

        int totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);

        return new
        {
            totalPage,
            totalRecord,
            pageNumber,
            pageSize,
            pageData = gradeDtos
        };
    }

    public async Task<object> GetGradeById(Guid id)
    {
        Grade grade = await _repository.GetGradeById(id);
        if (grade == null) return null;

        GradeResponse gradeDto = new GradeResponse
        {
            GradeName = grade.GradeName,
            Id = grade.Id,
        };
        return gradeDto;
    }

    //public async Task AddGrade(GradeResponse gradeDto)
    //{
    //    Grade grade = new Grade { Id = gradeDto.Id, GradeName=gradeDto.GradeName};
    //    await _repository.AddGrade(grade);
    //}
}
