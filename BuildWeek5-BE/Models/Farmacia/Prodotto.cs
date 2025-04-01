using BuildWeek5_BE.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildWeek5_BE.Models.Farmacia
{
    public class Prodotto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DataDiAcquisto { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        public int FornitoreId { get; set; }

        [ForeignKey("FornitoreId")]
        public Fornitore Fornitore { get; set; }

        public ICollection<UsoProdotto> Usi { get; set; }

        [ForeignKey(nameof(Cassetto))]
        public int CassettoId { get; set; }

        public Cassetto Cassetto { get; set; }

        [ForeignKey(nameof(Armadietto))]
        public int ArmadiettoId { get; set; }

        public Armadietto Armadietto { get; set; }

        public ICollection<Vendita> vendite { get; set; }

        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ICollection<ApplicationUser>? Cliente { get; set; }

        public ICollection<UtenteProdotto>? UtenteProdotto { get; set; }

    }
}
