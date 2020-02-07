using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using CargaDescarga;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Scm.Controllers.Dtos;
using Scm.Service;
using Scm.Domain;
using Scm.Data;

namespace Scm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    [ProducesResponseType(401, Type = typeof(string))]
    public class FacturaController : ControllerBase
    {
        private readonly ValeService _valeService;

        private IMapper _mapper;
        private ScmContext _context;
        private FacturaRepository _facturaRepository;

        
        public FacturaController(ValeService ValeService, IMapper mapper, FacturaRepository facturaRepository, ScmContext context)
        {
            _valeService = ValeService;
            _mapper = mapper;
            _facturaRepository= facturaRepository;
            _context= context;
        }

        private string CurrentUserId(ClaimsPrincipal claims){
                return claims.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpPost ("AgregarFcaturaPorVale")]
        public string Agregar([FromBody] RegisterFacturaDto model){ ///Estamos pidiendo los datos de EmpleadoDto
                try{
                     Factura Factura = _mapper.Map<Factura>(model);///De dto a Empleado
                    _facturaRepository.Insert(Factura);
                    
                    _context.SaveChanges(); ///guarda en la base de datos
                }catch(Exception e){
                    Console.WriteLine(e);
                    return "No se agrego";
                }
            return "Se ha agregado correctamente";
        }
        [HttpGet("{folio}")]        
        public IActionResult getById(string folio){
                
                var valeResult = _valeService.getByFolio(folio);
                if (valeResult.isSuccess){
                    var result = _mapper.Map<ValeDto>(valeResult.Result);
                    return Ok(result);
                }else{
                    return BadRequest(valeResult.Errors);
                }               
        }

        [HttpPost("filter/date")]        
        public IActionResult filterByDate(DateTime date){
                
                var valesResult = _valeService.getBetweenDate(date);
                if (valesResult.isSuccess){
                    var result = _mapper.Map<ValeDto>(valesResult.Result);
                    return Ok(result);
                }else{
                        return BadRequest(valesResult.Errors);
                }               
        }

        
    }
}