using BuildWeek5_BE.DTOs.Puppy;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Visita
{
    public class GetVisitaByIdResponseDto
    {

        [Required]
        public required string Message { get; set; }


        [Required]
        public GetVisitaDto Visita { get; set; }
    }
}
