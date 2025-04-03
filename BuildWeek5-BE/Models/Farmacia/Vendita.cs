using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BuildWeek5_BE.Models.Auth;

namespace BuildWeek5_BE.Models.Farmacia
{
    public class Vendita
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Cliente User { get; set; }

        [Required(ErrorMessage = "La ricetta medica è obbligatoria")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La ricetta medica deve essere compresa tra 3 e 100 caratteri")]
        public string RicettaMedica { get; set; }


        [Required]
        public int ProdottoId { get; set; }

        [ForeignKey("ProdottoId")]
        public Prodotto Prodotto { get; set; }

        public string? NumeroRicettaMedica { get; set; }

        public DateTime DataVendita { get; set; } = DateTime.Now;
    }
}
