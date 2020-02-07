using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scm.Controllers.Dtos;
using Scm.Data;
using Scm.Domain;

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

    }
}