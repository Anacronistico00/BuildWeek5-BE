using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Puppy
{
    public class GetPuppyResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public ICollection<GetPuppyDto> Puppies { get; set; }
    }
}
