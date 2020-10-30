using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WEBBook.Models;
using WEBBook.Repository.IRepository;
using WEBBook.Resource;

namespace WEBBook.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IEstudianteRepository estudianteRepository;
        private readonly IConfiguration configuration;

        public EstudianteController(IEstudianteRepository estudianteRepository, IConfiguration configuration)
        {
            this.estudianteRepository = estudianteRepository;
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetStudents()
        {
            var estudiantes = await estudianteRepository.GetAllAsync(configuration["APIStudent:BaseUrl"]);
            return Json(new { Data = estudiantes });
        }
        public async Task<JsonResult> GetStudent(int id)
        {
            var estudiantes = await estudianteRepository.GetAsync(configuration["APIStudent:BaseUrl"], id);
            return Json(new { Data = estudiantes });
        }
        public async Task<JsonResult> UpdateStudent(Estudiante estudiante)
        {
            var estudiantes = await estudianteRepository.UpdateAsync(configuration["APIStudent:BaseUrl"] + estudiante.IdLector, estudiante);
            return Json(new { Data = estudiantes });
        }
        public async Task<JsonResult> CreateStudent(Estudiante estudiante)
        {
            var estudiantes = await estudianteRepository.CreateAsync(configuration["APIStudent:BaseUrl"], estudiante);
            return Json(new { Data = estudiantes });
        }
        public async Task<JsonResult> DeleteStudent(int id)

        {
            var estudiantes = await estudianteRepository.DeleteAsync(configuration["APIStudent:BaseUrl"], id);
            return Json(new { Data = estudiantes });
        }
    }
}
