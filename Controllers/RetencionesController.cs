using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scm.Controllers.Dtos;
using Scm.Data;
using Scm.Data.Repositories;
using CargaDescarga;

namespace Scm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RetencionesController:ControllerBase
    {
        RetencionesRepository RetencionesRepository;
        ScmContext Context;
        IMapper Mapper;
        public RetencionesController(RetencionesRepository _retencionesRepository, ScmContext _context, IMapper _mapper){
            RetencionesRepository = _retencionesRepository;
            Context = _context;
            Mapper = _mapper;
        }
        [HttpPost ("Agregar Retenciones")]
        public IActionResult AgregarRetenciones(RetencionesDto Dto){
            Retenciones Retenciones= Mapper.Map<Retenciones>(Dto);
            RetencionesRepository.Insert(Retenciones);
            Context.SaveChanges();
            return Ok(Dto);
        }
    }
}