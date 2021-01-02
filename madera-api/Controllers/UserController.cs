using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using madera_api.Models;
using AutoMapper;
using madera_api.DTO;
using AutoMapper.QueryableExtensions;
using madera_api.Data;
using madera_api.Services;

namespace madera_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            var usersDTO = _mapper.Map<IList<UserDTO>>(users);

            return usersDTO.ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _userService.GetUserByID(id);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserDTO>(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            User dbUser = await _userService.GetUserByID(id);

            if (dbUser == null)
            {
                return NotFound();
            }

            _mapper.Map(user, dbUser);

            await _userService.UpdateUser(dbUser);

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            await _userService.CreateUser(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, _mapper.Map<UserDTO>(user));
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            User dbUser = await _userService.GetUserByID(id);

            if (dbUser == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(dbUser);

            return NoContent();
        }
    }
}
