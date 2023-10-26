using System;
namespace NZWalks.MVC.Models
{
	public class Region
	{
        public Guid Id { get; set; }

        public String Code { get; set; }

        public String Name { get; set; }

        public String? RegionImageUrl { get; set; }
    }
}

