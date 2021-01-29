using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using madera_api.Data;
using madera_api.Models;
using madera_api.Services;
using AutoMapper;
using madera_api.DTO;
using Newtonsoft.Json;

namespace madera_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private readonly IProposalService _proposalService;
        private readonly IMapper _mapper;

        public ProposalController(IProposalService proposalService, IMapper mapper)
        {
            _proposalService = proposalService;
            _mapper = mapper;
        }

        // GET: api/Proposal
        [HttpGet]
        public async Task<ActionResult<IList<ProposalDTO>>> GetProposals()
        {
            var proposals = await _proposalService.GetProposals();

            return proposals.ToList();
        }

        // GET: api/Proposal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProposalDTO>> GetProposal(int id)
        {
            var proposal = await _proposalService.GetProposalByID(id);

            if (proposal == null)
            {
                return NotFound();
            }

            return Ok(proposal);
        }

        // PUT: api/Proposal/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProposal(int id, ProposalDTO proposal)
        //{
        //    if (id != proposal.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var updatedProposal = await _proposalService.UpdateProposal(id, proposal);

        //    if (updatedProposal == null)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

        // POST: api/Proposal
        [HttpPost]
        public async Task<ActionResult<ProposalDTO>> PostProposal(ProposalDTO proposalDTO)
        {
            if (proposalDTO.Id != 0)
            {
                await _proposalService.UpdateProposal(proposalDTO);
            } else
            {
                await _proposalService.CreateProposal(proposalDTO);
            }

            return proposalDTO;
        }

        // DELETE: api/Proposal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProposal(int id)
        {
            var deletedProposal = await _proposalService.DeleteProposal(id);

            if (deletedProposal == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
