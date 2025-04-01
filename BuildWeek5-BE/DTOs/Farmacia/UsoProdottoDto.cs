using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia
{
    public class UsoProdottoDto
    {
        [Required]
        [StringLength(100)]
        public string Descrizione { get; set; }
    }
}
