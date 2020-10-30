using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIBook.Models
{
    public class Estudiante
    {
        [Key]
        public int IdLector { get; set; }
        public string CI { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Carrera { get; set; }
        public int Edad { get; set; }
        public virtual ICollection<Prestamo> Prestamo { get; set; }
    }
}
