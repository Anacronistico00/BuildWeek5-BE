using BuildWeek5_BE.Models.Auth;
using BuildWeek5_BE.Models.Farmacia;
using BuildWeek5_BE.DTOs.Farmacia.Fornitore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia
{
    public class GetProdottoDto
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DataDiAcquisto { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        public int FornitoreId { get; set; }

        [ForeignKey("FornitoreId")]
        public FornitoreDto Fornitore { get; set; }

        public ICollection<UsoProdottoDto> Usi { get; set; }

        public CassettoDto Cassetto { get; set; }
    }
}
