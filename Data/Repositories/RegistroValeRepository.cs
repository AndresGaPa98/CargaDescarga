using CargaDescarga;

namespace Scm.Data.Repositories
{
    public class RegistroValeRepository : BaseRepository<RegistroVale>
    {
        public RegistroValeRepository(ScmContext context) : base(context)
        {
        }
    }
}