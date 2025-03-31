using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Puppy
{
    public class AddPuppyResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
