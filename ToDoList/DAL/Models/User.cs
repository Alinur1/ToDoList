using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key]
        [Required]
        [StringLength(500)]
        public string? username { get; set; }
        [Required]
        [StringLength(50)]
        public string? password { get; set; }
        [EmailAddress]
        [StringLength(50)]
        public string? email { get; set; }
    }
}
