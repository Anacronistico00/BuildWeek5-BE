using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia.Vendita
{
    public class CreateVenditaDto
    {
        [Required(ErrorMessage = "L'ID del prodotto è obbligatorio")]
        public int ProdottoId { get; set; }

        [StringLength(50, ErrorMessage = "Il numero della ricetta medica non può superare i 50 caratteri")]
        public string NumeroRicettaMedica { get; set; }
    }
}
