using SGIEscolar.Data.Context;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Repository
{
    public class LicencaRepository : BaseRepository<Licenca>
    {
        public LicencaRepository(SGIEscolarContext DB) : base(DB)
        {
        }
    }
}
