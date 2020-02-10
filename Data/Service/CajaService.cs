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
       

        
    }
}