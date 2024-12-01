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
        Task<TaskList> GetTaskListByIdAsync(int id);
        Task<TaskList> AddTaskListAsync(TaskList taskList);
        Task<TaskList> UpdateTaskListAsync(TaskList taskList);
        Task<bool> DeleteTaskListAsync(int id);
    }
}
