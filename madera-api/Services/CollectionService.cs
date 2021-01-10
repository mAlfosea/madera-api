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
    public class CollectionService : ICollectionService
    {
        private readonly DbMainContext _context;
        private readonly IMapper _mapper;

        public CollectionService(DbMainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<CollectionDTO>> GetCollections()
        {
            var collections = await _context.Collection.ToListAsync();
            var CollectionsDTO = _mapper.Map<IList<CollectionDTO>>(collections);
            return CollectionsDTO.ToList();
        }

        public async Task<CollectionDTO> GetCollectionByID(int id)
        {
            var collection = await _context.Collection.SingleOrDefaultAsync(i => i.Id == id);

            if (collection == null)
            {
                return null;
            }

            return _mapper.Map<CollectionDTO>(collection);
        }

        public async Task CreateCollection(CollectionDTO collectionDTO)
        {
            var collection = _mapper.Map<Collection>(collectionDTO);

            await _context.Collection.AddAsync(collection);
            await _context.SaveChangesAsync(true);

            _mapper.Map(collection, collectionDTO);
        }

        public async Task<CollectionDTO> DeleteCollection(int id)
        {
            var collection = await _context.Collection.FindAsync(id);

            if (collection == null)
            {
                return null;
            }

            _context.Collection.Remove(collection);
            await _context.SaveChangesAsync(true);

            return _mapper.Map<CollectionDTO>(collection);
        }

        public async Task<CollectionDTO> UpdateCollection(int id, CollectionDTO collectionDTO)
        {
            var collection = await _context.Collection.FindAsync(id);

            if (collection == null)
            {
                return null;
            }

            _mapper.Map(collectionDTO, collection);

            //collection.Modules = client;

            await _context.SaveChangesAsync(true);

            return _mapper.Map<CollectionDTO>(collection);
        }
    }
}
