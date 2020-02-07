using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scm.Controllers.Dtos;
using Scm.Data;
<<<<<<< HEAD
using Scm.Domain;
=======
<<<<<<< Updated upstream
using Scm.Domain;
using Scm.Controllers;
using Scm.Controllers.Dtos;
=======
>>>>>>> Stashed changes
>>>>>>> 30dc523020a5843d80cb588a1f7933373b9f918e

namespace Scm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController: ControllerBase
    {
        private const string V = "No se guardo el registro";
        private EmpresaRepository _empresaRepository;
        private ScmContext _context;
        private IMapper _mapper;

        public EmpresaController(EmpresaRepository EmpresaRepository, ScmContext context, IMapper mapper){
            _empresaRepository = EmpresaRepository;
            _context = context;
            _mapper = mapper;

        }
<<<<<<< HEAD
        [HttpPost("Agregar")]
        public string Agregar(EmpresaDtos empresa){
            
                Empresa Empresa = _mapper.Map<Empresa>(empresa);
                _empresaRepository.Insert(Empresa);
                var regis = _context.SaveChanges();
                if(regis==0){
                    return "Fallo al momento de guardar";
                }
                else{
                    return "Registro guardado exitosamente";
                }
            
        }

        [HttpGet("Buscar")]
        public IActionResult GetId(int idEmpresa){
            var Empresa = _empresaRepository.GetById(idEmpresa);
            if(Empresa == null)
                return NotFound();
            var emprdto = _mapper.Map<EmpresaResponseDto>(Empresa);
            return Ok(emprdto);
        }


=======
<<<<<<< Updated upstream
        [HttpPut]
         public IActionResult Put(int id, [FromBody]  EmpresaResponseDto model){
            //Model validation
            var empresa= _mapper.Map<Empresa>(model);
            //bug.ModifiedAt = DateTime.Now;
            //bug.ModifiedById =  CurrentUserId(User as ClaimsPrincipal);
            _empresaRepository.Update(empresa);
            _context.SaveChanges();
            var dto = _mapper.Map<EmpresaResponseDto>(empresa);
            return Ok(dto);
        }
=======
>>>>>>> Stashed changes
>>>>>>> 30dc523020a5843d80cb588a1f7933373b9f918e
    }
}