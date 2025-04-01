using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Animale
{
    public class AnimaleDto
    {
        [Required]
        [StringLength(50)]
        public required string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public required string Tipologia { get; set; }
    }
}
