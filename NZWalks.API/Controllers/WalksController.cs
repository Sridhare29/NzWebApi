using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Mapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto.WalksDto;

namespace NZWalks.API.Controllers
{
    //api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : Controller
    {
        public readonly IMapper _autoMapper;
        public WalksController(IMapper mapper)
        {
            this._autoMapper = mapper;
        }
        //POST 
        [HttpPost]
        public async Task<IActionResult> create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walkDomainModel =  _autoMapper.Map<Walk>(addWalkRequestDto);

            return Ok();
        }
    }
}

