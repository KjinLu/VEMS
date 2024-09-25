using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class SlotDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid SubjectID { get; set; }

        public Guid TeacherID { get; set; }

        public Guid SessionID { get; set; }

        public Guid SlotID { get; set; }

        [ForeignKey("SlotID")]
        public Slot Slot { get; set; }

        [ForeignKey("TeacherID")]
        public Teacher Teacher { get; set; }

        [ForeignKey("SubjectID")]
        public Subject Subject { get; set; }

        [ForeignKey("SessionID")]
        public Session Session { get; set; }

    }
}
