using System;
using System.Collections.Generic;
using CargaDescarga;
using scm.Service;
using Scm.Data;
using Scm.Data.Repositories;

namespace Scm.Service
{

    public class ValeService
    {   
        private RegistroValeRepository _registroValeRepository;

        private ValeRepository _valeRepository;

        private ScmContext _context;
        public ValeService(ScmContext context, ValeRepository valeRepository, RegistroValeRepository registroValeRepository)
        {
            _registroValeRepository = registroValeRepository;
            _valeRepository = valeRepository;
            _context = context;
        }
        public ServiceResult<Vale> getByBusinessName(String name){
                
                var result = new ServiceResult<Vale>();
                result.isSuccess = true;
                result.Results = _valeRepository.getByBusinessName(name);
                return result;
        }
        public ServiceResult<Vale> getBetweenDate(DateTime date){
                
                var result = new ServiceResult<Vale>();
                result.isSuccess = true;
                result.Results = _valeRepository.getBetweenDate(date);
                return result;
        }

    }
}