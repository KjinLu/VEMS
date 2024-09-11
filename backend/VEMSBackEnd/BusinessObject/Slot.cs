using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Slot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime StartTime { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime EndTime { get; set; }

        [Required]
        public int SlotIndex { get; set; }

        public ICollection<SlotDetail> SlotDetails { get; set; }
    }
}
