using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.Models.Farmacia
{
    public class UsoProdotto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [Required]
        public int ProdottoId { get; set; }

        [ForeignKey("ProdottoId")]
        public Prodotto Prodotto { get; set; }
    }
}
