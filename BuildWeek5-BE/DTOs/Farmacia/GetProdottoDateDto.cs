using BuildWeek5_BE.DTOs.Farmacia.Fornitore;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia
{
    public class GetProdottoDateDto
    {
        [Required]
        [StringLength(100)]
        public required string Nome { get; set; }

        [Required]
        public required string NomeCliente { get; set; }

        [Required]
        public required DateOnly DataAcquisto { get; set; }
    }
}
