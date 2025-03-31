using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Puppy
{
    public class GetAnimaleByIdResponseDto
    {
        [Required]
        public required string Message { get; set; }


        [Required]
        public GetAnimaleDto Puppy { get; set; }
    }
}
