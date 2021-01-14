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

        public virtual ICollection<CollectionDTO> Collections { get; set; }

        public virtual ICollection<ComponentDTO> Components { get; set; }

        public List<ProposalModuleDTO> ProposalModules { get; set; }
    }
}
