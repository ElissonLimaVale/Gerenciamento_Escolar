using SGIEscolar.Data.Context;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Repository
{
    public class AlunoRepository : BaseRepository<Aluno>
    {
        public AlunoRepository(SGIEscolarContext DB) : base(DB)
        {
        }
    }
}
