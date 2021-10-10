using SGIEscolar.Data.Context;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Repository
{
    public class PermissaoRespository : BaseRepository<Permissao>
    {
        public PermissaoRespository(SGIEscolarContext DB) : base(DB)
        {
        }
    }
}
