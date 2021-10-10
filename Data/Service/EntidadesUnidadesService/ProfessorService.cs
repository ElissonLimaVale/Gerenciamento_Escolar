using AutoMapper;
using KissLog;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Models;
using SGIEscolar.Data.Repository;
using SGIEscolar.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SGIEscolar.Data.Service
{
    public class ProfessorService : BaseService<Professor, ProfessorViewModel>
    {
        private readonly EnderecoService _endereco;
        public ProfessorService(ProfessorRepository repository, 
            EnderecoService endereco,
            INotificador notificador, 
            IMapper mapper, 
            ILogger logger, 
            IDapper dapper, 
            AutenticacaoService autenticacao) : base(repository, notificador, mapper, logger, dapper, autenticacao)
        {
            _endereco = endereco;
        }

        public override async Task<int> Adicionar(ProfessorViewModel entity)
        {
            if (!await ExisteItem(entity))
            {
                return await base.Adicionar(entity);
            }
            Notificar("Ops, já existe um professor cadastrado com este Email/Nome ou Id!");
            return 0;
        }

        public override async Task<int> Atualizar(ProfessorViewModel entity, string[] includes = null)
        {
            if(! await ExisteItem(entity))
            {
                await _endereco.Atualizar(entity.Endereco);
                return await base.Atualizar(entity, includes);
            }
            Notificar("Ops, já existe um professor cadastrado com este Email/Nome ou Id!");
            return 0;
        }

        private async Task<bool> ExisteItem(ProfessorViewModel entity)
        {
            var professores = await BuscarLista(x => x.Id.Equals(entity.Id) || x.Nome.Equals(entity.Nome) || x.Email.Equals(entity.Email));
            return professores.Any();
        }
    }
}
