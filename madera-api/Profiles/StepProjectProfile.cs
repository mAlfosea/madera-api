using AutoMapper;
using madera_api.DTO;
using madera_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Profiles
{
    public class StepProjectProfile : Profile
    {
        public StepProjectProfile()
        {
            CreateMap<StepProject, StepProjectDTO>();
            CreateMap<StepProjectDTO, StepProject>();
        }
    }
}
