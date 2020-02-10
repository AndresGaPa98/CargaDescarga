using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Scm.Controllers.Dtos;
using Scm.Domain;
using Scm.Infrastructure.Authentication;
using Scm.Infrastructure.ManagedResponses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Scm.Data;
using System;
using System.Collections.Generic;
namespace scm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    

    public class CajaController : ControllerBase
    {

        private CajaRepositorio _cajaRepositorio;
        private ScmContext _context;
        private IMapper _mapper;

        public CajaController(CajaRepositorio _cajaRepositorio, ScmContext _context, IMapper _mapper){
            this._cajaRepositorio=_cajaRepositorio;
            this._context = _context;
            this._mapper = _mapper;
        }

        [HttpPost ("inicioCaja")]
        public string InicioCaja([FromBody] CajaDtosOpen model){ ///Estamos pidiendo los datos de EmpleadoDto
                 
                // Caja.FechaApertura=DateTime.Now;
                //try{
                    Caja Caja = _mapper.Map<Caja>(model);///De dto a Empleado
                    _cajaRepositorio.Insert(Caja); ///inserta xd
                   Caja.FechaApertuta=DateTime.Now;
                    _context.SaveChanges(); ///guarda en la base de datos
                ///}catch(Exception e){
                   // Console.WriteLine(e);
                    //return "No se agrego";
                //}
            return "Se ha agregado correctamente";
        }

        [HttpPut("CierreCaja")]
                public IActionResult Put(int IdCaja, [FromBody]  CajaDtosClouse model){

                var cajaActual = _cajaRepositorio.GetById(IdCaja);
                cajaActual.FechaCiere = DateTime.Now;
                cajaActual.CantidadFinal = model.CantidadFinal;
            //var Caja= _mapper.Map<Caja>(model);
            _cajaRepositorio.Update(cajaActual);
            _context.SaveChanges();
            var dto = _mapper.Map<CajaDtosClouse>(cajaActual);
            return Ok(dto);
        }

    }

    


}