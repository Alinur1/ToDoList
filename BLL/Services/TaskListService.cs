using BLL.Interfaces;
using DAL.DataAccess;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TaskListService : ITaskList
    {
        private readonly ToDoContext _context;

        public TaskListService(ToDoContext context)
        {
            _context = context;
        }

        public async Task<TaskList> AddTaskListAsync(TaskList taskList)
        {
            await _context.task_list.AddAsync(taskList);
            await _context.SaveChangesAsync();
            return taskList;
        }

        public async Task<bool> DeleteTaskListAsync(int id)
        {
            var existingTaskList = await _context.task_list.FindAsync(id);
            if (existingTaskList != null)
            {
                _context.task_list.Remove(existingTaskList);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TaskList>> GetAllTaskListAsync()
        {
            return await _context.task_list.ToListAsync();
        }

        public async Task<TaskList> GetTaskListByIdAsync(int id)
        {
            return await _context.task_list.FindAsync(id);
        }

        public async Task<TaskList> UpdateTaskListAsync(TaskList taskList)
        {
            var existingTaskList = await _context.task_list.FindAsync(taskList.task_id);
            if (existingTaskList != null)
            {
                existingTaskList.task_name = taskList.task_name;
                existingTaskList.task_description = taskList.task_description;

                _context.task_list.Update(existingTaskList);
                await _context.SaveChangesAsync();
            }
            return taskList ?? throw new KeyNotFoundException("Task not found.");
        }
    }
}
