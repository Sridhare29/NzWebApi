using System;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
	public class NZWalksDbContext : DbContext
	{
		public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{

		}
		public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for Difficulties
            var difficulties = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id = Guid.Parse("1f8b9b6c-1787-4734-b262-5f711cde1d1b"),
                    Name= "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("711857ad-1245-43f5-880b-5b139f5e461c"),
                    Name= "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("524b1946-edfa-4a06-af13-b477ab0a537e"),
                    Name= "Hard"
                }
            };
            //seed Difficulties to the Database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //seed data for Regions
            var regions = new List<Region>()
        {
            new Region
            {
                Id = Guid.Parse("ad1a9601-1d15-4248-aaf4-838ec193465e"),
                Code = "AKL",
                Name = "Auckland",
                RegionImageUrl="https://img.veenaworld.com/wp-content/uploads/2023/04/Top-10-Best-Hotels-in-the-Magnificent-City-of-Auckland.jpg"
            },
            new Region
            {
                Id = Guid.Parse("4ad912a1-3d03-495b-a0d9-1f1834b621fe"),
                Code = "NTL",
                Name = "Northland",
                RegionImageUrl=null
            },
            new Region
            {
                Id = Guid.Parse("0f4e7d9d-cdd8-4b82-ac68-a33391ae1046"),
                Code = "Bay of Plenty",
                Name = "BOP",
                RegionImageUrl="https://www.newzealand.com/assets/Tourism-NZ/Bay-of-Plenty/mountsummit-Katie-Cox__aWxvdmVrZWxseQo_CropResizeWzEyMDAsNjMwLDc1LCJqcGciXQ.jpg"
            },
            new Region
            {
                Id = Guid.Parse("46828463-1ae4-49bc-ad48-1ef331abdbf9"),
                Code = "WGN",
                Name = "Wellington",
                RegionImageUrl="https://www.planetware.com/wpimages/2022/11/new-zealand-wellington-top-attractions-intro-paragraph-wellington-downtown-harbour.jpg"
            },
            new Region
            {
                Id = Guid.Parse("a1a8e84e-c785-4079-8e4f-629fbf8ad57b"),
                Code = "NSN",
                Name = "Nelson",
                RegionImageUrl="https://images.rawpixel.com/image_450/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvYTAwMi1pc3dhbnRvYS0zNC5qcGc.jpg"
            },
            new Region
            {
                Id = Guid.Parse(""),
                Code = "STL",
                Name = "Southland",
                RegionImageUrl=null
            },
        };
            //seed Regions to the Database
            modelBuilder.Entity<Region>().HasData(regions);
        }

    }
}

