﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WEBBook.Models;
using WEBBook.Repository.IRepository;

namespace WEBBook.Repository
{
    public class EstudianteRepository : Repository<Estudiante>, IEstudianteRepository
    {
        private readonly IHttpClientFactory httpClientFactory;

        public EstudianteRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
    }
}
