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
        
        public Empleado Empleado {get; set;}
        public AppUser Usuario { get; set; }
        public decimal? IVAAplicado { get; set; }
        
        public decimal? GastosFacturacion { get; set; }
        public decimal? GastosSeguridadSocial { get; set; }
        public int IdEmpleado { get; set; }
        public string UsuarioId { get; set; }
        public List<Vale> Vales {get; set;}

        public decimal montoTotal()
        {
            decimal SUM = 0.0M;
            foreach(Vale v in Vales)
            {
                SUM += v.Monto;
            }
            return SUM;
        }
    }
}