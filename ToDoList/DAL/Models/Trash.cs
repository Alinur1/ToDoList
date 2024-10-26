using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Trash
    {
        public int trash_id { get; set; }
        [ForeignKey("user")]
        public string? username { get; set; }
        [ForeignKey("completedTasks")]
        public int? completed_task_id { get; set; }
        [ForeignKey("task")]
        public int? task_id { get; set; }

        //Foreign keys
        public CompletedTask? completedTasks { get; set; }
        public TaskList? task { get; set; }
        public User? user { get; set; }
    }
}
