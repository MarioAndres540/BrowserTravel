using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BrowserTravel.Entidades
{
    public class Libro
    {
        [Key]
        [Required]
        public int ISBN { get; set; }
        
        public int Editoriales_id { get; set; }
        [StringLength(45)]
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Sinopsis { get; set; }
        [StringLength(45)]
        [Unicode]
        [Required]
        public string N_paginas { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
