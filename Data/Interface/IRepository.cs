using System;
using System.Collections.Generic;

namespace SGIEscolar.Data.Interface
{
    public interface IRepository<TEntity>
    {
        public void Adicionar(TEntity entity);
        public void Atualizar(TEntity entity);
        public void Deletar(TEntity entity);
        IEnumerable<TEntity> ListarTodos();
        TEntity BuscarPorId(Guid id);
    }
}
