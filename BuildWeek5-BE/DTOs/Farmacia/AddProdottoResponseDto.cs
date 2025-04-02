using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia
{
    public class AddProdottoResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
