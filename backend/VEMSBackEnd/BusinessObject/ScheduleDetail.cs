using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ScheduleDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Schedule ScheduleId { get; set; }

        [ForeignKey("ScheduleId")]
        public Schedule Schedule { get; set; }

        public Session SessionId { get; set; }

        [ForeignKey("SessionId")]
        public Session Session { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

    }
}
