using BuildWeek5_BE.Models.Auth;
using BuildWeek5_BE.Models.Farmacia;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia
{
    public class AddProdottoRequestDto
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public int FornitoreId { get; set; }

        [Required]
        public required string UsiProdotto { get; set; }

        [Required]
        public int CassettoId { get; set; }

        [Required]
        public int ArmadiettoId { get; set; }

    }
}
