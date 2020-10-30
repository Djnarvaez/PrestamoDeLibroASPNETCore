using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Models.DTO
{
    public class AutorDTO
    {
        public int IdAutor { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
    }
}
