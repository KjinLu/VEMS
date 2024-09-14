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

public class ClasroomRepository : IClassroomRepository
{
    public Task AddClassroom(Classroom classroom)
        => ClassroomDAO.Instance.AddClassroomAsync(classroom);

    public Task DeleteClassroom(Guid id)
        => ClassroomDAO.Instance.DeleteClassroomAsync(id);

    public Task<List<Classroom>> GetAllClassrooms()
        => ClassroomDAO.Instance.GetAllClassroomsAsync();

    public Task<Classroom> GetClassroomById(Guid id)
        => ClassroomDAO.Instance.GetClassroomByIdAsync(id);

    public Task UpdateClassroom(Classroom classroom)
        => ClassroomDAO.Instance.UpdateClassroomAsync(classroom);
}
