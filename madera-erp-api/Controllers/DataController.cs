using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Newtonsoft.Json;
using madera_erp_api.Services;

namespace madera_erp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public DataController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        // GET: api/Data
        [HttpGet]
        public async Task<ActionResult> GenerateData()
        {
            var data = await _dataService.CreateData();

            if (!data)
            {
                return BadRequest();
            }

            return NoContent();
        }        
    }
}
