using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Dto.WalksDto;

namespace NZWalks.API.Controllers
{
    //api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : Controller
    {
        //POST 
        [HttpPost]
        public async Task<IActionResult> create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            return Ok();
        }
    }
}

