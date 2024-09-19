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
        public string StartTime { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public string EndTime { get; set; }

        [Required]
        public int SlotIndex { get; set; }

        public ICollection<SlotDetail> SlotDetail { get; set; }
    }
}
