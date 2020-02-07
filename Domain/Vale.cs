using System.Runtime.InteropServices;
using System;
using Scm.Domain;

namespace CargaDescarga{
    public class Vale
    {
      public string FolioVale { get; set; } 
      public decimal Monto { get; set; } 
      public DateTime FechaExpedicionVale { get; set; } 
      public Empresa Empresa { get; set; }

    }
}