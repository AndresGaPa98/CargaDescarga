using System;
using System.Collections.Generic;
using CargaDescarga;
using scm.Service;
using Scm.Data;
using Scm.Data.Repositories;
namespace Scm.Service
{
    public class CajaService
    {
        private CajaRepositorio _cajaRepositorio;
        private ScmContext _context;
        public CajaService(ScmContext context,CajaRepositorio cajaRepositorio)
        {
            _cajaRepositorio = cajaRepositorio;
            _context = context;

        }
        public ServiceResult<RegistroValeRepository> getBetweenDate(DateTime FechaApertura, DateTime FechaCierre)
        { ///FALTA RETORNO DE ERRORES
                
            var result = new  ServiceResult<RegistroFacturaRepository>();
            try{
                result.isSuccess = true;
                result.Results = _cajaRepositorio.getBetweenDate(FechaApertura, FechaCierre);
                if(result.Results.Count < 1)
                {
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add("No existe ningun vale entre esas fechas");
                }
                return result;
            }
            catch(Exception ex)
            {
                result.isSuccess = false;
                result.Errors = new List<string>();
                result.Errors.Add(ex.ToString());
                return result;
            }
        }

        
    }
}