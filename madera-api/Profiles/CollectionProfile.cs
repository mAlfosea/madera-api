using AutoMapper;
using madera_api.DTO;
using madera_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Profiles
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            CreateMap<Collection, CollectionDTO>();
            CreateMap<CollectionDTO, Collection>();
        }
    }
}
