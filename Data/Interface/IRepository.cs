using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SGIEscolar.Data.Interface
{
    public interface IRepository<TEntity>
    {
        Task<int> Adicionar(TEntity entity);
        Task<int> Atualizar(TEntity entity);
        Task<int> Deletar(TEntity entity);
        Task<IEnumerable<TEntity>> ListarTodos();
        Task<IEnumerable<TEntity>> BuscarLista(Expression<Func<TEntity, bool>> expression, string[] includes);
        Task<TEntity> BuscarPorId(Guid id, string[] includes);
        Task<TEntity> BuscarObjeto(Expression<Func<TEntity, bool>> expression, string[] includes);
    }
}
