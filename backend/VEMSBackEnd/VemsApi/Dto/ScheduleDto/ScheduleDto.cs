using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VemsApi.Dto.ScheduleDto
{
    public class CreateScheduleDto
    {
        public DateTime Time { get; set; }

        public Guid ClassroomId { get; set; }
    }

    public class UpdateScheduleDto
    {
        public Guid ScheduleDetail {  get; set; }

        public DateTime Time { get; set; }

        public Guid ClassroomId { get; set; }
    }

    public class DeleteSchedule
    {
        public Guid ScheduleDetail { get; set; }
    }

}
