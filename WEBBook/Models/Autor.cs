using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBBook.Models
{
    public class Autor
    {
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "Favor ingrese el nombre del autor")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Favor ingrese la nacionalidad del autor")]
        public string Nacionalidad { get; set; }
        public List<Errors> Errors { get; set; }

    }
}
