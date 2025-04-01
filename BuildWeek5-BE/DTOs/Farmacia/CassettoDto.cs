using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia
{
    public class CassettoDto
    {
        public int CassettoId { get; set; }

        [Required]
        public int ArmadiettoId { get; set; }
    }
}
