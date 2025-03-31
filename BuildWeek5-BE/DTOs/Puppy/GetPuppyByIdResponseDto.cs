using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Puppy
{
    public class GetPuppyByIdResponseDto
    {
        [Required]
        public required string Message { get; set; }


        [Required]
        public GetPuppyDto Puppy { get; set; }
    }
}
