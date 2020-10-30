using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIBook.Models
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public virtual ICollection<LibAut> LibroAutor { get; set; }
    }
}
