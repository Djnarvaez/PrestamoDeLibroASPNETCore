using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBBook.Models
{
    public class Estudiante
    {
        public int IdLector { get; set; }
        public string CI { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Carrera { get; set; }
        public int Edad { get; set; }
    }
}
