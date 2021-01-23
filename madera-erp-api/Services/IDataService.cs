using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_erp_api.Services
{
    public interface IDataService
    {
        public Task<bool> CreateData();
    }
}
