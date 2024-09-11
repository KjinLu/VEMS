using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string StatusName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        public ICollection<AttendanceStatus> AttendanceStatuses { get; set; }

    }
}
