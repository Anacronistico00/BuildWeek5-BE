using BuildWeek5_BE.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildWeek5_BE.Models.Farmacia
{
    public class UtenteProdotto
    {
        public int prodottoId { get; set; }

        public int utenteId { get; set; }

        public DateOnly DataAcquisto { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string? NumeroRicettaMedica { get; set; }

        [ForeignKey(nameof(prodottoId))]
        public Prodotto Prodotto { get; set; }

        [ForeignKey(nameof(utenteId))]
        public Cliente Cliente { get; set; }
    }
}
