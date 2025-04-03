using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Puppy
{
    public class AddAnimaleRequestDto
    {
        [Required]
        [StringLength(50)]
        public required string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public required string Tipologia { get; set; }

        [Required]
        [StringLength(50)]
        public required string ColoreMantello { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DataNascita { get; set; }

        [Required]
        public bool MicrochipPresente { get; set; }

        [StringLength(15)]
        public string? NumeroMicrochip { get; set; }

        public int? UserId { get; set; }
    }
}
