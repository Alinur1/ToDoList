using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Task
    {
        [Key]
        public int task_id { get; set; }
        [ForeignKey("user")]
        public string? username { get; set; }
        public string? tasks { get; set; }
        public string? description { get; set; }
        public bool? is_completed { get; set; }

        //Foreign keys
        public User? user { get; set; }
    }
}
