using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scm.Controllers.Dtos
{
   
public class RegisterValesDto
    {
        [Required]
        public int IdEmpleado { get; set; }
        [Required]
        public List<ValeDto> Vales { get; set; }
    }


    public class ValeDto
    {
        [Required]
        public string Folio { get; set; }
        [Required]
        public Decimal Monto { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string   Empresa  { get; set; }

    }

    public class RegisterValesResponseDto
    {
        public int IdRegistroVale { get; set; }
        public DateTime Fecha  { get; set; }
        public Decimal Subtotal { get; set; }
        public Decimal MontoIVA{ get; set; }
        public Decimal Total{ get; set; }

        //Retenciones
    }
}