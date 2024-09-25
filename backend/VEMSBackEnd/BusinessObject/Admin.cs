using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace BusinessObject
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string Username { get; set; }

        [Required]
        [MaxLength(80)]
        [Column(TypeName = "varchar")]
        [JsonIgnore]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(256)]
        [Column(TypeName = "nvarchar")]
        public string Email { get; set; }

        [Required]
        [MaxLength(80)]
        [Column(TypeName = "varchar")]
        [JsonIgnore]
        public string? RefreshToken { get; set; } = string.Empty;

        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
