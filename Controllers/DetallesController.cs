using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgeDemo;
using AgeDemo.Models;

namespace AgeDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DetallesController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<Detalle> GetDetalles()
        {
            return _context.Detalle.ToList();
        }

        [HttpGet("{linea}")]
        public Detalle GetDetalle(int linea)
        {
            return _context.Detalle.Find(linea);
        }

        [HttpPut("{linea}")]
        public Detalle PutDetalle(int linea, Detalle detalle)
        {
            if (linea != detalle.Linea)
                return null;

            _context.Entry(detalle).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                return detalle;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        [HttpPost]
        public Detalle PostDetalle(Detalle detalle)
        {
            _context.Detalle.Add(detalle);
            _context.SaveChanges();
            return detalle;
        }

        [HttpDelete("{linea}")]
        public Detalle DeleteFactura(int linea)
        {
            Detalle detalle = _context.Detalle.Find(linea);
            if (detalle == null)
                return null;

            _context.Remove(detalle);
            _context.SaveChanges();
            return detalle;
        }


    }   
}
