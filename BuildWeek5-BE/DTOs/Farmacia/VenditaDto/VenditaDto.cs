﻿using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Farmacia
{
    public class VenditaDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "L'ID del prodotto è obbligatorio")]
        public int ProdottoId { get; set; }

        public string NomeProdotto { get; set; }

        public decimal PrezzoProdotto { get; set; }

        public string NumeroRicettaMedica { get; set; }
    }
}
