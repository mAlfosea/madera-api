using madera_api.DTO;
using madera_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Services
{
    public interface ICollectionService
    {
        public Task<IList<CollectionDTO>> GetCollections();

        public Task<CollectionDTO> GetCollectionByID(int id);

        public Task CreateCollection(CollectionDTO dto);

        public Task<CollectionDTO> UpdateCollection(int id, CollectionDTO collection);

        public Task<CollectionDTO> DeleteCollection(int id);
    }
}
