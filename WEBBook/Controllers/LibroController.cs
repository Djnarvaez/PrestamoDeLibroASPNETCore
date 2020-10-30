using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WEBBook.Models;
using WEBBook.Repository.IRepository;

namespace WEBBook.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroRepository libroRepository;
        private readonly ILibAutRepository libAutRepository;
        private readonly IConfiguration configuration;

        public LibroController(ILibroRepository libroRepository, ILibAutRepository libAutRepository, IConfiguration configuration)
        {
            this.libroRepository = libroRepository;
            this.libAutRepository = libAutRepository;
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetBooks()
        {
            var libros = await libroRepository.GetAllAsync(configuration["APIBook:BaseUrl"]);
            return Json(new { Data = libros });
        }
        public async Task<JsonResult> GetBook(int id)
        {
            var estudiantes = await libroRepository.GetAsync(configuration["APIBook:BaseUrl"], id);
            return Json(new { Data = estudiantes });
        }
        public async Task<JsonResult> UpdateBook(Libro libro)
        {
            var estudiantes = await libroRepository.UpdateAsync(configuration["APIBook:BaseUrl"] + libro.IdLibro, libro);
            return Json(new { Data = estudiantes });
        }
        public async Task<JsonResult> CreateBook(Libro libro)
        {
            var estudiantes = await libroRepository.CreateAsync(configuration["APIBook:BaseUrl"], libro);
            return Json(new { Data = estudiantes });
        }
        public async Task<JsonResult> DeleteBook(int id)
        {
            var estudiantes = await libroRepository.DeleteAsync(configuration["APIBook:BaseUrl"], id);
            return Json(new { Data = estudiantes });
        }

        public async Task<JsonResult> AssignAuthor(LibAut libAut)
        {
            await libAutRepository.CreateAsync(configuration["APIBook:BaseUrl"] + "AssignAuthor", libAut);
            return Json(new { Data = string.Empty });
        }
    }
}
