using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;

        public RegionController(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _dbContext.Regions.ToList();
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var regions = _dbContext.Regions.Find(id);
            if(regions == null)
            {
                return NotFound();
            }
            return Ok(regions);
        }

        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

