using AutoMapper;
using KissLog;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Models;
using SGIEscolar.Data.Repository;
using SGIEscolar.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGIEscolar.Data.Service
{
    public class TurmaService : BaseService<Turma, TurmaViewModel>
    {
        private readonly TurmaRepository _turma;
        public TurmaService(
            TurmaRepository repository, 
            INotificador notificador, 
            IMapper mapper, 
            ILogger logger,
            IDapper dapper,
            AutenticacaoService autenticacao) : base(repository, notificador, mapper, logger, dapper, autenticacao)
        {
            this._turma = repository;
        }

        public override async Task<int> Adicionar(TurmaViewModel turma)
        {
            await base.Adicionar(turma);
            var turmas = new List<TurmaViewModel>();
            turmas.Add(new TurmaViewModel
            {
                Nome = "Primeiro Ano A",
                Serie = "1º A"
            });
            turmas.Add(new TurmaViewModel
            {
                Nome = "Primeiro Ano B",
                Serie = "1º B"
            });
            turmas.Add(new TurmaViewModel
            {
                Nome = "Segundo Ano A",
                Serie = "2º A"
            });
            turmas.Add(new TurmaViewModel
            {
                Nome = "Segundo Ano B",
                Serie = "2º B"
            });
            turmas.Add(new TurmaViewModel
            {
                Nome = "Terceiro Ano A",
                Serie = "3º A"
            });
            turmas.Add(new TurmaViewModel
            {
                Nome = "Terceiro Ano B",
                Serie = "3º B"
            });
            turmas.ForEach((item) =>
            {
                _ = base.Adicionar(item).Result;
            });
            return 0;
        }
    }
}


