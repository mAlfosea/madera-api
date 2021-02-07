﻿using System;
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
        public async Task<ActionResult<IList<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetUsers();

            return users.ToList();
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

            return user;
        }

        // GET: api/User/jean
        [Route("find")]
        [HttpGet]
        public async Task<ActionResult<IList<UserDTO>>> GetUserByName([FromQuery] string userName)
        {
            var user = await _userService.GetUserByName(userName);

            if (user == null)
            {
                return NotFound();
            }

            return user.ToList();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var updatedUser = await _userService.UpdateUser(id, user);

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
            await _userService.CreateUser(userDTO);

            return userDTO;
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deletedUser = await _userService.DeleteUser(id);

            if (deletedUser == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
