using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VemsApi.Dto.ScheduleDto
{
    /// <summary>
    ///  Schedule DTO
    /// </summary>
    public class GetClassSchedule
    {
        public Guid ClassroomId { get; set; }
    }

    public class CreateScheduleDto
    {
        public string Time { get; set; }
        public Guid ClassroomId { get; set; }
    }

    public class UpdateScheduleDto
    {
        public Guid ScheduleId { get; set; }
        public string Time { get; set; }
        public Guid ClassroomId { get; set; }
    }

    public class DeleteSchedule
    {
        public Guid ScheduleId { get; set; }
    }

    // Schedule details
    public class CreateScheduleDetailRequest
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
        public Guid TeacherID { get; set; }
        public Guid SlotID { get; set; }
    }

}
