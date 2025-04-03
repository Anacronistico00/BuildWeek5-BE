using BuildWeek5_BE.DTOs.Puppy;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Clienti
{
    public class GetClientiResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public ICollection<GetClientiDto> Customer { get; set; }
    }
}
