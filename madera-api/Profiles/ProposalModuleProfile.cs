using AutoMapper;
using madera_api.DTO;
using madera_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Profiles
{
    public class ProposalModuleProfile : Profile
    {
        public ProposalModuleProfile()
        {
            CreateMap<ProposalModule, ProposalModuleDTO>();
            CreateMap<ProposalModuleDTO, ProposalModule>()
                .ForMember(dest => dest.Module, act => act.Ignore())
                .ForMember(dest => dest.Proposal, act => act.Ignore());
        }
    }
}
