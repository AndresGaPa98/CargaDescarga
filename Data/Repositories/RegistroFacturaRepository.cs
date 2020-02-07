using Scm.Domain;
using Scm.Data.Repositories;
using System;

namespace Scm.Data{
    public class RegistroFacturaRepository : BaseRepository<RegistroFactura>
    {
        public RegistroFacturaRepository(ScmContext context) : base(context)
        {
        }

        internal object GetByID()
        {
            throw new NotImplementedException();
        }
    }
}