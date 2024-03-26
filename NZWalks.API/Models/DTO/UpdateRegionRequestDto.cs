using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name has to have 100 characters or less")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
