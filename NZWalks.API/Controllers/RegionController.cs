using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;

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
            var regionsDomain = _dbContext.Regions.ToList();

            var regionDto = new List<RegionDto>();
            foreach(var regionDomain in regionsDomain)
            {
                regionDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl,
                });
            }
            return Ok(regionDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var regionDomain = _dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(regionDomain == null)
            {
                return NotFound();
            }
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };
            return Ok(regionDto);
        }

        [HttpPost]
         public IActionResult create([FromBody] AddRegionRequestDto addRegionRequestDto)
         {
            //Map or Convert DTO to Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            //Use Domain Model to create Region
            _dbContext.Regions.Add(regionDomainModel);
            _dbContext.SaveChanges();

            //Map Domain Model back to Dto
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id  }, regionDto);
         }

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

