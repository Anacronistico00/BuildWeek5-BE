using System;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs
{
    public class UpdateRicoveroDto
    {


        [Required]
        public string Descrizione { get; set; }

        public DateOnly? DataFineRicovero { get; set; }

    }
}