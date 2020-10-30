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
    public class AutorController : Controller
    {
        private readonly IAutorRepository autorRepository;
        private readonly IConfiguration configuration;

        public AutorController(IAutorRepository autorRepository, IConfiguration configuration)
        {
            this.autorRepository = autorRepository;
            this.configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            return View(await autorRepository.GetAllAsync(configuration["APIAuthor:BaseUrl"]));
        }
        public IActionResult Create()
        {
            return View(new Autor());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                var modelError = await autorRepository.CreateAsync(configuration["APIAuthor:BaseUrl"], autor);
                if (modelError.Response.Errors.Count > 0)
                {
                    autor.Errors = new List<Errors>();
                    foreach (var item in modelError.Response.Errors)
                    {
                        autor.Errors.Add(item);
                    }
                    return View(autor);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Autor autor = new Autor();
            if (id == null) return NotFound();
            autor = await autorRepository.GetAsync(configuration["APIAuthor:BaseUrl"], id.GetValueOrDefault());
            if (autor == null) return NotFound();
            return View(autor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Autor autor)
        {
            if (ModelState.IsValid)
            {
                var modelError = await autorRepository.UpdateAsync(configuration["APIAuthor:BaseUrl"] + autor.IdAutor, autor);
                if (modelError.Response.Errors.Count > 0)
                {
                    autor.Errors = new List<Errors>();
                    foreach (var item in modelError.Response.Errors)
                    {
                        autor.Errors.Add(item);
                    }
                    return View(autor);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Autor autor = new Autor();
            if (id == null) return NotFound();
            autor = await autorRepository.GetAsync(configuration["APIAuthor:BaseUrl"], id.GetValueOrDefault());

            if (autor == null) return NotFound();
            return View(autor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var autor = await autorRepository.GetAsync(configuration["APIAuthor:BaseUrl"], id);
            if (autor == null) return NotFound();

            var modelError = await autorRepository.DeleteAsync(configuration["APIAuthor:BaseUrl"], autor.IdAutor);
            if (modelError.Response.Errors.Count > 0)
            {
                autor.Errors = new List<Errors>();
                foreach (var item in modelError.Response.Errors)
                {
                    autor.Errors.Add(item);
                }
                return View(autor);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<JsonResult> GetAuthors()
        {
             var autor = await autorRepository.GetAllAsync(configuration["APIAuthor:BaseUrl"]);
            return Json(new { Data = autor });
        }
    }
}
