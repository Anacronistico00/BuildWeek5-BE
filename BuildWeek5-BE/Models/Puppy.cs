﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using BuildWeek5_BE.Models.Auth;

namespace BuildWeek5_BE.Models
{
    public class Puppy
    {
        [Key]
        public int PuppyId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DataRegistrazione { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public required string Tipologia { get; set; }

        [Required]
        [StringLength(50)]
        public required string ColoreMantello { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DataNascita { get; set; }

        [Required]
        public bool MicrochipPresente { get; set; }

        [StringLength(15)]
        public string? NumeroMicrochip { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }

        public ApplicationUser? User { get; set; }

        public ICollection<Visita>? Visite { get; set; }

        public ICollection<Ricovero>? Ricoveri { get; set; }
    }
}

