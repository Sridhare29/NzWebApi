
using System;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
	public interface IRegionRepositories
	{
	  Task<List<Region>> GetAllAsync();
	  Task<Region>	GetById(Guid id);
	}
}

