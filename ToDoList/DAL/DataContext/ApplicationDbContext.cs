using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<CompletedTasks> completed_task { get; set; }
        public DbSet<TaskList> task_list { get; set; }
        public DbSet<Trash> trash { get; set; }
        public DbSet<User> user { get; set; }
    }
}
