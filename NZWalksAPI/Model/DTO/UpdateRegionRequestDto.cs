using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Model.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be minimum of three characters")]
        [MaxLength(3, ErrorMessage = "Code has to be maximum of three characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be maximum of 100 characters")]
        public string Name { get; set; }
        public string? RegionImagineURL { get; set; }
    }
}
