using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBook.Models;
using APIBook.Models.DTO;
using APIBook.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepository estudianteRepository;
        private readonly ILibroRepository libroRepository;

        private readonly IMapper mapper;

        public EstudianteController(IEstudianteRepository estudianteRepository, ILibroRepository libroRepository, IMapper mapper)
        {
            this.estudianteRepository = estudianteRepository ?? throw new ArgumentNullException(nameof(estudianteRepository));
            this.mapper = mapper;
            this.libroRepository = libroRepository ?? throw new ArgumentNullException(nameof(libroRepository)); ;
        }
        [HttpGet]
        public async Task<ActionResult<List<EstudianteDTO>>> GetStudents()
        {
            var estudiante = await estudianteRepository.GetStudents();
            return Ok(mapper.Map<List<EstudianteDTO>>(estudiante));
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<ActionResult<EstudianteDTO>> GetStudent(int id)
        {
            var estudiante = await estudianteRepository.GetStudent(id);
            if (estudiante == null) return NotFound();
            return Ok(mapper.Map<EstudianteDTO>(estudiante));
        }

        [HttpPost]
        public async Task<ActionResult> Createtudent([FromBody] EstudianteDTO estudianteDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var estudiante = mapper.Map<Estudiante>(estudianteDTO);
            var id = await estudianteRepository.CreateStudent(estudiante);
            if (id  == 0)
            {
                ModelState.AddModelError(string.Empty, $"Ha ocurrido un error al intentar guardar el autor {estudianteDTO.Nombre}");
                return StatusCode(500, ModelState);
            }
          
            return new CreatedAtRouteResult("GetStudent", new { id = id }, estudiante);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id, [FromBody] EstudianteDTO estudianteDTO)
        {
            if (estudianteDTO.IdLector != id) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var estudiante = mapper.Map<Estudiante>(estudianteDTO);
            await estudianteRepository.UpdateStudent(estudiante);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var estudiante = await estudianteRepository.GetStudent(id);
            if (estudiante == null) return NotFound();
            await estudianteRepository.DeleteStudent(id);
            return NoContent();
        }
        //[HttpPost(Name = "LendBooks")]
        //public async Task<ActionResult> LendBooks([FromBody] StudentBookDTO studentBookDTO)
        //{
        //    await estudianteRepository.LendBooks(studentBookDTO);
        //    return NoContent();
        //}
        //[HttpPost(Name = "ReturnBooks")]
        //public async Task<ActionResult> ReturnBooks([FromBody] StudentBookDTO studentBookDTO)
        //{
        //    await estudianteRepository.ReturnBooks(studentBookDTO);
        //    return NoContent();
        //}

        //[HttpGet(Name = "GetBorrowedBooks")]
        //public async Task<ActionResult<List<BookBorrowedDTO>>> GetBorrowedBooks()
        //{
        //    var prestamos = await estudianteRepository.GetBorrowedBooks();
        //    if (prestamos == null) return NotFound();
        //    List<BookBorrowedDTO> bookBorroweds = new List<BookBorrowedDTO>();
        //    foreach (var item in prestamos)
        //    {
        //        BookBorrowedDTO bookBorrowed = new BookBorrowedDTO();
        //        var estudiante = await estudianteRepository.GetStudent(item.IdLector);
        //        var libro = await libroRepository.GetAsync(item.IdLibro);

        //        bookBorrowed.IdLibro = item.IdLibro;
        //        bookBorrowed.IdLector = item.IdLector;
        //        bookBorrowed.FechaPrestamo = item.FechaPrestamo;
        //        bookBorrowed.FechaDevolucion = item.FechaDevolucion;
        //        bookBorrowed.Devuelto = item.Devuelto;
        //        bookBorrowed.Nombre = estudiante.Nombre;
        //        bookBorrowed.Titulo = libro.Titulo;
        //        bookBorroweds.Add(bookBorrowed);
        //    }
        //    return Ok(bookBorroweds);
        //}
    }
}
