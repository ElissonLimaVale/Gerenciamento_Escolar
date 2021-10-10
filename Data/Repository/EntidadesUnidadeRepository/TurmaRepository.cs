using SGIEscolar.Data.Context;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Repository
{
    public class TurmaRepository : BaseRepository<Turma>
    {
        public TurmaRepository(SGIEscolarContext DB) : base(DB)
        {
        }
    }
}
