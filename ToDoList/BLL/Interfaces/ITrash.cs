using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface Trash
    {
        Task<IEnumerable<Trash>> GetAllTrashAsync();
        Task<Trash?> GetTrashByIdAsync(int id);
        Task<Trash> AddTrashAsync(Trash trash);
        Task<Trash> UpdateTrashAsync(Trash trash);
        Task<bool> DeleteTrashAsync(int id);
    }
}
