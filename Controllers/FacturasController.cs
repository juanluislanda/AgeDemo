using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgeDemo;
using AgeDemo.Models;
using AgeDemo.dto;

namespace AgeDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private FacturaAdapter adapter;

        public FacturasController(ApplicationDbContext context)
        {
            _context = context;
            adapter = new FacturaAdapter();
        }

        [HttpGet]
        public IEnumerable<DtoFactura> GetFacturas()
        {
            IEnumerable<Factura> factura =  _context.Factura.ToList();
            List<DtoFactura> dtos = new List<DtoFactura>();
            foreach(Factura f in factura)
            {
                dtos.Add(sumarize(f));
            }
            return dtos;
        }

        [HttpGet("{id}")]
        public DtoFactura GetFactura(int id)
        {
            Factura fact= _context.Factura.Find(id);
            return sumarize(fact);
        }

        private DtoFactura sumarize(Factura fact)
        {
            IEnumerable<Detalle> detalles = _context.Detalle.Where(b => b.Id == fact.Id);
            DtoFactura dto = adapter.convertDto(fact);
            double total = 0;
            foreach (Detalle detalle in detalles)
            {
                total += Convert.ToDouble(detalle.Monto_total);
            }
            dto.Monto = total;
            return dto;
        }

        [HttpPut("{id}")]
        public Factura PutFactura(int id,Factura factura)
        {
            if (id != factura.Id)
                return null;

            _context.Entry(factura).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                return factura;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }


        [HttpPost]
        public Factura PostFacturas(Factura factura)
        {
            _context.Factura.Add(factura);
            _context.SaveChanges();
            return factura;
        }

        [HttpDelete("{id}")]
        public Factura DeleteFactura(int id)
        {
            Factura factura = _context.Factura.Find(id);
            if (factura == null)
                return null;

            _context.Remove(factura);
            _context.SaveChanges();
            return factura;
        }
    }   
}
