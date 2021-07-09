using SGIEscolar.Data.Context;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Repository
{
    public class InstituicaoRepository : BaseRepository<Instituicao>
    {
        public InstituicaoRepository(SGIEscolarContext DB) : base(DB)
        {
        }
    }
}
