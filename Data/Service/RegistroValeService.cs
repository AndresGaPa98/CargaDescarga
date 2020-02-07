using System;
using System.Collections.Generic;
using CargaDescarga;
using scm.Service;
using Scm.Data;
using Scm.Data.Repositories;

namespace Scm.Service
{

    public class RegistroValeService
    {   
        private RegistroValeRepository _registroValeRepository;

        private RetencionRepository _retencionRepository;

        private ScmContext _context;
        public RegistroValeService(ScmContext context, RegistroValeRepository registroValeRepository, RetencionRepository retencionRepository)
        {
            _registroValeRepository = registroValeRepository;
            _retencionRepository = retencionRepository;
            _context = context;
        }
        public ServiceResult<RegistroVale> Save(RegistroVale registroVale){

             //Validar que los vales no se hayan registrado previamente
            
            //Se deben realizar los cálculos y registro de ingreso y egreso
            try{
                _registroValeRepository.Insert(registroVale);
                registroVale.IVAAplicado = _retencionRepository.GetById("IVA").Value;
                var affectedRows = _context.SaveChanges();
                if( affectedRows ==0 ) {
                    //Hubo un pex
                    var result = new ServiceResult<RegistroVale>();
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add("No se pudo guardar el registro vale");
                    return result;
                }
                else{
                    var result = new ServiceResult<RegistroVale>();
                    result.isSuccess = true;
                    result.Result = registroVale;
                    return result;
                    }
            }catch(Exception ex){
                    var result = new ServiceResult<RegistroVale>();
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add(ex.Message);
                    return result;
            }


           


        }

    }
}