using APIBook.Context;
using APIBook.Models;
using APIBook.Models.DTO;
using APIBook.Repository.IRepository;
using APIBook.Resource;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Repository
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly ApplicationDbContext context;

        public EstudianteRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Estudiante> GetStudent(int id)
        {
            var result = await context.Estudiante.FromSqlRaw<Estudiante>("GetStudent  @Id",
               new SqlParameter("@Id", id)).AsNoTracking().ToListAsync();

            return result.SingleOrDefault();
        }
        public async Task<List<Estudiante>> GetStudents()
        {
            return await context.Estudiante.FromSqlRaw<Estudiante>($"exec {Util.GetStudents}").ToListAsync();

        }
        public async Task<int> CreateStudent(Estudiante estudiante)
        {
            return await context.Database.ExecuteSqlRawAsync($"{Util.CreateStudent} @Id,@CI,@Nombre,@Direccion,@Carrera,@Edad",
            new SqlParameter("@Id", estudiante.IdLector),
            new SqlParameter("@CI", estudiante.CI),
            new SqlParameter("@Nombre", estudiante.Nombre),
            new SqlParameter("@Direccion", estudiante.Direccion),
            new SqlParameter("@Carrera", estudiante.Carrera),
            new SqlParameter("@Edad", estudiante.Edad));
        }
        public async Task UpdateStudent(Estudiante estudiante)
        {
            await context.Database.ExecuteSqlRawAsync("UpdateStudent {0},{1},{2},{3},{4},{5}",
           new SqlParameter("@Id", estudiante.IdLector),
           new SqlParameter("@CI", estudiante.CI),
           new SqlParameter("@Nombre", estudiante.Nombre),
           new SqlParameter("@Direccion", estudiante.Direccion),
           new SqlParameter("@Carrera", estudiante.Carrera),
           new SqlParameter("@Edad", estudiante.Edad));
        }
        public async Task DeleteStudent(int id)
        {
            await context.Database.ExecuteSqlRawAsync("DeleteStudent  {0}",
                 new SqlParameter("@Id", id));
        }
        public async Task LendBooks(StudentBookDTO studentBookDTO)
        {
            await context.Database.ExecuteSqlRawAsync("LendBooks {0},{1}",
           new SqlParameter("@IdLector", studentBookDTO.IdLector),
           new SqlParameter("@IdLibro", studentBookDTO.IdLibro));
        }
        public async Task ReturnBooks(StudentBookDTO studentBookDTO)
        {
            await context.Database.ExecuteSqlRawAsync("ReturnBooks {0},{1}",
           new SqlParameter("@IdLector", studentBookDTO.IdLector),
           new SqlParameter("@IdLibro", studentBookDTO.IdLibro));
        }
        public async Task<List<Prestamo>> GetBorrowedBooks()
        {
            return await context.Prestamo.FromSqlRaw<Prestamo>($"{Util.GetBorrowedBooks}").ToListAsync();
        }

        public async Task AssignAuthor(LibAut libAut)
        {
            await context.Database.ExecuteSqlRawAsync("AssignAuthor {0}, {1}",
            new SqlParameter("@IdLibro", libAut.IdLibro),
            new SqlParameter("@IdAutor", libAut.IdAutor));
        }
    }
}
