using System;
namespace NZWalks.API.Models.Dto
{
	public class UpdateRegionRequestDto
	{
        public String Code { get; set; }

        public String Name { get; set; }

        public String? RegionImageUrl { get; set; }
    }
}

