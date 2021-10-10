using AutoMapper;
using KissLog;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Models;
using SGIEscolar.Data.Repository;
using SGIEscolar.ViewModels;

namespace SGIEscolar.Data.Service
{
    public class PermissaoService : BaseService<Permissao, PermissaoViewModel>
    {
        public PermissaoService(PermissaoRespository repository, 
            INotificador notificador, 
            IMapper mapper, 
            ILogger logger, 
            IDapper dapper, 
            AutenticacaoService autenticacao) : base(repository, notificador, mapper, logger, dapper, autenticacao)
        {
        }
    }
}
