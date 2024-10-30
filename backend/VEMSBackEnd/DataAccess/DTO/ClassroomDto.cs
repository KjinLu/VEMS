using System;

namespace DataAccess.Dto.ClassroomDto;

public class ClassroomResponse
{
    public Guid Id { get; set; }

    public string ClassName { get; set; }

    public Guid GradeId { get; set; }
}


public class ClassStudentsResponse
{
    public Guid ClassID { get; set; }
    public string ClassName { get; set; }
    public int NumberOfStudent { get; set; }
    public List<ClassStudentInfo> Students { get; set; }
}

public class ClassStudentInfo
{
    public Guid StudentID { get; set; }
    public string PublicStudentID { get; set; }
    public string ClassName { get; set; }
    public string StudentName { get; set; }
    public string StudentImage { get; set; }
    public string StudentPhone { get; set; }
    public string StudentType { get; set; }
    public Guid StudentTypeID { get; set; }
}

public class StudentTypeResponse
{
    public Guid StudentTypeID { get; set; }
    public string StudentName { get; set; }
    public string StudentCode { get; set; }
}