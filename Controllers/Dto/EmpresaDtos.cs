using System.ComponentModel.DataAnnotations;

namespace Scm.Controllers.Dtos
{
    public class EmpresaDtos
    {
        [Required]
<<<<<<< HEAD
        public string  NombreEmpresa { get; set; }
=======
<<<<<<< Updated upstream
        public string  NombreEmpresa { get; set; }
=======
        public string  Nombre { get; set; }
>>>>>>> Stashed changes
>>>>>>> 30dc523020a5843d80cb588a1f7933373b9f918e
    }

    public class EmpresaResponseDto
    {
        public int IdEmpresa { get; set; }
<<<<<<< HEAD
        public string NombreEmpresa { get; set; }
=======
<<<<<<< Updated upstream
        public string NombreEmpresa { get; set; }
=======
        public string Nombre { get; set; }
>>>>>>> Stashed changes
>>>>>>> 30dc523020a5843d80cb588a1f7933373b9f918e
    }
}