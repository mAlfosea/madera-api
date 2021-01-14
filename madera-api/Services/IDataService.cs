using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Services
{
    public interface IDataService
    {
        public Task<bool> CreateData();
    }
}
