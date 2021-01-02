using madera_api.Data;
using madera_api.DTO;
using madera_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Services
{
    public class UserService : IUserService
    {
        private readonly DbMainContext _context;

        public UserService(DbMainContext context)
        {
            _context = context;
        }

        public async Task<IList<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByID(int userID)
        {
            return await _context.Users.FindAsync(userID);
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(true);
        }

        public async Task UpdateUser(User user)
        {
            await _context.SaveChangesAsync(true);
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(true);
        }
    }
}
