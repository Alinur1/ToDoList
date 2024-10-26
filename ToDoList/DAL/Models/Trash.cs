using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Trash
    {
        public int trash_id { get; set; }
        public string? username { get; set; }
        public int? completed_task_id { get; set; }
        public int? task_id { get; set; }

        //Foreign keys
        public CompletedTasks? completedTasks { get; set; }
        public Task? task { get; set; }
        public User? user { get; set; }
    }
}
