using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBook.Context;
using APIBook.Models;
using APIBook.Models.DTO;
using APIBook.Repository;
using APIBook.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace APIBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("DefaultConetionstring")));

            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ILibroRepository, LibroRepository>();
            services.AddScoped<IEstudianteRepository, EstudianteRepository>();
            services.AddScoped<ILibAutRepository, LibAutRepository>();


            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<Autor, AutorDTO>();
                configuration.CreateMap<AutorDTO, Autor>();
                configuration.CreateMap<Libro, LibroDTO>();
                configuration.CreateMap<LibroDTO, Libro>();
                configuration.CreateMap<Estudiante, EstudianteDTO>();
                configuration.CreateMap<EstudianteDTO, Estudiante>();
                configuration.CreateMap<LibAut, LibAutDTO>();
                configuration.CreateMap<LibAutDTO, LibAut>();

            }, typeof(Startup));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
