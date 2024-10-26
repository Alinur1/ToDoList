using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CompletedTasks
    {
        [Key]
        public int completed_task_id { get; set; }
        [ForeignKey("user")]
        public string? username { get; set; }
        [ForeignKey("task")]
        public int task_id { get; set; }
        public bool? is_trashed { get; set; }

        //Foreign keys
        public User? user { get; set; }
        public TaskList? task { get; set; }
    }
}
