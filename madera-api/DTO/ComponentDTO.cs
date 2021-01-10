using madera_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.DTO
{
    public class ComponentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nature { get; set; }

        public string Trait { get; set; }

        public string Unite { get; set; }

        public double Price { get; set; }

        public ICollection<Module> Modules { get; set; }
    }
}
