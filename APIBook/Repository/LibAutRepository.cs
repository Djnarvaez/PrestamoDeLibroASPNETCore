using APIBook.Context;
using APIBook.Models;
using APIBook.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Repository
{
    public class LibAutRepository : Repository<LibAut>, ILibAutRepository
    {
        private readonly ApplicationDbContext context;

        public LibAutRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
