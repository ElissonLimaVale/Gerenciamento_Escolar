using SGIEscolar.Data.Context;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public UsuarioRepository(SGIEscolarContext DB) : base(DB)
        {
        }
    }
}
