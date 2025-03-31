using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Visita
{
    public class AddVisitaResponseDto
    {
        [Required]
        public required string Message { get; set; }
    }
}
