using ToDoList.BLL.Interfaces;
using ToDoList.DAL.Models;
using ToDoList.DbAccess;

namespace ToDoList.BLL.Services
{
    public class UserService : IUser
    {
        private readonly ToDoContext _context;
        public UserService(ToDoContext context)
        {
            _context = context;
        }
        public Task<User> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User>? GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
