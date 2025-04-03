using System;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Clienti
{
    public class ClienteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il cognome non può superare i 100 caratteri")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Il codice fiscale è obbligatorio")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Il codice fiscale deve essere di 16 caratteri")]
        public string CodiceFiscale { get; set; }

        [Required(ErrorMessage = "La data di nascita è obbligatoria")]
        [DataType(DataType.Date)]
        public DateTime DataDiNascita { get; set; }

        [Required(ErrorMessage = "L'indirizzo è obbligatorio")]
        [StringLength(200, ErrorMessage = "L'indirizzo non può superare i 200 caratteri")]
        public string Indirizzo { get; set; }
    }
}
