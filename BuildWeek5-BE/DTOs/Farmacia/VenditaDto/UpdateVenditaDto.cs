using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia.Vendita
{
    public class UpdateVenditaDto
    {

        [Required(ErrorMessage = "La ricetta medica è obbligatoria")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La ricetta medica deve essere compresa tra 3 e 100 caratteri")]
        public string RicettaMedica { get; set; }
    }
}
