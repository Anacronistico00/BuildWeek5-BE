using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Clienti
{
    public class AddClienteResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
