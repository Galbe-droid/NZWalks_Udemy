using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Model.DTO
{
    public class AddWalkRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name maximum characters is 100")]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Description maximum characters is 1000")]
        public string Description { get; set; }
        [Required]
        [Range(0,50)]
        public double LengthInKm { get; set; }
        public string? WalkImageURL { get; set; }

        [Required]
        public Guid DifficultId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
