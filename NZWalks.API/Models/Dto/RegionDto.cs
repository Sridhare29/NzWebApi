using System;
namespace NZWalks.API.Models.Dto
{
	public class RegionDto
	{
        public Guid Id { get; set; }

        public String Code { get; set; }

        public String Name { get; set; }

        public String? RegionImageUrl { get; set; }
    }
}

