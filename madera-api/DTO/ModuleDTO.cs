using madera_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.DTO
{
    public class ModuleDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nature { get; set; }

        public string Trait { get; set; }

        public string Unite { get; set; }

        public ICollection<Collection> Collections { get; set; }

        public ICollection<Component> Components { get; set; }
    }
}
