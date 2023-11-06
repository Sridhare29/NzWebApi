using System;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories.WalkRepos
{
	public interface IWalkRepositories
	{
		Task<Walk> CreateAsync(Walk walk);
		Task<List<Walk>> GetAllAsync();
	}
}

