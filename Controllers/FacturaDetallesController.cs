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
    public class FacturaDetalles : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FacturaDetalles(ApplicationDbContext context)
        {
            _context = context;
        }




        [HttpGet("{id}")]
        public IEnumerable<Detalle> GetDetalleByFactura(int id)
        {
            return _context.Detalle.Where(b => b.Id == id);
        }

    }
}
