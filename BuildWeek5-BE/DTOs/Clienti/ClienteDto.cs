using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Clienti
{
    public class ClienteDto
    {

        public required string Nome { get; set; }

        public required string Cognome { get; set; }

        public required string CodiceFiscale { get; set; }
    }
}
