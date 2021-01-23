using madera_erp_api.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_erp_api.Services
{
    public interface IUserService
    {
        public Task<IList<UserDTO>> GetUsers();

        public Task<UserDTO> GetUserByID(int userID);

        public Task CreateUser(UserDTO userDTO);

        public Task<UserDTO> UpdateUser(int id, UserDTO user);

        public Task<UserDTO> DeleteUser(int userID);
    }
}
