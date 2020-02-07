using System;
using System.Collections.Generic;
using CargaDescarga;

namespace Scm.Domain
{
    public class RegistroFactura
    {
        public int IdRegistroFactura { get; set; }
        public DateTime Fecha {get; set;}
        public decimal TotalFactura { get; set; }
        public List<Factura> Facturas { get; set; }
        public Retenciones Retencion { get; set; }
        public Empleado Empleado {get; set;}
        public ReporteMovimientos ReporteMovimiento { get; set; }
    }
}