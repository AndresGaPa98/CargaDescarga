using System;

namespace Scm.Domain
{
    public class ReporteMovimientos
    {
        public decimal TotalEgreso { get; set; }
        public decimal TotalIngreso { get; set; }
        public DateTime FechaReporte { get; set; }
    }
}