using System;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
	public class SqlRegionRepository : IRegionRepositories
	{
        private readonly NZWalksDbContext dbContext;

        public SqlRegionRepository(NZWalksDbContext nZWalksDbContext)
		{
            this.dbContext = nZWalksDbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetById(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

