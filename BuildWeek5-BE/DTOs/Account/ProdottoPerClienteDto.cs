using BuildWeek5_BE.DTOs.Farmacia;
using BuildWeek5_BE.Models.Auth;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Account
{
    public class ProdottoPerClienteDto
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        [StringLength(16)]
        public required string FiscalCode { get; set; }

        public ICollection<ProdottoDto> Prodotti { get; set; }
    }
}
