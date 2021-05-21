using AutoMapper;
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
        public BaseService(IRepository<TEntity> repository, INotificador notificador, IMapper mapper, ILogger logger)
        {
            this._repository = repository;
            this._notificador = notificador;
            this._mapper = mapper;
            this._logger = logger;
        }

        public virtual async Task Adicionar(TEntityViewModel entity)
        {
            await _repository.Adicionar(_mapper.Map<TEntity>(entity));
        }

        public virtual async Task Atualizar(TEntityViewModel entity)
        {
            await _repository.Atualizar(_mapper.Map<TEntity>(entity));
        }

        public virtual async Task Deletar(TEntityViewModel entity)
        {
            await _repository.Deletar(_mapper.Map<TEntity>(entity));
        }

        public virtual async Task<IEnumerable<TEntityViewModel>> ListarTodos()
        {
            return _mapper.Map<IEnumerable<TEntityViewModel>>(await _repository.ListarTodos());
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

        public void Notificar(string mensagem, bool state = false)
        {
            _notificador.Handle(new Notificacao(mensagem, state));
        }

        public void Dispose()
        {
            this?.Dispose();
        }
    }
}
