using System;
namespace NZWalks.API.Models.Dto.WalksDto
{
	public class WalkDto
	{
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String LengthInKm { get; set; }

        public String? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }
    }
}

