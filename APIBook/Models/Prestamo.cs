using System;
using System.ComponentModel.DataAnnotations;

namespace APIBook.Models
{
    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }
        public int IdLector { get; set; }
        public int IdLibro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public Nullable<System.DateTime> FechaDevolucion { get; set; }
        public bool Devuelto { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Libro Libro { get; set; }
    }
}
