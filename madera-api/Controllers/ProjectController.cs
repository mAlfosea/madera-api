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

namespace madera_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IList<ProjectDTO>>> GetProjects()
        {
            var projects = await _projectService.GetProjects();

            return projects.ToList();
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProject(int id)
        {
            var project = await _projectService.GetProjectByID(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectDTO project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            var updatedProject = await _projectService.UpdateProject(id, project);

            if (updatedProject == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Project
        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> PostProject(ProjectDTO projectDTO)
        {
            await _projectService.CreateProject(projectDTO);

            return projectDTO;
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var deletedProject = await _projectService.DeleteProject(id);

            if (deletedProject == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
