using Microsoft.EntityFrameworkCore;
using SGIEscolar.Data.Context;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SGIEscolar.Data.Repository
{
    public abstract class BaseRepository<TEntity>: IRepository<TEntity>, IDisposable where TEntity : BaseEntity, new()
    {
        protected readonly SGIEscolarContext db;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(SGIEscolarContext DB)
        {
            this.db = DB;
            this.dbSet = this.db.Set<TEntity>();
        }

        public async Task<int> Adicionar(TEntity entity)
        {
            dbSet.Add(entity);
            return await SaveChangeAsync();
        }

        public async Task<int> Atualizar(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return await SaveChangeAsync();
        }

        public async Task<int> Deletar(TEntity entity)
        {
            dbSet.Remove(entity);
            return await SaveChangeAsync();
        }

        public async Task<int> DeletarPorId(Guid id, string[] includes = null)
        {
            var entity = await BuscarPorId(id, includes);
            dbSet.Remove(entity);
            return await SaveChangeAsync();
        }

        public async Task<IEnumerable<TEntity>> ListarTodos(string[] includes = null)
        {
            var result = dbSet.AsNoTracking();
            if (includes != null)
                foreach (var item in includes)
                    result = result.Include(item);

            return await result.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> BuscarLista(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            var result = dbSet.AsNoTracking();
            if (includes != null)
                foreach (var item in includes)
                    result = result.Include(item);

            return await result.Where(expression).ToListAsync();
        }

        public async Task<TEntity> BuscarPorId(Guid id, string[] includes = null)
        {
            var result = dbSet.AsNoTracking();
            if(includes != null)
                foreach(var item in includes)
                    result = result.Include(item);

            return await result.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> BuscarObjeto(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            var result = dbSet.AsNoTracking();
            if (includes != null)
                foreach (var item in includes)
                    result = result.Include(item);

            return await result.FirstOrDefaultAsync(expression);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
