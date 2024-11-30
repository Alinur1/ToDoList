using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.Models;

namespace ToDoList.DbAccess
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
    }
}
