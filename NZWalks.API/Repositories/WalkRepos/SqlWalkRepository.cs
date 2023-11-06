using System;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories.WalkRepos
{
	public class SqlWalkRepository : IWalkRepositories
	{
        public readonly NZWalksDbContext _nZWalksDb;
		public SqlWalkRepository(NZWalksDbContext nZWalksDb)
		{
            this._nZWalksDb = nZWalksDb;
		}

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _nZWalksDb.Walks.AddAsync(walk);
            await _nZWalksDb.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await _nZWalksDb.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }
    }
}

