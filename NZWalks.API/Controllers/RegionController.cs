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
    [Route("api/[controller]/[action]")]
    [ApiController]
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
                if (regionDomain == null)
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
         public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
         {
        if (ModelState.IsValid)
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
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                //check if region is exists
                var regionsDomainModel = _dbContext.Regions.FirstOrDefault(x => x.Id == id);

                if (regionsDomainModel == null)
                {
                    return NotFound();
                }
                //map Dto to Domain Model
                regionsDomainModel.Code = updateRegionRequestDto.Code;
                regionsDomainModel.Name = updateRegionRequestDto.Name;
                regionsDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

                _dbContext.SaveChanges();

                //Convert DomainModel to Dto
                var regionDto = new RegionDto
                {
                    Id = regionsDomainModel.Id,
                    Code = regionsDomainModel.Code,
                    Name = regionsDomainModel.Name,
                    RegionImageUrl = regionsDomainModel.RegionImageUrl
                };

                return Ok(regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var regionsDomainModel = _dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(regionsDomainModel == null)
            {
                return NotFound();
            }

            _dbContext.Regions.Remove(regionsDomainModel);
            _dbContext.SaveChanges();
            // return deleted region back
            //map Domain Model to Dto
            var regionDto = new RegionDto
            {
                Id = regionsDomainModel.Id,
                Code = regionsDomainModel.Code,
                Name = regionsDomainModel.Name,
                RegionImageUrl = regionsDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }
        
    }
}

