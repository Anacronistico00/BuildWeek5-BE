using System.Collections.Generic;

namespace BuildWeek5_BE.DTOs.Farmacia.Fornitore
{
    public class FornitoreDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Recapito { get; set; }
        public string Indirizzo { get; set; }

        // Opzionale: includi i prodotti associati
        public ICollection<ProdottoSempliceDto> Prodotti { get; set; }
    }

    // DTO semplificato per i prodotti quando vengono inclusi nel fornitore
    public class ProdottoSempliceDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }
    }
}
