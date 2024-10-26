using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITaskList
    {
        Task<IEnumerable<TaskList>> GetAllTaskListAsync();
        Task<TaskList?> GetTaskListByIdAsync(int id);
        Task<TaskList> AddTaskListAsync(Task task);
        Task<TaskList> UpdateTaskListAsync(Task task);
        Task<bool> DeleteTaskListAsync(int id);
    }
}
