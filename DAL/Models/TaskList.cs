using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TaskList
    {
        [Key]
        public int task_id { get; set; }
        [ForeignKey("user")]
        public int user_id { get; set; }
        public string? task_name { get; set; }
        public string? task_description { get; set; }

        //Foreign keys
        public User? user { get; set; }
    }
}
