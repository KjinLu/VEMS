
public class ScheduleResponse
{
    public Guid Id { get; set; }

    public DateTime Time { get; set; }

    public Guid ClassroomId { get; set; }

    public string ClassroomName { get; set; }

}

public class CreateScheduleDetailRequest
{
    public Guid ScheduleID { get; set; }
    public List<SessionDto> Sessions { get; set; }
}

public class UpdateScheduleRequest
{
    public Guid ScheduleID { get; set; }
    public List<SessionDto> Sessions { get; set; }
}

public class SessionDto
{
    public Guid SessionID { get; set; }
    public List<SlotDetailDto> SlotDetails { get; set; }
}

public class SlotDetailDto
{
    public Guid SubjectID { get; set; }
    public Guid? TeacherID { get; set; }
    public Guid SlotID { get; set; }
}

public class UpdateSlotDetailDto
{
    public Guid? SlotDetailID { get; set; }
    public Guid SubjectID { get; set; }
    public Guid TeacherID { get; set; }
    public Guid SlotID { get; set; }
}

public class ScheduleDetailResponseDto
{
    public Guid ScheduleId { get; set; }
    public DateTime Time { get; set; }
    public string ClassName { get; set; }
    public Guid ClassroomID { get; set; }
    public List<SesionDetailResponse> Sessions { get; set; }
}

public class SesionDetailResponse
{
    public int DayOfWeek { get; set; }
    public string PeriodName { get; set; }
    public Guid SessionID { get; set; }
    public List<SlotDetailResponse> SlotDetails { get; set; }
}

public class SlotDetailResponse
{
    public Guid SubjectID { get; set; }
    public string SubjectName { get; set; }
    public Guid? TeacherID { get; set; }
    public string? TeacherName { get; set; }
    public Guid SlotID { get; set; }
    public int SlotIndex { get; set; }
    public TimeSpan SlotStart { get; set; }
    public TimeSpan SlotEnd { get; set; }
}

public class TeacherScheduleResponse
{
    public Guid TeacherID { get; set; }
    public string TeacherName { get; set; }
    public List<TeacherSesionDetailResponse> Sessions { get; set; }
}

public class TeacherSlotDetailResponse
{
    public Guid ClassroomID { get; set; }
    public string Classname { get; set; }
    public Guid SubjectID { get; set; }
    public string SubjectName { get; set; }
    public Guid SlotID { get; set; }
    public int SlotIndex { get; set; }
    public TimeSpan SlotStart { get; set; }
    public TimeSpan SlotEnd { get; set; }
}


public class TeacherSesionDetailResponse
{
    public int DayOfWeek { get; set; }
    public string PeriodName { get; set; }
    public Guid SessionID { get; set; }
    public List<TeacherSlotDetailResponse> SlotDetails { get; set; }
}