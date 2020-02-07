using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scm.Data;
<<<<<<< Updated upstream
using Scm.Domain;
using Scm.Controllers;
using Scm.Controllers.Dtos;
=======
>>>>>>> Stashed changes

namespace Scm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController: ControllerBase
    {
        private EmpresaRepository _empresaRepository;
        private ScmContext _context;
        private IMapper _mapper;

        public EmpresaController(EmpresaRepository EmpresaRepository, ScmContext context, IMapper mapper){
            _empresaRepository = EmpresaRepository;
            _context = context;
            _mapper = mapper;

        }
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
    }
}