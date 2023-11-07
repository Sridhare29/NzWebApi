using System;
namespace NZWalks.API.Models.Dto.WalksDto
{
	public class UpdateWalkRequestDto
	{
        public String Name { get; set; }

        public String Description { get; set; }

        public double LengthInKm { get; set; }

        public String? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }
    }
}

