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
    public class PrestamoController : Controller
    {
        private readonly IPrestamoRepository prestamoRepository;
        private readonly IStudentBookRepository studentBookRepository;
        private readonly IConfiguration configuration;

        public PrestamoController(IPrestamoRepository prestamoRepository, IStudentBookRepository studentBookRepository, IConfiguration configuration)
        {
            this.prestamoRepository = prestamoRepository;
            this.studentBookRepository = studentBookRepository;
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> LendBooks(StudentBook studentBook)
        {
            var estudiantes = await studentBookRepository.CreateAsync(configuration["APIBorrowed:BaseUrl"] + Util.LendBooks, studentBook);
            return Json(new { Data = estudiantes });
        }
        public async Task<JsonResult> GetBooksBorrowed()
        {
            var estudiantes = await prestamoRepository.GetAllAsync(configuration["APIBorrowed:BaseUrl"]);
            return Json(new { Data = estudiantes });
        }
        public async Task<JsonResult> ReturnBooks(StudentBook studentBook)
        {
            var estudiantes = await studentBookRepository.CreateAsync(configuration["APIBorrowed:BaseUrl"] + Util.ReturnBooks, studentBook);
            return Json(new { Data = estudiantes });
        }
    }
}
