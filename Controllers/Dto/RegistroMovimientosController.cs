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
using Scm.Data.Repositories;


namespace Scm.Controllers
{
[Route("api/[controller]")]
    [ApiController]
    
    public class RegistroMovimientosController:ControllerBase{


        private RegistroValeRepository _registroValeRepository;
     
        
        private IMapper _mapper;

public RegistroMovimientosController(RegistroValeRepository registroValeRepository, IMapper mapper){

    _registroValeRepository = registroValeRepository;
    
    _mapper = mapper;
}


         [HttpGet("Todos")]
        public IActionResult Get(){
            var Regs = _registroValeRepository.GetAll();
            var RegsDtos = _mapper.Map<List<RegisterValesResponseDto>>(Regs);
            return Ok(RegsDtos);
        }

    }



}