using System;
using BusinessObject;
using DataAccess.DAO;
using DataAccess.Dto.ClassroomDto;
using DataAccess.DTO;

namespace DataAccess.Repository;
public interface IClassroomRepository
{
    Task<Classroom> GetClassroomById(Guid id); // Retrieve a classroom by Id
    Task<List<ClassroomResponse>> GetAllClassrooms(); // Retrieve all classrooms
    Task AddClassroom(Classroom classroom); // Add a new classroom
    Task UpdateClassroom(Classroom classroom); // Update an existing classroom
    Task DeleteClassroom(Guid id); // Delete a classroom by Id
    Task<ClassStudentsResponse> GetClassStudents(Guid classID);
    Task<List<StudentType>> GetAllStudentType();
    Task<bool> AssignStudentType(AssignStudentTypeRequest request);

    Task AddClassrooms(List<ImportClassRequest> classrooms);

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

        public Task<List<ClassroomResponse>> GetAllClassrooms()
            => _dao.GetAllClassroomsAsync();

        public Task<List<StudentType>> GetAllStudentType()
        => _dao.GetAllStudentType();

        public Task<Classroom> GetClassroomById(Guid id)
            => _dao.GetClassroomByIdAsync(id);

        public async Task<ClassStudentsResponse> GetClassStudents(Guid classID)
        => await _dao.GetClassStudents(classID);

        public Task UpdateClassroom(Classroom classroom)
            => _dao.UpdateClassroomAsync(classroom);

        public Task<bool> AssignStudentType(AssignStudentTypeRequest request)
         => _dao.AssignStudentType(request);

        public Task AddClassrooms(List<ImportClassRequest> classrooms) => _dao.AddClassrooms(classrooms);

    }
