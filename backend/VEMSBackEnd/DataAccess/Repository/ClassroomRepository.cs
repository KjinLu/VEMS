using System;
using BusinessObject;
using DataAccess.DAO;

namespace DataAccess.Repository;
public interface IClassroomRepository
{
    Task<Classroom> GetClassroomById(Guid id); // Retrieve a classroom by Id
    Task<List<Classroom>> GetAllClassrooms(); // Retrieve all classrooms
    Task AddClassroom(Classroom classroom); // Add a new classroom
    Task UpdateClassroom(Classroom classroom); // Update an existing classroom
    Task DeleteClassroom(Guid id); // Delete a classroom by Id
}

public class ClassroomRepository : IClassroomRepository
{
    private readonly ClassroomDAO _dao;

    public ClassroomRepository()
    {
        _dao = new ClassroomDAO();
    }
    public Task AddClassroom(Classroom classroom)
        => _dao.AddClassroomAsync(classroom);

    public Task DeleteClassroom(Guid id)
        => _dao.DeleteClassroomAsync(id);

    public Task<List<Classroom>> GetAllClassrooms()
        => _dao.GetAllClassroomsAsync();

    public Task<Classroom> GetClassroomById(Guid id)
        => _dao.GetClassroomByIdAsync(id);

    public Task UpdateClassroom(Classroom classroom)
        => _dao.UpdateClassroomAsync(classroom);

}
