using AutoMapper;
using madera_api.DTO;
using madera_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Profiles
{
    public class ProjectProfile: Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
        }
    }
}
