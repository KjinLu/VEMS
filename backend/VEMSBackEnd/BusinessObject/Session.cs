using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public int DayOfWeek { get; set; }

        public Guid PeriodID { get; set; }

        [ForeignKey("PeriodID")]
        public Period Period { get; set; }

        public ICollection<ScheduleDetail> ScheduleDetails { get; set; }
        public ICollection<SlotDetail> SlotDetails { get; set; }


    }
}
