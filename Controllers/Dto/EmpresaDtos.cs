using System.ComponentModel.DataAnnotations;

namespace Scm.Controllers.Dtos
{
    public class EmpresaDtos
    {
        [Required]
<<<<<<< Updated upstream
        public string  NombreEmpresa { get; set; }
=======
        public string  Nombre { get; set; }
>>>>>>> Stashed changes
    }

    public class EmpresaResponseDto
    {
        public int IdEmpresa { get; set; }
<<<<<<< Updated upstream
        public string NombreEmpresa { get; set; }
=======
        public string Nombre { get; set; }
>>>>>>> Stashed changes
    }
}