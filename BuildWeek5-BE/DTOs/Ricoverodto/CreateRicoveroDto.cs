using System;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs
{
    public class CreateRicoveroDto
    {
        [Required(ErrorMessage = "L'ID del paziente è obbligatorio")]
        public int PuppyId { get; set; }

        [Required(ErrorMessage = "La data di inizio ricovero è obbligatoria")]
        public DateOnly DataInizioRicovero { get; set; }

        [Required(ErrorMessage = "La descrizione del ricovero è obbligatoria")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "La descrizione deve essere compresa tra {2} e {1} caratteri")]
        public string Descrizione { get; set; }

        public DateOnly? DataFineRicovero { get; set; }
    }
}
