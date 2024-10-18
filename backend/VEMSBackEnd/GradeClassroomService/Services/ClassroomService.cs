using System;
using BusinessObject;
using DataAccess.DAO;
using DataAccess.Dto.ClassroomDto;
using DataAccess.Repository;

namespace GradeClassroomService.Services;


public interface IClassroomService
{

    Task<object> GetClassroomById(Guid id);
    Task<object> GetAllClassrooms(PaginationRequest request); // Retrieve all classrooms
    Task AddClassroom(ClassroomResponse classroom); // Add a new classroom
    Task UpdateClassroom(ClassroomResponse classroom); // Update an existing classroom
    Task DeleteClassroom(Guid id); // Delete a classroom by Id

}

public class ClassroomService : IClassroomService
{

    private readonly IClassroomRepository _repository;
    public ClassroomService()
    {
        _repository = new ClassroomRepository();
    }


    public async Task<object> GetAllClassrooms(PaginationRequest request)
    {
        int pageNumber = request.PageNumber;
        int pageSize = request.PageSize;

        // Get all classrooms and count
        IEnumerable<Classroom> classrooms = await _repository.GetAllClassrooms();
        IEnumerable<ClassroomResponse> classroomDtos = classrooms.Select(classroom => new ClassroomResponse
        {
            Id = classroom.Id,
            ClassName = classroom.ClassName,
            GradeId = classroom.GradeId
        }).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        int totalRecord = classrooms.Count();

        int totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);

        return new
        {
            totalPage,
            totalRecord,
            pageNumber,
            pageSize,
            pageData = classroomDtos
        };
    }

    public async Task<object> GetClassroomById(Guid id)
    {
        Classroom classroom = await _repository.GetClassroomById(id);
        if (classroom == null) return null;

        ClassroomResponse classroomDto = new ClassroomResponse
        {
            ClassName = classroom.ClassName,
            Id = classroom.Id,
            GradeId = classroom.GradeId
        };
        return classroomDto;
    }

    public async Task AddClassroom (ClassroomResponse classroomRequest)
    {
        Classroom classroom = new Classroom { ClassName = classroomRequest.ClassName, Id = classroomRequest.Id,GradeId = classroomRequest.GradeId };
        await _repository.AddClassroom(classroom);
    }

    public async Task UpdateClassroom(ClassroomResponse classroomRequest)
    {
        Classroom classroom = new Classroom { ClassName = classroomRequest.ClassName, Id = classroomRequest.Id, GradeId = classroomRequest.GradeId };
        await _repository.UpdateClassroom(classroom);
    }

    public async Task DeleteClassroom(Guid id)
    {
        await _repository.DeleteClassroom(id);
    }
}
