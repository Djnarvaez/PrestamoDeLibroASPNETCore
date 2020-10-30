using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBBook.Models
{
    public class Libro
    {
        public int IdLibro { get; set; }
        [Required(ErrorMessage = "Favor ingresar el titulo")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Favor ingresar el editorial")]
        public string Editorial { get; set; }
        public string Area { get; set; }
        public List<Errors> Errors { get; set; }
    }
}
