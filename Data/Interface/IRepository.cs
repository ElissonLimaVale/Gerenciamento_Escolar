using SGIEscolar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SGIEscolar.Data.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<int> Adicionar(TEntity entity);
        Task<int> Atualizar(TEntity entity);
        Task<int> Deletar(TEntity entity);
        Task<int> DeletarPorId(Guid id, string[] includes = null);
        Task<IEnumerable<TEntity>> ListarTodos(string[] includes = null);
        Task<IEnumerable<TEntity>> BuscarLista(Expression<Func<TEntity, bool>> expression, string[] includes = null);
        Task<TEntity> BuscarPorId(Guid id, string[] includes = null);
        Task<TEntity> BuscarObjeto(Expression<Func<TEntity, bool>> expression, string[] includes = null);
        Task<int> SaveChangeAsync();
    }
}
