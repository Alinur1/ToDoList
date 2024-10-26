using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICompletedTask
    {
        Task<IEnumerable<CompletedTask>> GetAllCompletedTaskAsync();
        Task<CompletedTask?> GetCompletedTaskByIdAsync(int id);
        Task<CompletedTask> AddCompletedTaskAsync(CompletedTask completedTask);
        Task<CompletedTask> UpdateCompletedTaskAsync(CompletedTask completedTask);
        Task<bool> DeleteCompletedTaskAsync(int id);
    }
}
