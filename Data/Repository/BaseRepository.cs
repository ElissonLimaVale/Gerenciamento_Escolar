using Microsoft.EntityFrameworkCore;
using SGIEscolar.Data.Context;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Models;
using System;
using System.Collections;
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
            await dbSet.AddAsync(entity);
            return await SaveChanges();
        }

        public async Task<int> Atualizar(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return await SaveChanges();
        }

        public async Task<int> Deletar(TEntity entity)
        {
            dbSet.Remove(entity);
            return await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> ListarTodos()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> BuscarLista(Expression<Func<TEntity, bool>> expression, string[] includes)
        {
            var result = dbSet.AsNoTracking();
            if (includes != null)
                foreach (var item in includes)
                    result = result.Include(item);

            return await result.Where(expression).ToListAsync();
        }

        public async Task<TEntity> BuscarPorId(Guid id, string[] includes)
        {
            var result = dbSet.AsNoTracking();
            if(includes != null)
                foreach(var item in includes)
                    result = result.Include(item);

            return await result.Where(x => x.Id == id).SingleAsync();
        }

        public async Task<TEntity> BuscarObjeto(Expression<Func<TEntity, bool>> expression, string[] includes)
        {
            var result = dbSet.AsNoTracking();
            if (includes != null)
                foreach (var item in includes)
                    result = result.Include(item);

            return await result.Where(expression).SingleAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await db.SaveChangesAsync();
        }
        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
