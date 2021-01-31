using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using madera_erp_api.Services;
using madera_erp_api.DTO;

namespace madera_erp_api.Controllers
{
    [Route("api-erp/[controller]")]
    [ApiController]
    public class UserSynchController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserSynchController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var updatedUser = await _userService.SynchUpdateUser(id, user);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDTO)
        {
            await _userService.SynchCreateUser(userDTO);

            return userDTO;
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deletedUser = await _userService.SynchDeleteUser(id);

            if (deletedUser == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
