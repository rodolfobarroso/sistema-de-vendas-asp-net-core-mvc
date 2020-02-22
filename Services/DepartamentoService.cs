using System;
using System.Collections.Generic;
using System.Linq;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace VendasWebMvc.Services
{
    public class DepartamentoService
    {
        private readonly VendasWebMvcContext _context;


        public DepartamentoService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
