using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIBook.Models
{
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Area { get; set; }
        public virtual ICollection<LibAut> LibroAutor { get; set; }
        public virtual ICollection<Prestamo> Prestamo { get; set; }
    }
}
