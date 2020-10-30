using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Models.DTO
{
    public class LibroDTO
    {
        public int IdLibro { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Area { get; set; }
    }
}
