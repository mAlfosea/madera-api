using AutoMapper;
using madera_api.DTO;
using madera_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Profiles
{
    public class ModuleProfile : Profile
    {
        public ModuleProfile()
        {
            CreateMap<Module, ModuleDTO>();
            CreateMap<ModuleDTO, Module>();
        }
    }
}
