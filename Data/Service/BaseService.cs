using AutoMapper;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Models;
using SGIEscolar.Data.Notificacoes;
using SGIEscolar.ViewModels;
using System;
using System.Collections.Generic;

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
        public BaseService(IRepository<TEntity> repository, INotificador notificador, IMapper mapper)
        {
            this._repository = repository;
            this._notificador = notificador;
            this._mapper = mapper;
        }

        public void Adicionar(TEntity entity)
        {
            try
            {
                _repository.Adicionar(entity);
                _notificador.Handle(new Notificacao("Cadastrado com sucesso!", true));

            }catch(Exception ex)
            {
                _notificador.Handle(new Notificacao(ex.Message.ToString()));
            }
        }

        public void Atualizar(TEntity entity)
        {
            try
            {
                _repository.Atualizar(entity);
                _notificador.Handle(new Notificacao("Atualizado com sucesso!", true));

            }
            catch (Exception ex)
            {
                _notificador.Handle(new Notificacao(ex.Message.ToString()));
            }
        }

        public void Deletar(TEntity entity)
        {
            try
            {
                _repository.Deletar(entity);
                _notificador.Handle(new Notificacao("Deletado com sucesso!", true));

            }
            catch (Exception ex)
            {
                _notificador.Handle(new Notificacao(ex.Message.ToString()));
            }
        }

        public IEnumerable<TEntity> ListarTodos()
        {
            return _repository.ListarTodos();
        }

        public TEntity BuscarPorId(Guid id)
        {
            return _repository.BuscarPorId(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
