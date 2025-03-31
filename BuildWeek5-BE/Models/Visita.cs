﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildWeek5_BE.Models
{
    public class Visita
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataVisita { get; set; }

        [Required]
        [StringLength(50)]
        public required string ObiettivoEsame {  get; set; }

        [Required]
        [StringLength(255)]
        public required string DescrizioneCura { get; set; }

        [ForeignKey(nameof(Puppy))]
        public int PuppyId { get; set; }

        public Puppy Puppy { get; set; }
    }
}
