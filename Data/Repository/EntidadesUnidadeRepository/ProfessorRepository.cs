using SGIEscolar.Data.Context;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Repository
{
    public class ProfessorRepository : BaseRepository<Professor>
    {
        public ProfessorRepository(SGIEscolarContext DB) : base(DB)
        {
        }
    }
}
