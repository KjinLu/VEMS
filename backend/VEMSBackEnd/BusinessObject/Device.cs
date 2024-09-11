using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid AccountID { get; set; }
        
        [Required]
        public string DeviceInfo { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime LastLogin { get; set; }
    }
}
