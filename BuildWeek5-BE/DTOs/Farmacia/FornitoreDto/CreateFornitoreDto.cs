using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia.Fornitore
{
    public class CreateFornitoreDto
    {
        [Required(ErrorMessage = "Il nome del fornitore è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il recapito del fornitore è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il recapito non può superare i 100 caratteri")]
        public string Recapito { get; set; }

        [Required(ErrorMessage = "L'indirizzo del fornitore è obbligatorio")]
        [StringLength(200, ErrorMessage = "L'indirizzo non può superare i 200 caratteri")]
        public string Indirizzo { get; set; }
    }
}
