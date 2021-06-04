using Microsoft.EntityFrameworkCore;
using SGIEscolar.Data.Context;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public void Adicionar(TEntity entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Deletar(TEntity entity)
        {
            dbSet.Remove(entity);
            db.SaveChanges();
        }

        public IEnumerable<TEntity> ListarTodos()
        {
            return dbSet.ToListAsync().Result;
        }

        public IEnumerable<TEntity> BuscarLista(Expression<Func<TEntity, bool>> expression, string[] includes)
        {
            var result = dbSet.AsNoTracking();
            if (includes != null)
                foreach (var item in includes)
                    result = result.Include(item);

            return result.Where(expression).ToList();
        }

        public TEntity BuscarPorId(Guid id, string[] includes)
        {
            var result = dbSet.AsNoTracking();
            if(includes != null)
                foreach(var item in includes)
                    result = result.Include(item);

            return result.Where(x => x.Id == id).Single();
        }

        public TEntity BuscarObjeto(Expression<Func<TEntity, bool>> expression, string[] includes)
        {
            var result = dbSet.AsNoTracking();
            if (includes != null)
                foreach (var item in includes)
                    result = result.Include(item);

            return result.Where(expression).Single();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
