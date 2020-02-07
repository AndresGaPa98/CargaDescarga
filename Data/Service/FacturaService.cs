using System;
using System.Collections.Generic;
using Scm.Domain;
using scm.Service;
using Scm.Data;
using Scm.Data.Repositories;

namespace Scm.Service
{

    public class FacturaService
    {   
        private RegistroFacturaRepository _registroFacturaRepository;

        private ValeRepository _valeRepository;
        private FacturaRepository _facturaRepository;

        private ScmContext _context;
        public FacturaService(ScmContext context, FacturaRepository facturaRepository, ValeRepository valeRepository, RegistroFacturaRepository registroFacturaRepository)
        {
            _registroFacturaRepository = registroFacturaRepository;
            _valeRepository = valeRepository;
            _facturaRepository = facturaRepository;
            _context = context;
        }
        public ServiceResult<Vale> getByFolio(string folio){ ///FALTA RETORNO DE ERRORES
                Vale vale = _valeRepository.GetByFolio(folio);
                var result = new ServiceResult<Vale>();
                if(vale != null)
                {
                    result.isSuccess = true;
                    result.Result = vale;
                }
                else{
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add("No existe ninguno con ese folio");
                }
                return result;
        }
        public ServiceResult<Factura> Save(Factura factura){
                _facturaRepository.Insert(factura); //Se registra la factura
                foreach(Vale v in factura.Vales)
                {
                    v.FacturaFolioFactura = factura.FolioFactura;
                    _valeRepository.Update(v);
                }
                var affectedRows = _context.SaveChanges();
                if( affectedRows ==0 ) {
                    //Hubo un pex
                    var result = new ServiceResult<Factura>();
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add("No se pudo guardar el registro vale");
                    return result;
                }
                else{
                    var result = new ServiceResult<Factura>();
                    result.isSuccess = true;
                    result.Result = factura;
                    return result;
                    }
        }
        public ServiceResult<Vale> getBetweenDate(DateTime date,DateTime date2){ ///FALTA RETORNO DE ERRORES
                
                var result = new ServiceResult<Vale>();
                result.isSuccess = true;
                result.Results = _valeRepository.getBetweenDate(date, date2);
                return result;
        }

    }
}