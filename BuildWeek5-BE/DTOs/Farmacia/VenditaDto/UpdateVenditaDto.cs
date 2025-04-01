using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia.Vendita
{
    public class UpdateVenditaDto
    {
        [StringLength(50, ErrorMessage = "Il numero della ricetta medica non può superare i 50 caratteri")]
        public string NumeroRicettaMedica { get; set; }
    }
}
