using System;
using System.Collections.Generic;
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
        [HttpGet("Buscar {idEmpresa}")]
        public IActionResult GetId(int idEmpresa){
            var Empresa = _empresaRepository.GetById(idEmpresa);
            if(Empresa == null)
                return NotFound();
            var emprdto = _mapper.Map<EmpresaResponseDto>(Empresa);
            return Ok(emprdto);
        }
        [HttpGet("BuscarTodos")]
        public IActionResult GetAll(){
            var empresas = _empresaRepository.GetAll();
            var EmpresasResult = _mapper.Map<List<EmpresaResponseDto>>(empresas);
            return Ok(EmpresasResult);
        }

        [HttpPut("Modificar")]
        /*Para modificar se requiere que el parametro de idEmpresa en el cuerpo del JSON sea el mismo que
        se usa al elegir una empresa para editar debido a que es llave foranea en factura y vale (ocurre
        lo mismo con la seccion de modificar del empleado)*/
        public IActionResult Put(int idEmpresa, [FromBody]  EmpresaResponseDto model){
            var empresa= _mapper.Map<Empresa>(model);
            _empresaRepository.Update(empresa);
            _context.SaveChanges();
            var dto = _mapper.Map<EmpresaResponseDto>(empresa);
            return Ok(dto);
        }
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int idEmpresa){
            _empresaRepository.Delete(idEmpresa);
            _context.SaveChanges();
            return Ok();
        }

    }
}