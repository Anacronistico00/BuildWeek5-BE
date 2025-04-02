using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia.Fornitore
{
    public class UpdateFornitoreDto
    {
        [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri")]
        public string Nome { get; set; }

        [StringLength(100, ErrorMessage = "Il recapito non può superare i 100 caratteri")]
        public string Recapito { get; set; }

        [StringLength(200, ErrorMessage = "L'indirizzo non può superare i 200 caratteri")]
        public string Indirizzo { get; set; }
    }
}
