using BuildWeek5_BE.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BuildWeek5_BE.DTOs.Animale;

namespace BuildWeek5_BE.DTOs.Visita
{
    public class GetVisitaDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataVisita { get; set; }

        [Required]
        [StringLength(50)]
        public required string ObiettivoEsame { get; set; }

        [Required]
        [StringLength(255)]
        public required string DescrizioneCura { get; set; }

        [ForeignKey(nameof(Animale))]
        public int PuppyId { get; set; }

        public AnimaleDto Animale { get; set; }
    }
}
