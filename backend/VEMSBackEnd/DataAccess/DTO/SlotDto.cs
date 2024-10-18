using BusinessObject;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.SlotDto
{
    public class CreateSlotDto
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int SlotIndex { get; set; }
    }

    public class UpdateSlotDto
    {
        public Guid Id { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int SlotIndex { get; set; }
    }

    public class DeleteSlotDto
    {
        public Guid Id { get; set; }

    }
}
