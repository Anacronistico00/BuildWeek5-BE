using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Clienti
{
    public class AddClienteRequestDto
    {
        [Required(ErrorMessage = "Il nome è obbligatorio.")]
        [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio.")]
        [StringLength(100, ErrorMessage = "Il cognome non può superare i 100 caratteri.")]
        public required string Cognome { get; set; }

        [Required(ErrorMessage = "Il CF è obbligatorio.")]
        [MinLength(16, ErrorMessage = "Il Codice Fiscale deve contenere almeno 16 caratteri.")]
        [MaxLength(16, ErrorMessage = "Il Codice Fiscale non può superare i 16 caratteri.")]
        public required string CodiceFiscale { get; set; }

        [Required(ErrorMessage = "La data di nascita è obbligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La data di nascita non è valida.")]
        public DateTime DataDiNascita { get; set; }

        [Required(ErrorMessage = "L'indirizzo è obbligatorio.")]
        [StringLength(200, ErrorMessage = "L'indirizzo non può superare i 200 caratteri.")]
        public required string Indirizzo { get; set; }
    }
}
