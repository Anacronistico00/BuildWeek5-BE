using BuildWeek5_BE.DTOs.Puppy;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia
{
    public class GetProdottoResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public ICollection<GetProdottoDto> Products { get; set; }
    }
}
