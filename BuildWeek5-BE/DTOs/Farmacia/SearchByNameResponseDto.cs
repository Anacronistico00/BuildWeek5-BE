
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia.DtosProdotto
{
    public class SearchByNameResponseDto
    {
        [Required]
        public required string Message { get; set; }

        [Required]
        public ICollection<GetProdottoDto> Prodotti { get; set; }
    }
}
