using madera_api.DTO;
using madera_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Services
{
    public interface IModuleService
    {
        public Task<IList<ModuleDTO>> GetModules();

        public Task<ModuleDTO> GetModuleByID(int id);

        public Task CreateModule(ModuleDTO dto);

        public Task<ModuleDTO> UpdateModule(int id, ModuleDTO module);

        public Task<ModuleDTO> DeleteModule(int id);
    }
}
