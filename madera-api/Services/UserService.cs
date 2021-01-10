using AutoMapper;
using madera_api.Data;
using madera_api.DTO;
using madera_api.Models;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;

        public UserService(DbMainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<UserDTO>> GetUsers()
        {
            var users = await _context.User.ToListAsync();
            var usersDTO = _mapper.Map<IList<UserDTO>>(users);
            return usersDTO.ToList();
        }

        public async Task<UserDTO> GetUserByID(int userID)
        {
            var user = await _context.User.FindAsync(userID);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserDTO>(user);
        }

        public async Task CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.Password = "1234";

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync(true);

            _mapper.Map(user, userDTO);
        }

        public async Task<UserDTO> UpdateUser(int id, UserDTO userDTO)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            _mapper.Map(userDTO, user);

            await _context.SaveChangesAsync(true);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> DeleteUser(int userID)
        {
            var user = await _context.User.FindAsync(userID);

            if (user == null)
            {
                return null;
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync(true);

            return _mapper.Map<UserDTO>(user);
        }
    }
}
