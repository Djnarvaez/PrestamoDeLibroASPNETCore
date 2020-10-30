using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBook.Models.DTO;
using APIBook.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IEstudianteRepository estudianteRepository;
        private readonly ILibroRepository libroRepository;

        public PrestamoController(IEstudianteRepository estudianteRepository, ILibroRepository libroRepository, IMapper mapper)
        {
            this.estudianteRepository = estudianteRepository;
            this.libroRepository = libroRepository;
        }
        [HttpPost]
        [Route("LendBooks")]
        public async Task<ActionResult> LendBooks([FromBody] StudentBookDTO studentBookDTO)
        {
            await estudianteRepository.LendBooks(studentBookDTO);
            return NoContent();
        }
        [HttpPost]
        [Route("ReturnBooks")]
        public async Task<ActionResult> ReturnBooks([FromBody] StudentBookDTO studentBookDTO)
        {
            await estudianteRepository.ReturnBooks(studentBookDTO);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<BookBorrowedDTO>>> GetBorrowedBooks()
        {
            var prestamos = await estudianteRepository.GetBorrowedBooks();
            if (prestamos == null) return NotFound();
            List<BookBorrowedDTO> bookBorroweds = new List<BookBorrowedDTO>();
            foreach (var item in prestamos)
            {
                BookBorrowedDTO bookBorrowed = new BookBorrowedDTO();
                var estudiante = await estudianteRepository.GetStudent(item.IdLector);
                var libro = await libroRepository.GetAsync(item.IdLibro);

                bookBorrowed.IdLibro = item.IdLibro;
                bookBorrowed.IdLector = item.IdLector;
                bookBorrowed.FechaPrestamo = item.FechaPrestamo;
                bookBorrowed.FechaDevolucion = item.FechaDevolucion;
                bookBorrowed.Devuelto = item.Devuelto;
                bookBorrowed.Nombre = estudiante.Nombre;
                bookBorrowed.Titulo = libro.Titulo;
                bookBorroweds.Add(bookBorrowed);
            }
            return Ok(bookBorroweds);
        }
    }
}
