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
    public class LibroController : ControllerBase
    {
        private readonly ILibroRepository libroRepository;
        private readonly ILibAutRepository libAutRepository;
        private readonly IMapper mapper;

        public LibroController(ILibroRepository libroRepository, ILibAutRepository libAutRepository, IMapper mapper)
        {
            this.libroRepository = libroRepository;
            this.libAutRepository = libAutRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<LibroDTO>>> GetBooksAsync()
        {
            var libros = await libroRepository.GetAllAsync();
            return Ok(mapper.Map<List<LibroDTO>>(libros));
        }

        [HttpGet("{id}", Name = "GetBookAsync")]
        public async Task<ActionResult<LibroDTO>> GetBookAsync(int id)
        {
            var libro = await libroRepository.GetAsync(id);
            if (libro == null) return NotFound();
            return Ok(mapper.Map<LibroDTO>(libro));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAutorAsync([FromBody] LibroDTO libroDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var libro = mapper.Map<Libro>(libroDTO);
            if (!await libroRepository.CreateAsync(libro))
            {
                ModelState.AddModelError(string.Empty, $"Ha ocurrido un error al intentar guardar el libro {libroDTO.Titulo}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetBookAsync", new { id = libro.IdLibro }, libro);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAutorAsync(int id, [FromBody] LibroDTO libroDTO)
        {
            if (libroDTO.IdLibro != id) return BadRequest(ModelState);

            var libro = mapper.Map<Libro>(libroDTO);
            if (!await libroRepository.UpdateAsync(libro))
            {
                ModelState.AddModelError("Response", $"Ha ocurrido un error al intentar actualizar el libro {libroDTO.Titulo}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookAsync(int id)
        {
            var libro = await libroRepository.GetAsync(id);
            if (libro == null) return NotFound();

            if (!await libroRepository.DeleteAsync(libro))
            {
                ModelState.AddModelError("Response", $"Ha ocurrido un error al intentar eliminar el libro {libro.Titulo}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpPost]
        [Route("AssignAuthor")]
        public async Task<ActionResult> AssignAuthor([FromBody] LibAutDTO libAutDTO)
        {
            var libro = mapper.Map<LibAut>(libAutDTO);
            if (!await libAutRepository.CreateAsync(libro))
            {
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
