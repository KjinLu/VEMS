using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Reason
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ReasonName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<AttendanceStatus> AttendanceStatuses { get; set; }
    }
}
