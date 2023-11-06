using System;
namespace NZWalks.API.Models.Dto.DifficultyDto
{
	public class WalkDto
	{
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String LengthInKm { get; set; }

        public String? WalkImageUrl { get; set; }

        public RegionDto Region { get; set; }

        public DifficultyDto Difficulty { get; set; }
    }
}

