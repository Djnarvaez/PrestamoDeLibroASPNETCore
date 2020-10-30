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
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository autorRepository;
        private readonly IMapper mapper;

        public AutorController(IAutorRepository autorRepository, IMapper mapper)
        {
            this.autorRepository = autorRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDTO>>> GetAuthors()
        {
            var autors = await autorRepository.GetAllAsync();
            return Ok(mapper.Map<List<AutorDTO>>(autors));
        }

        [HttpGet("{id}", Name = "GetAutorAsync")]
        public async Task<ActionResult<AutorDTO>> GetAutorAsync(int id)
        {
            var autor = await autorRepository.GetAsync(id);
            if (autor == null) return NotFound();
            return Ok(mapper.Map<AutorDTO>(autor));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAutorAsync([FromBody] Autor autorDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var autor = mapper.Map<Autor>(autorDTO);
            if (!await autorRepository.CreateAsync(autor))
            {
                ModelState.AddModelError(string.Empty, $"Ha ocurrido un error al intentar guardar el autor {autorDTO.Nombre}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetAutorAsync", new { id = autor.IdAutor }, autor);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAutorAsync(int id, [FromBody] Autor autorDTO)
        {
            if (autorDTO.IdAutor != id) return BadRequest(ModelState);

            var autor = mapper.Map<Autor>(autorDTO);
            if (!await autorRepository.UpdateAsync(autor))
            {
                ModelState.AddModelError("Response", $"Ha ocurrido un error al intentar actualizar el autor {autorDTO.Nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAutorAsync(int id)
        {
            var autor = await autorRepository.GetAsync(id);
            if (autor == null) return NotFound();

            if (!await autorRepository.DeleteAsync(autor))
            {
                ModelState.AddModelError("Response", $"Ha ocurrido un error al intentar eliminar el libro {autor.Nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
