using BuildWeek5_BE.Models.Farmacia;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BuildWeek5_BE.Models.Auth;
using BuildWeek5_BE.DTOs.Account;

namespace BuildWeek5_BE.DTOs.Farmacia
{
    public class ProdottoDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DataDiAcquisto { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public UserDto Cliente { get; set; }
    }
}
