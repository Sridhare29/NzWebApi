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

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var existingWalk = await _nZWalksDb.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(existingWalk == null)
            {
                return null;
            }

            _nZWalksDb.Walks.Remove(existingWalk);
            await _nZWalksDb.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null)
        {
            var walks =  _nZWalksDb.Walks.Include("Difficulty").Include("Region").AsQueryable();

            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }
            return await walks.ToListAsync();
            //Add the Naigation props for Difficulty & Region to get
            //return await _nZWalksDb.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk> GetByIdAsync(Guid id)
        {
            //Add the Naigation props for Difficulty & Region to getby id
            return await _nZWalksDb.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await _nZWalksDb.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingWalk == null)
             {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await _nZWalksDb.SaveChangesAsync();

            return existingWalk;

        }
    }
}

