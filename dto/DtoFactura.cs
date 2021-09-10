using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeDemo.dto
{
    public class DtoFactura
    {

       
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }

        public string Fecha { get; set; }

        public string Correlativo { get; set; }

       public double Monto { get; set; }
    }
}
