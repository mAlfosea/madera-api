using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.DTO
{
    public class ProposalModuleDTO
    {
        public int Id { get; set; }

        public int ProposalId { get; set; }
        public ProposalDTO Proposal { get; set; }

        public int ModuleId { get; set; }
        public ModuleDTO Module { get; set; }

        public int Quantity { get; set; }
    }
}
