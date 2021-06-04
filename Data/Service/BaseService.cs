using AutoMapper;
using KissLog;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Models;
using SGIEscolar.Data.Notificacoes;
using SGIEscolar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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

        public void Adicionar(TEntityViewModel entity)
        {
            try
            {
                _repository.Adicionar(_mapper.Map<TEntity>(entity));
                this.Notificar("Cadastrado com sucesso!", true);
            }catch(Exception ex)
            {
                _logger.Error(ex);
                this.Notificar(ex.Message.ToString());
            }
        }

        public void Atualizar(TEntityViewModel entity)
        {
            try
            {
                _repository.Atualizar(_mapper.Map<TEntity>(entity));
                this.Notificar("Atualizado com sucesso!", true);
            } catch (Exception ex) {
                _logger.Error(ex);
                this.Notificar(ex.Message.ToString());
            }
        }

        public void Deletar(TEntityViewModel entity)
        {
            try
            {
                _repository.Deletar(_mapper.Map<TEntity>(entity));
                this.Notificar("Deletado com sucesso!", true);
            } catch (Exception ex) {
                _logger.Error(ex);
                this.Notificar(ex.Message.ToString());
            }
        }

        public IEnumerable<TEntityViewModel> ListarTodos()
        {
            return _mapper.Map<IEnumerable<TEntityViewModel>>(_repository.ListarTodos());
        }
        public IEnumerable<TEntityViewModel> BuscarLista(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            return _mapper.Map<IEnumerable<TEntityViewModel>>(_repository.BuscarLista(expression, includes));
        }
        public TEntityViewModel BuscarPorId(Guid id, string[] includes = null)
        {
            return _mapper.Map<TEntityViewModel>(_repository.BuscarPorId(id, includes));
        } 
        
        public TEntityViewModel BuscarObjeto(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            return _mapper.Map<TEntityViewModel>(_repository.BuscarObjeto(expression, includes));
        }

        public void Notificar(string mensagem, bool state = false)
        {
            _notificador.Handle(new Notificacao(mensagem, state));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
