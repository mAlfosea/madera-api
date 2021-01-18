using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using madera_api.Data;
using madera_api.Models;
using madera_api.Services;
using AutoMapper;
using madera_api.DTO;
using Newtonsoft.Json;

namespace madera_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;
        private readonly IMapper _mapper;

        public ModuleController(IModuleService moduleService, IMapper mapper)
        {
            _moduleService = moduleService;
            _mapper = mapper;
        }

        // GET: api/Module
        [HttpGet]
        public async Task<ActionResult<IList<ModuleDTO>>> GetModules()
        {
            var modules = await _moduleService.GetModules();

            return modules.ToList();
        }

        // GET: api/Module/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleDTO>> GetModule(int id)
        {
            var module = await _moduleService.GetModuleByID(id);

            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }

        // PUT: api/Module/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(int id, ModuleDTO module)
        {
            if (id != module.Id)
            {
                return BadRequest();
            }

            var updatedModule = await _moduleService.UpdateModule(id, module);

            if (updatedModule == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Module
        [HttpPost]
        public async Task<ActionResult<ModuleDTO>> PostCollection(ModuleDTO moduleDTO)
        {
            await _moduleService.CreateModule(moduleDTO);

            return moduleDTO;
        }

        // DELETE: api/Module/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var deletedModule = await _moduleService.DeleteModule(id);

            if (deletedModule == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
