using AutoMapper;
using madera_api.Data;
using madera_api.DTO;
using madera_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Services
{
    public class ProposalService : IProposalService
    {
        private readonly DbMainContext _context;
        private readonly IMapper _mapper;

        public ProposalService(DbMainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ProposalDTO>> GetProposals()
        {
            var proposals = await _context.Proposal.ToListAsync();

            var proposalsDTO = _mapper.Map<IList<ProposalDTO>>(proposals);
            return proposalsDTO.ToList();
        }

        public async Task<ProposalDTO> GetProposalByID(int Id)
        {
            var proposal = await _context.Proposal.Include(p => p.ProposalModules).SingleOrDefaultAsync(i => i.Id == Id);

            if (proposal == null)
            {
                return null;
            }

            return _mapper.Map<ProposalDTO>(proposal);
        }

        public async Task CreateProposal(ProposalDTO proposalDTO)
        {
            var proposalDTOTemp = proposalDTO;
            proposalDTOTemp.CreationDate = DateTime.Now;
            var proposalModuleDTO = proposalDTO.ProposalModules;
            proposalDTOTemp.ProposalModules = null;

            var proposal = _mapper.Map<Proposal>(proposalDTOTemp);

            await _context.Proposal.AddAsync(proposal);
            await _context.SaveChangesAsync(true);

            foreach (var obj in proposalModuleDTO)
            {
                obj.ProposalId = proposal.Id;
                var proposalModule = _mapper.Map<ProposalModule>(obj);

                await _context.ProposalModule.AddAsync(proposalModule);
            }

            await _context.SaveChangesAsync(true);

            _mapper.Map(proposal, proposalDTO);
        }

        public async Task<ProposalDTO> UpdateProposal(ProposalDTO proposalDTO)
        {
            var proposalDb = await _context.Proposal.FindAsync(proposalDTO.Id);

            if (proposalDb != null)
            {
                var proposalDTOTemp = proposalDTO;
                var proposalModuleDTO = proposalDTO.ProposalModules;
                proposalDTOTemp.ProposalModules = null;

                _mapper.Map(proposalDTOTemp, proposalDb);

                await _context.SaveChangesAsync(true);

                var proposalmodulesDb = await _context.ProposalModule.Where(pm => pm.ProposalId == proposalDb.Id).ToListAsync();

                var modulesToRemove = new List<ProposalModule>();

                foreach(var obj in proposalmodulesDb)
                {
                    if (!proposalModuleDTO.Any(pm => pm.Id == obj.Id))
                    {
                        modulesToRemove.Add(obj);
                    }
                }
                foreach(var pmToRemove in modulesToRemove)
                {
                    _context.ProposalModule.Remove(pmToRemove);
                }

                foreach (var obj in proposalModuleDTO)
                {
                    var proposalModuleDb = new ProposalModule();

                    if (obj.Id != 0)
                    {
                        proposalModuleDb = proposalmodulesDb.FirstOrDefault(pm => pm.Id == obj.Id);
                        _mapper.Map(obj, proposalModuleDb);
                    } else
                    {
                        obj.ProposalId = proposalDb.Id;
                        proposalModuleDb = _mapper.Map<ProposalModule>(obj);
                        await _context.ProposalModule.AddAsync(proposalModuleDb);
                    }
                }

                await _context.SaveChangesAsync(true);

                return _mapper.Map(proposalDb, proposalDTO);
            } else
            {
                return null;
            }
        }

        public async Task<ProposalDTO> DeleteProposal(int proposalID)
        {
            var proposal = await _context.Proposal.FindAsync(proposalID);

            if (proposal == null)
            {
                return null;
            }

            _context.Proposal.Remove(proposal);
            await _context.SaveChangesAsync(true);

            return _mapper.Map<ProposalDTO>(proposal);
        }
    }
}
