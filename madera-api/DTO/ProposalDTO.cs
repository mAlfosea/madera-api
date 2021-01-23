using madera_api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.DTO
{
    public class ProposalDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProjectId { get; set; }

        public ProjectDTO Project { get; set; }

        public int CommercialId { get; set; }

        public UserDTO Commercial { get; set; }

        public byte[] CreationDate { get; set; }

        public ProposalEnum Status { get; set; }

        public List<ProposalModuleDTO> ProposalModules { get; set; }
    }
}
