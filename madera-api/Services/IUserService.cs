using madera_api.DTO;
using madera_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Services
{
    public interface IUserService
    {
        public Task<IList<User>> GetUsers();

        public Task<User> GetUserByID(int userID);

        public Task CreateUser(User user);

        public Task UpdateUser(User user);

        public Task DeleteUser(User userID);
    }
}
