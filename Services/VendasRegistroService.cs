using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class VendasRegistroService
    {
        private readonly VendasWebMvcContext _context;

        public VendasRegistroService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<VendasRegistro>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.RegistroVendas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }

            return await result
                        .Include(x => x.Vendedor)
                        .Include(x => x.Vendedor.Departamento)
                        .OrderByDescending(x => x.Data)
                        .ToListAsync();
        }
    }
}
