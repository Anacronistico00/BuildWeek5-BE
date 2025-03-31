using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildWeek5_BE.Models
{
    public class Ricovero
    {
        [Key]
        public int RicoveroId { get; set; }

        [ForeignKey(nameof(Puppy))]
        public int PuppyId { get; set; }

        public Puppy Puppy { get; set; }

        [Required]
        public DateOnly DataInizioRicovero { get; set; }

        [Required]
        public required string Descrizione { get; set; }
    }
}
