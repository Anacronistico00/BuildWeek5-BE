using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildWeek5_BE.DTOs.Clienti;

namespace BuildWeek5_BE.DTOs.Puppy
{
    public class GetAnimaleDto
    {
        [Key]
        public int PuppyId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DataRegistrazione { get; set; }

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

        [ForeignKey("Cliente")]
        public int? ClienteId { get; set; }

        public ClienteDto? Cliente { get; set; }
    }
}
