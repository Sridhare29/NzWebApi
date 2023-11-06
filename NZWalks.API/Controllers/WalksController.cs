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
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await _walkRepositories.GetAllAsync();
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
    }
}

