using madera_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.DTO
{
    public class CollectionDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Module> Modules { get; set; }
    }
}
