﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class VendedorService
    {
        private readonly VendasWebMvcContext _context;

        public VendedorService( VendasWebMvcContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor obj)
        {
            /*Estava sendo usando quando não tinha Departamento instanciado, 
             *daí quebrava a integridade referencial de Vendedor-Departamento.
             obj.Departamento = _context.Departamento.First(); */
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
