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
    public class TurmaService : BaseService<Turma, TurmaViewModel>
    {
        public TurmaService(
            TurmaRepository repository, 
            INotificador notificador, 
            IMapper mapper, 
            ILogger logger,
            IDapper dapper,
            AutenticacaoService autenticacao) : base(repository, notificador, mapper, logger, dapper, autenticacao)
        {
        }

        public override async Task<int> Adicionar(TurmaViewModel entity)
        {
            if(! await ExisteItem(entity))
            {
                return await base.Adicionar(entity);
            }
            Notificar("Ops, já existe uma turma cadastrada com o mesmo Nome e/ou Série!");
            return 0;
        }

        private async Task<bool> ExisteItem(TurmaViewModel entity)
        {
            var turmas = await base.BuscarLista(x => x.Id.Equals(entity.Id) || x.Nome.Equals(entity.Nome) || x.Serie.Equals(entity.Serie));
            return turmas.Any();
        }
    }
}


