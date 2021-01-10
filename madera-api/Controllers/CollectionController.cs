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
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionService _collectionService;
        private readonly IMapper _mapper;

        public CollectionController(ICollectionService collectionService, IMapper mapper)
        {
            _collectionService = collectionService;
            _mapper = mapper;
        }

        // GET: api/Collection
        [HttpGet]
        public async Task<ActionResult<IList<CollectionDTO>>> GetCollections()
        {
            var collections = await _collectionService.GetCollections();

            return collections.ToList();
        }

        // GET: api/Collection/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollectionDTO>> GetCollection(int id)
        {
            var collection = await _collectionService.GetCollectionByID(id);

            if (collection == null)
            {
                return NotFound();
            }

            return collection;
        }

        // PUT: api/Collection/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollection(int id, CollectionDTO collection)
        {
            if (id != collection.Id)
            {
                return BadRequest();
            }

            var updatedCollection = await _collectionService.UpdateCollection(id, collection);

            if (updatedCollection == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Collection
        [HttpPost]
        public async Task<ActionResult<CollectionDTO>> PostCollection(CollectionDTO collectionDTO)
        {
            await _collectionService.CreateCollection(collectionDTO);

            return collectionDTO;
        }

        // DELETE: api/Collection/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var deletedCollection = await _collectionService.DeleteCollection(id);

            if (deletedCollection == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
