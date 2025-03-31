using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Puppy
{
    public class GetAnimaleResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public ICollection<GetAnimaleDto> Puppies { get; set; }
    }
}
