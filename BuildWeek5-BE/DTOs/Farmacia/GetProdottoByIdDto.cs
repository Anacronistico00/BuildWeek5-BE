using BuildWeek5_BE.DTOs.Farmacia.Fornitore;
using BuildWeek5_BE.Models.Farmacia;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia
{
    public class GetProdottoByIdDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public required string Nome { get; set; }

        public FornitoreDto? Fornitore { get; set; }

        [Required]
        public required string UsiProdotto { get; set; }

        public CassettoDto? Cassetto { get; set; }

        public List<UtenteProdottoDto>? vendite { get; set; }
    }
}
