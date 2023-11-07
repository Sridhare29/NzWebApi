using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Mapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto.DifficultyDto;
using NZWalks.API.Models.Dto.WalksDto;
using NZWalks.API.Repositories.WalkRepos;

namespace NZWalks.API.Controllers
{
    //api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : Controller
    {
        public readonly IMapper _autoMapper;
        public readonly IWalkRepositories _walkRepositories;

        public WalksController(IMapper mapper, IWalkRepositories walkRepositories)
        {
            this._autoMapper = mapper;
            this._walkRepositories = walkRepositories;
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walksDomainModel = await _walkRepositories.GetAllAsync(filterOn, filterQuery,sortBy, isAscending ?? true,pageNumber,pageSize);
            //Map Dto to Domain Model

            return Ok(_autoMapper.Map<List<Walk>>(walksDomainModel));
        }

        //POST 
        [HttpPost]
        public async Task<IActionResult> create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map Dto to Domain Model
            var walkDomainModel = _autoMapper.Map<Walk>(addWalkRequestDto);

            await _walkRepositories.CreateAsync(walkDomainModel);

            //Map Domain Model to Dto

            return Ok(_autoMapper.Map<WalkDto>(walkDomainModel));
        }

        //GET{ID}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepositories.GetByIdAsync(id);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model to Dto

            return Ok(_autoMapper.Map<WalkDto>(walkDomainModel));
        }

        //POST{ID}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            //Map Dto to Domain Model
            var walkDomainModel = _autoMapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel = await _walkRepositories.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel == null)
            {
                return NotFound();
            }
            //Map Domain Model to Dto
            return Ok(_autoMapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleteWalkDomainModel =  await _walkRepositories.DeleteAsync(id);
            if(deleteWalkDomainModel == null)
            {
                return NotFound();
            }
            //Map Domain Model to Dto
            return Ok(_autoMapper.Map<WalkDto>(deleteWalkDomainModel));
        }
    }
}

