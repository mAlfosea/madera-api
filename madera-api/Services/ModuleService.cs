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
    public class ModuleService : IModuleService
    {
        private readonly DbMainContext _context;
        private readonly IMapper _mapper;

        public ModuleService(DbMainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ModuleDTO>> GetModules()
        {
            var modules = await _context.Module.Include(p => p.Components).ToListAsync();
            var ModulesDTO = _mapper.Map<IList<ModuleDTO>>(modules);
            return ModulesDTO.ToList();
        }

        public async Task<ModuleDTO> GetModuleByID(int id)
        {
            var module = await _context.Module.Include(p => p.Components).SingleOrDefaultAsync(i => i.Id == id);

            if (module == null)
            {
                return null;
            }

            return _mapper.Map<ModuleDTO>(module);
        }

        public async Task CreateModule(ModuleDTO moduleDTO)
        {
            var module = _mapper.Map<Module>(moduleDTO);

            await _context.Module.AddAsync(module);
            await _context.SaveChangesAsync(true);

            _mapper.Map(module, moduleDTO);
        }

        public async Task<ModuleDTO> DeleteModule(int id)
        {
            var module = await _context.Module.FindAsync(id);

            if (module == null)
            {
                return null;
            }

            _context.Module.Remove(module);
            await _context.SaveChangesAsync(true);

            return _mapper.Map<ModuleDTO>(module);
        }

        public async Task<ModuleDTO> UpdateModule(int id, ModuleDTO moduleDTO)
        {
            var module = await _context.Module.FindAsync(id);

            if (module == null)
            {
                return null;
            }

            _mapper.Map(moduleDTO, module);

            //collection.Modules = client;

            await _context.SaveChangesAsync(true);

            return _mapper.Map<ModuleDTO>(module);
        }
    }
}
