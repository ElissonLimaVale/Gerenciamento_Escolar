using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SGIEscolar.Data.Interface
{
    public interface IRepository<TEntity>
    {
        public void Adicionar(TEntity entity);
        public void Atualizar(TEntity entity);
        public void Deletar(TEntity entity);
        IEnumerable<TEntity> ListarTodos();
        IEnumerable<TEntity> BuscarLista(Expression<Func<TEntity, bool>> expression, string[] includes);
        TEntity BuscarPorId(Guid id, string[] includes);
        TEntity BuscarObjeto(Expression<Func<TEntity, bool>> expression, string[] includes);
    }
}
