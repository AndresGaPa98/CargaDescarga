using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Scm.Controllers.Dtos{
    public class CajaDtos
    {
        [Required]
        public DateTime FechaApertura{get;set;}
        [Required]
        public string Username { get; set; }
        [Required]
        public decimal CantidadInicial { get; set; }
    }
}