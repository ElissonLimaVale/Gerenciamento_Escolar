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
        private readonly EnderecoService _endereco;
        public AlunoService(
            AlunoRepository repository, 
            INotificador notificador, 
            IMapper mapper, 
            ILogger logger,
            IDapper dapper,
            AutenticacaoService autenticacao,
            EnderecoService endereco) : base(repository, notificador, mapper, logger, dapper, autenticacao)
        {
            this._aluno = repository;
            this._endereco = endereco;
        }

        public override async Task<int> Adicionar(AlunoViewModel aluno)
        {
            if (!await ExisteAluno(aluno))
                await base.Adicionar(aluno);
            else
                Notificar("Já existe um aluno cadastrado com esse CPF!");
            return 0;
        }
        
        public override async Task<int> Atualizar(AlunoViewModel aluno, string[] includes = null)
        {
            if (!await ExisteAluno(aluno))
            {
                await base.Atualizar(aluno, includes);
                await _endereco.Atualizar(aluno.Endereco);
            }
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
