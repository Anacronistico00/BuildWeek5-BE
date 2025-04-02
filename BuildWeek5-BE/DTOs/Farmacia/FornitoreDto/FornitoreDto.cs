using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia.Fornitore
{
    public class FornitoreDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Recapito { get; set; }

        [Required]
        [StringLength(200)]
        public string Indirizzo { get; set; }

    }


}
