using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.Models.Farmacia
{
    public class Armadietto
    {
        [Key]
        public int Codice { get; set; }

        public ICollection<Cassetto> Cassetti { get; set; }
    }
}
