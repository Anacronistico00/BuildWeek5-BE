namespace BuildWeek5_BE.DTOs.Farmacia
{
    public class UtenteProdottoDto
    {
        public string CodiceFiscale { get; set; }
        public DateOnly DataAcquisto { get; set; }
        public string? NumeroRicettaMedica { get; set; }
    }
}
