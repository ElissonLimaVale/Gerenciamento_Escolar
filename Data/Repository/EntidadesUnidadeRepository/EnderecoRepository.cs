using SGIEscolar.Data.Context;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>
    {
        public EnderecoRepository(SGIEscolarContext DB) : base(DB)
        {
        }
    }
}
