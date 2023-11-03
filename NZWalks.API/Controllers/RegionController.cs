using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepositories regionRepositories;
        private readonly IMapper _mapper;
        public RegionController(IRegionRepositories regionRepositories,IMapper mapper)
        {
            this.regionRepositories = regionRepositories;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await regionRepositories.GetAllAsync();

            //var regionDto = new List<RegionDto>();
            //foreach(var regionDomain in regionsDomain)
            //{
            //    regionDto.Add(new RegionDto()
            //    {
            //        Id = regionDomain.Id,
            //        Code = regionDomain.Code,
            //        Name = regionDomain.Name,
            //        RegionImageUrl = regionDomain.RegionImageUrl,
            //    });
            //}
            //AutoMapper
            var regionDto = _mapper.Map<List<RegionDto>>(regionsDomain);

            return Ok(regionDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await regionRepositories.GetByIdAsync(id);
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
         public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
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
                regionDomainModel = await regionRepositories.CreateAsync(regionDomainModel);

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
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                //Map DTO to Domain Model
                var regionsDomainModel = new Region
                {
                    Code = updateRegionRequestDto.Code,
                    Name = updateRegionRequestDto.Name,
                    RegionImageUrl = updateRegionRequestDto.RegionImageUrl
                };

                //check if region is exists
                regionsDomainModel = await regionRepositories.UpdateAsync(id, regionsDomainModel);

                if (regionsDomainModel == null)
                {
                    return NotFound();
                }
                //map Dto to Domain Model
                regionsDomainModel.Code = updateRegionRequestDto.Code;
                regionsDomainModel.Name = updateRegionRequestDto.Name;
                regionsDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;


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
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionsDomainModel = await regionRepositories.DeleteAsync(id);
            if(regionsDomainModel == null)
            {
                return NotFound();
            }

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

