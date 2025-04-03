using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Clienti
{
    public class ClienteDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cognome { get; set; }

        public string CodiceFiscale { get; set; }

        public DateTime DataDiNascita { get; set; }

        public string Indirizzo { get; set; }
    }

}
