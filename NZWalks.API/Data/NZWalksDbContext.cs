using System;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
	public class NZWalksDbContext : DbContext
	{
		public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
		{

		}
		public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for Difficulties
            //Easy,Medium & Hard
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
                Id = Guid.Parse("69307f13-cd58-4623-88cb-b26a54098fa9"),
                Code = "AKL",
                Name = "Auckland",
                RegionImageUrl="https://img.veenaworld.com/wp-content/uploads/2023/04/Top-10-Best-Hotels-in-the-Magnificent-City-of-Auckland.jpg"
            },
            new Region
            {
                Id = Guid.Parse("a9997679-45b9-45ce-a50f-6dabc4564965"),
                Code = "NTL",
                Name = "Northland",
                RegionImageUrl=null
            },
            new Region
            {
                Id = Guid.Parse("a473c74e-b0a3-46e3-85de-f83b9449991b"),
                Code = "Bay of Plenty",
                Name = "BOP",
                RegionImageUrl="https://www.newzealand.com/assets/Tourism-NZ/Bay-of-Plenty/mountsummit-Katie-Cox__aWxvdmVrZWxseQo_CropResizeWzEyMDAsNjMwLDc1LCJqcGciXQ.jpg"
            },
            new Region
            {
                Id = Guid.Parse("c9c7c613-f12e-43fd-9f1a-5993cc8f68f0"),
                Code = "WGN",
                Name = "Wellington",
                RegionImageUrl="https://www.planetware.com/wpimages/2022/11/new-zealand-wellington-top-attractions-intro-paragraph-wellington-downtown-harbour.jpg"
            },
            new Region
            {
                Id = Guid.Parse("57ceb9cc-d451-460d-b2f9-c156dbe9bd83"),
                Code = "NSN",
                Name = "Nelson",
                RegionImageUrl="https://images.rawpixel.com/image_450/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvYTAwMi1pc3dhbnRvYS0zNC5qcGc.jpg"
            },
            new Region
            {
                Id = Guid.Parse("d446aedc-b6d9-41d3-ae30-0a2e1973c210"),
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

