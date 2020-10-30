using APIBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<LibAut> LibAut { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Prestamo> Prestamo { get; set; }
    }
}
