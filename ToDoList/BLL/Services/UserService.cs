using Microsoft.EntityFrameworkCore;
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

        public async Task<User> AddUserAsync(User user)
        {
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var existingUser = await _context.users.FindAsync(id);
            if(existingUser != null)
            {
                _context.users.Remove(existingUser);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.users.FindAsync(id);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var existingUser = await _context.users.FindAsync(user.id);
            if(existingUser != null)
            {
                existingUser.full_name = user.full_name;
                existingUser.email = user.email;

                _context.users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
            return existingUser ?? throw new KeyNotFoundException("User not found");
        }
    }
}
