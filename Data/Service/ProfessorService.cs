

using AutoMapper;
using KissLog;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Models;
using SGIEscolar.Data.Repository;
using SGIEscolar.ViewModels;
using System;
using System.Threading.Tasks;

namespace SGIEscolar.Data.Service
{
    public class ProfessorService : BaseService<Professor, ProfessorViewModel>
    {
        private readonly ProfessorRepository _professor;
        public ProfessorService(ProfessorRepository repository, 
            INotificador notificador, 
            IMapper mapper, 
            ILogger logger, 
            IDapper dapper, 
            AutenticacaoService autenticacao) : base(repository, notificador, mapper, logger, dapper, autenticacao)
        {
            this._professor = repository;
        }

        public override async Task<int> Adicionar(ProfessorViewModel professor)
        {
            if (!await ExisteProfessor(professor))
            {
                await base.Adicionar(professor);
            } else
            {
                Notificar("Já existe um professor cadastrardo com esse email!");
            }
            return 0;
        }

        public override async Task<int> Atualizar(ProfessorViewModel professor)
        {
            if (!await ExisteProfessor(professor))
            {
                await base.Atualizar(professor);
            } else
            {
                Notificar("Já existe um professor cadastrardo com esse email!");
            }
            return 0;
        }

        public async Task<bool> ExisteProfessor(ProfessorViewModel professor)
        {
            var registro = await BuscarObjeto(x => x.Email == professor.Email && x.Id != new Guid() && x.Id != professor.Id);
            return (registro != null); 
        }
    }
}
