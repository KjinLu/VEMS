using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class EmailToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid AccountID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Token { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreateAt { get; set; }

    }
}
