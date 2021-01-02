using madera_api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Services
{
    public interface IProjectService
    {
        public Task<IList<ProjectDTO>> GetProjects();

        public Task<ProjectDTO> GetProjectByID(int Id);

        public Task CreateProject(ProjectDTO projectDTO);

        public Task<ProjectDTO> UpdateProject(int id, ProjectDTO projectDTO);

        public Task<ProjectDTO> DeleteProject(int projectID);
    }
}
