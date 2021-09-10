using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgeDemo.Models;

namespace AgeDemo.dto
{
    public class FacturaAdapter
    {
        public DtoFactura convertDto(Factura factura)
        {
            DtoFactura ret = new DtoFactura();
            ret.Id = factura.Id;
            ret.Nombre = factura.Nombre;
            ret.Fecha = factura.Fecha;
            ret.Nit = factura.Nit;
            ret.Correlativo = factura.Correlativo;
            return ret;
        }

        public Factura convertEntity(DtoFactura factura)
        {
            Factura ret = new Factura();
            ret.Id = factura.Id;
            ret.Nombre = factura.Nombre;
            ret.Fecha = factura.Fecha;
            ret.Nit = factura.Nit;
            ret.Correlativo = factura.Correlativo;
            return ret;
        }
    }
}
