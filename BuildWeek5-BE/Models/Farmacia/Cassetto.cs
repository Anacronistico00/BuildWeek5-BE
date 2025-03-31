using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.Models.Farmacia
{
    public class Cassetto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ArmadiettoId { get; set; }

        [ForeignKey("ArmadiettoId")]
        public Armadietto Armadietto { get; set; }

        public ICollection<Prodotto> prodotti { get; set; }
    }
}
