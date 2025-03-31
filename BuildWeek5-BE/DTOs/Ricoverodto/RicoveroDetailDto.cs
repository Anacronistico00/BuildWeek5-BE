using System;
using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Ricovero
{
    public class RicoveroDetailDto
    {
        public int RicoveroId { get; set; }
        public int PuppyId { get; set; }
        public string PuppyNome { get; set; }
        public DateOnly DataInizioRicovero { get; set; }
        public string Descrizione { get; set; }
        public DateOnly? DataFineRicovero { get; set; }
    }
}