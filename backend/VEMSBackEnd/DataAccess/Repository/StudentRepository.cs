using System;
using BusinessObject;
using DataAccess.DAO;

namespace DataAccess.Repository;

public interface IStudentRepository
{
    // Task<Student> GetStudentById(Guid id); // Retrieve a Student by Id
    Task<List<Student>> GetAllStudents(); // Retrieve all Students
    Task<List<Student>> GetAllStudentsByClassroom(Guid classId); // Get Student By Classroom ID
    // Task AddStudent(Student Student); // Add a new Student
    // Task UpdateStudent(Student Student); // Update an existing Student
    // Task DeleteStudent(Guid id); // Delete a Student by Id
}

public class StudentRepository : IStudentRepository
{
    private readonly StudentDAO _dao;

    public StudentRepository()
    {
        _dao = new StudentDAO();
    }
    // public Task AddStudent(Student student)
    //     => _dao.AddStudentAsync(student);

    // public Task DeleteStudent(Guid id)
    //     => _dao.DeleteStudentAsync(id);

    public Task<List<Student>> GetAllStudents()
        => _dao.GetAllStudentsAsync();

        
    public Task<List<Student>> GetAllStudentsByClassroom(Guid classId)
        => _dao.GetAllStudentsAsync();

    // public Task<Student> GetStudentById(Guid id)
    //     => _dao.GetStudentByIdAsync(id);

    // public Task UpdateStudent(Student student)
    //     => _dao.UpdateStudentAsync(student);

}

