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
        private readonly FacturaService _facturaService;

        private IMapper _mapper;
        private ScmContext _context;
        private FacturaRepository _facturaRepository;

        
        public FacturaController(FacturaService ValeService, IMapper mapper, FacturaRepository facturaRepository, ScmContext context)
        {
            _facturaService = ValeService;
            _mapper = mapper;
            _facturaRepository= facturaRepository;
            _context= context;
        }

        private string CurrentUserId(ClaimsPrincipal claims){
                return claims.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpPost ("agregar")]
        public string Agregar([FromBody] RegisterFacturaDto model){ ///Estamos pidiendo los datos de EmpleadoDto
                try{

                    
                    List<Vale> vales = _facturaService.getBetweenDate(model.FechaInicial,model.FechaFinal).Results;
                    
                    Factura factura = new Factura();///De dto a Empleado
                    factura.FolioFactura = model.FolioFactura;
                    factura.FechaExpedicion = DateTime.Now; //Fecha de hoy
                    factura.Vales = vales;
                    factura.Monto = factura.montoTotal();

                    _facturaService.Save(factura);
                    
                    _context.SaveChanges(); ///guarda en la base de datos
                }catch(Exception e){
                    Console.WriteLine(e);
                    return "No se agrego";
                }
            return "Se ha agregado correctamente";
        }
        [HttpGet("{folio}")]        
        public IActionResult getById(string folio){
                
                var valeResult = _facturaService.getByFolio(folio);
                if (valeResult.isSuccess){
                    var result = _mapper.Map<ValeDto>(valeResult.Result);
                    return Ok(result);
                }else{
                    return BadRequest(valeResult.Errors);
                }               
        }

        [HttpPost("filter/date")]        
        public IActionResult filterByDate(DateTime date,DateTime date2){
                
                var valesResult = _facturaService.getBetweenDate(date, date2);
                if (valesResult.isSuccess){
                    var result = _mapper.Map<ValeDto>(valesResult.Result);
                    return Ok(result);
                }else{
                        return BadRequest(valesResult.Errors);
                }               
        }

        
    }
}