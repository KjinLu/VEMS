public class CreateActivityEnrollerListRequest
{
    public DateTime ActivityTime { get; set; }
    public string ActivityNote { get; set; }
    public List<Guid> StudentIDs { get; set; }
}

public class TakeActivityAttendanceRequest
{
    public Guid AttendanceId { get; set; }
    public List<StudentAttendance> attendanceData { get; set; }
}

public class StudentAttendance
{
    public Guid AttendanceActivityId { get; set; }
    public Guid StatusId { get; set; }
    public string StudentName { get; set; }
    public string StatusName { get; set; }
}

public class GetEnrollerActivityRequest
{
    public DateTime ActivityDate { get; set; }
}

public class EnrollerActivityResponse
{
    public DateTime ActivityDate { get; set; }
    public Guid AttendanceId { get; set; }
    public string Note { get; set; }
    public List<StudentAttendance> students { get; set; }
}
