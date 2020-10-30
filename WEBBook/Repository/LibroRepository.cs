using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WEBBook.Models;
using WEBBook.Repository.IRepository;

namespace WEBBook.Repository
{
    public class LibroRepository : Repository<Libro>, ILibroRepository
    {
        private readonly IHttpClientFactory httpClientFactory;

        public LibroRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
    }
}
