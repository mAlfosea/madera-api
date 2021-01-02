using AutoMapper;
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
    public class ProjectService : IProjectService
    {
        private readonly DbMainContext _context;
        private readonly IMapper _mapper;

        public ProjectService(DbMainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ProjectDTO>> GetProjects()
        {
            var projects = await _context.Projects.Include(p => p.Client).ToListAsync();
            var projectsDTO = _mapper.Map<IList<ProjectDTO>>(projects);
            return projectsDTO.ToList();
        }

        public async Task<ProjectDTO> GetProjectByID(int Id)
        {
            var project = await _context.Projects.Include(p => p.Client).SingleOrDefaultAsync(i => i.Id == Id);

            if (project == null)
            {
                return null;
            }

            return _mapper.Map<ProjectDTO>(project);
        }

        public async Task CreateProject(ProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);
            var client = await _context.Users.FindAsync(projectDTO.Client.Id);

            project.Client = client;

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync(true);

            _mapper.Map(project, projectDTO);
        }

        public async Task<ProjectDTO> DeleteProject(int projectID)
        {
            var project = await _context.Projects.FindAsync(projectID);

            if (project == null)
            {
                return null;
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync(true);

            return _mapper.Map<ProjectDTO>(project);
        }

        public async Task<ProjectDTO> UpdateProject(int id, ProjectDTO projectDTO)
        {
            var project = await _context.Projects.FindAsync(id);

            var client = await _context.Users.FindAsync(projectDTO.Client.Id);

            if (project == null || client == null)
            {
                return null;
            }

            _mapper.Map(projectDTO, project);

            project.Client = client;

            await _context.SaveChangesAsync(true);

            return _mapper.Map<ProjectDTO>(project);
        }
    }
}
