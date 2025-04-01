using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BuildWeek5_BE.Models.Auth;

namespace BuildWeek5_BE.Models.Farmacia
{
    public class Vendita
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public int ProdottoId { get; set; }

        [ForeignKey("ProdottoId")]
        public Prodotto Prodotto { get; set; }

        public string? NumeroRicettaMedica { get; set; }

        public DateTime DataVendita { get; set; } = DateTime.Now;
    }
}
