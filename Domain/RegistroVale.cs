using System.Collections;
using System;
using System.Collections.Generic;
using Scm.Domain;
using System.Linq;

namespace CargaDescarga{
    public class RegistroVale
    {
        public int IdRegistroVale { get; set; }
        public DateTime Fecha  { get; set; }
         public decimal? IVAAplicado { get; set; }
         public decimal? GastosCobranzaInversion{get; set;}
        public decimal? GastosFacturacion { get; set; }
        public decimal? GastosSeguridadSocial { get; set; }
        ///Total sin aplicar retenciones
        public decimal GetSubTotalVale (){
            decimal suma  =0.0M;
            if(Vales != null && Vales.Count>0){
                foreach(var value in Vales)
                suma +=value.Monto;
            }
            //Vales.Select(x=>suma=x.Monto);
            return suma;
         }
         public decimal GetIVA() { 
            return GetSubTotalVale() * (IVAAplicado.Value/100);
         }

         public decimal Total() { 
            return GetSubTotalVale() + GetIVA();
         }

        ///public Retenciones Retenciones {get; set;}
        public Empleado Empleado { get; set; }
        public List<Vale> Vales { get; set; }
        public AppUser Usuario {get; set;}
        public int IdEmpleado { get; set; }
        public string UsuarioId { get; set; }
    }
}