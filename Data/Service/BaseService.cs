using AutoMapper;
using Dapper;
using KissLog;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Models;
using SGIEscolar.Data.Notificacoes;
using SGIEscolar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SGIEscolar.Data.Service
{
    public class BaseService<TEntity, TEntityViewModel>: 
        IDisposable 
        where TEntity : BaseEntity
        where TEntityViewModel : BaseEntityViewModel
    {
        protected readonly INotificador _notificador;
        protected IMapper _mapper;
        protected IRepository<TEntity> _repository;
        protected readonly ILogger _logger;
        protected readonly IDapper _dapper;
        protected readonly AutenticacaoService _autenticacao;
        public BaseService(IRepository<TEntity> repository, INotificador notificador, IMapper mapper, ILogger logger, IDapper dapper, AutenticacaoService autenticacao)
        {
            this._repository = repository;
            this._notificador = notificador;
            this._mapper = mapper;
            this._logger = logger;
            this._dapper = dapper;
            this._autenticacao = autenticacao;
        }

        public virtual async Task<int> Adicionar(TEntityViewModel entity)
        {
            return await _repository.Adicionar(_mapper.Map<TEntity>(entity));
        }

        public virtual async Task<int> Atualizar(TEntityViewModel entity, string[] includes = null)
        {
            return await _repository.Atualizar(_mapper.Map<TEntity>(entity), includes);
        }

        public virtual async Task<int> Deletar(TEntityViewModel entity)
        {
            return await _repository.Deletar(_mapper.Map<TEntity>(entity));
        }

        public virtual async Task<int> DeletarPorId(Guid id, string[] includes = null)
        {
            return await _repository.DeletarPorId(id, includes);
        }

        public virtual async Task<IEnumerable<TEntityViewModel>> ListarTodos(string[] includes = null)
        {
            return _mapper.Map<IEnumerable<TEntityViewModel>>(await _repository.ListarTodos(includes));
        }

        public virtual async Task<IEnumerable<TEntityViewModel>> BuscarLista(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            return _mapper.Map<IEnumerable<TEntityViewModel>>(await _repository.BuscarLista(expression, includes));
        }

        public virtual async Task<TEntityViewModel> BuscarPorId(Guid id, string[] includes = null)
        {
            return _mapper.Map<TEntityViewModel>(await _repository.BuscarPorId(id, includes));
        } 
        
        public virtual async Task<TEntityViewModel> BuscarObjeto(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            return _mapper.Map<TEntityViewModel>(await _repository.BuscarObjeto(expression, includes));
        }
        public virtual async Task<IEnumerable<TEntityViewModel>> BuscarPorFiltro(string filtro, string[] colunas, string[] includes = null)
        {
            var response = new List<TEntity>();
            try
            {
                var table = typeof(TEntity).Name + "s";
                var query = "BEGIN SELECT TOP 500 * FROM [dbo].[" + table + "] ";

                // Inner Joins
                if (includes == null)
                    query += " WHERE ";
                else
                {
                    foreach (var item in includes)
                    {
                        query += " INNER JOIN " + item + "s" + " on " + table + "." + item + "Id = " + item + ".Id ";
                        if (Array.IndexOf(includes, item) == (includes.Length - 1))
                            query += " WHERE ";
                    }
                }
                // Colunas
                foreach (var item in colunas)
                {
                    query += table + "." + item + " LIKE '%' + @filtro + '%' ";
                    if (Array.IndexOf(colunas, item) < (colunas.Length - 1))
                        query += " OR ";
                }
                var parametros = new DynamicParameters();
                parametros.Add("filtro", filtro);
                response = await _dapper.RetornaListaQueryAsync<TEntity>(query += " END", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _mapper.Map<IEnumerable<TEntityViewModel>>(response);
        }


        public void Notificar(string mensagem, bool state = false)
        {
            _notificador.Handle(new Notificacao(mensagem, state));
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
