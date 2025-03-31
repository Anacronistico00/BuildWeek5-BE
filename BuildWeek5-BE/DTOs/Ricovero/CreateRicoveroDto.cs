using System;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs
{
    public class CreateRicoveroDto
    {
        [Required]
        public int PuppyId { get; set; }

        [Required]
        public DateOnly DataInizioRicovero { get; set; }

        [Required]
        public string Descrizione { get; set; }

        public DateOnly? DataFineRicovero { get; set; }

    }
}