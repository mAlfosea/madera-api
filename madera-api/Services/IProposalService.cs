using madera_api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Services
{
    public interface IProposalService
    {
        public Task<IList<ProposalDTO>> GetProposals();

        public Task<ProposalDTO> GetProposalByID(int Id);

        public Task CreateProposal(ProposalDTO proposalDTO);

        public Task<ProposalDTO> UpdateProposal(ProposalDTO proposalDTO);

        public Task<ProposalDTO> DeleteProposal(int proposalID);
    }
}
