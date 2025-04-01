using System.Collections.Generic;

namespace BuildWeek5_BE.DTOs.Farmacia.Fornitore
{
    public class FornitoreDetailDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Recapito { get; set; }
        public string Indirizzo { get; set; }
        public ICollection<ProdottoSempliceDto> Prodotti { get; set; }
        public int NumeroProdotti => Prodotti?.Count ?? 0;
    }
}
