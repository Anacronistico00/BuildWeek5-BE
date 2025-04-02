using BuildWeek5_BE.Models.Auth;
using BuildWeek5_BE.Models.Farmacia;
using BuildWeek5_BE.DTOs.Farmacia.Fornitore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia
{
    public class GetProdottoDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public required string Nome { get; set; }

        public FornitoreDto? Fornitore { get; set; }

        [Required]
        public required string UsiProdotto { get; set; }

        public CassettoDto? Cassetto { get; set; }
    }
}
