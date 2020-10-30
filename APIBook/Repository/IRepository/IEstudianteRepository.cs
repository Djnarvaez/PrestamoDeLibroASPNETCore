using APIBook.Models;
using APIBook.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Repository.IRepository
{
    public interface IEstudianteRepository
    {
        Task<List<Estudiante>> GetStudents();
        Task<Estudiante> GetStudent(int id);
        Task<int> CreateStudent(Estudiante estudiante);
        Task UpdateStudent(Estudiante estudiante);
        Task DeleteStudent(int id);
        Task<List<Prestamo>> GetBorrowedBooks();
        Task LendBooks(StudentBookDTO studentBook);
        Task ReturnBooks(StudentBookDTO studentBook);
    }
}
