using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia.Vendita
{
    public class CreateVenditaDto
    {
        [Required(ErrorMessage = "L'ID del prodotto è obbligatorio")]
        public int ProdottoId { get; set; }

        [Required(ErrorMessage = "L'ID del cliente è obbligatorio")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "La ricetta medica è obbligatoria")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La ricetta medica deve essere compresa tra 3 e 100 caratteri")]
        public string RicettaMedica { get; set; }

        [StringLength(50, ErrorMessage = "Il numero della ricetta medica non può superare i 50 caratteri")]
        public string NumeroRicettaMedica { get; set; }
    }
}
