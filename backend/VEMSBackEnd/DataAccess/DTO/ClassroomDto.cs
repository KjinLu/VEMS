using System;

namespace DataAccess.Dto.ClassroomDto;

public class ClassroomResponse
{
    public Guid Id { get; set; }

    public string ClassName { get; set; }

    public Guid GradeId { get; set; }
}
