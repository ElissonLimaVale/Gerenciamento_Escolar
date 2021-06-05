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
    public class AlunoService : BaseService<Aluno, AlunoViewModel>
    {
        private readonly AlunoRepository _aluno;
        public AlunoService(
            AlunoRepository repository, 
            INotificador notificador, 
            IMapper mapper, 
            ILogger logger) : base(repository, notificador, mapper, logger)
        {
            this._aluno = repository;
        }

        public override async Task<int> Adicionar(AlunoViewModel aluno)
        {
            if (!await ExisteAluno(aluno))
                await base.Adicionar(aluno);
            else
                Notificar("Já existe um aluno cadastrado com esse CPF!");
            return 0;
        }
        
        public override async Task<int> Atualizar(AlunoViewModel aluno)
        {
            if (!await ExisteAluno(aluno))
                await base.Atualizar(aluno);
            else
                Notificar("Já existe um aluno cadastrado com esse CPF!");
            return 0;
        }

        private async Task<bool> ExisteAluno(AlunoViewModel aluno)
        {
            var registro = await BuscarObjeto(x => x.CPF == aluno.CPF && x.Id != new Guid() && x.Id != aluno.Id);
            return (registro != null);
        }
    }
}
