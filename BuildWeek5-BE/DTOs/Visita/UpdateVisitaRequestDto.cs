using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Visita
{
    public class UpdateVisitaRequestDto
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataVisita { get; set; }

        [Required]
        [StringLength(50)]
        public required string ObiettivoEsame { get; set; }

        [Required]
        [StringLength(255)]
        public required string DescrizioneCura { get; set; }

    }
}
