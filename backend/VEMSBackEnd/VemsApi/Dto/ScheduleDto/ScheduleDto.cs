using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VemsApi.Dto.ScheduleDto
{
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
}
