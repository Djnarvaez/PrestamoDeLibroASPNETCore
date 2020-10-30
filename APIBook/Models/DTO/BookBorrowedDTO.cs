using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Models.DTO
{
    public class BookBorrowedDTO
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public int IdLector { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public Nullable<System.DateTime> FechaDevolucion { get; set; }
        public bool Devuelto { get; set; }
    }
}
