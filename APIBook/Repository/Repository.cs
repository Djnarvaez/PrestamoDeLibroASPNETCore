using APIBook.Context;
using APIBook.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Task<bool> CreateAsync(T entity)
        {
            context.AddAsync(entity);
            return SaveAsync();
        }

        public Task<bool> DeleteAsync(T entity)
        {
            context.Remove(entity);
            return SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            context.Update(entity);
            return await SaveAsync();
        }
    }
}
