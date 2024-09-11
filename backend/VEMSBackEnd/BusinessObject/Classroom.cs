using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Classroom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClassName { get; set; }

        public Guid GradeId { get; set; }
        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }

        public ICollection<Schedule> Schedule { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
