using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia
{
    public class GetProdottoByIdResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public GetProdottoByIdDto Product { get; set; }
    }
}
