using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
	public class NzWalksAuthDbContext : IdentityDbContext
	{
		public NzWalksAuthDbContext(DbContextOptions<NzWalksAuthDbContext> options) : base(options)
		{
		}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

