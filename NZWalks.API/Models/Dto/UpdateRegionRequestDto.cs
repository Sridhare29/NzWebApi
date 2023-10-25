using System;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.Dto
{
	public class UpdateRegionRequestDto
	{
        [Required]
        [MinLength(3, ErrorMessage = "required minimum of 3 character")]
        [MaxLength(3, ErrorMessage = "required maximum of 3 character")]
        public String Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be maximum 100 character")]
        public String Name { get; set; }

        public String? RegionImageUrl { get; set; }
    }
}

