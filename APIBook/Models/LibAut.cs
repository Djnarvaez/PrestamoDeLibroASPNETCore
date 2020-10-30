using System;
using System.ComponentModel.DataAnnotations;

namespace APIBook.Models
{
    public class LibAut
    {
        [Key]
        public int Id { get; set; }
        public int IdAutor { get; set; }
        public int IdLibro { get; set; }
        public virtual Autor Autor { get; set; }
        public virtual Libro Libro { get; set; }
    }
}
