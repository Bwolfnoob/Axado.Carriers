using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Axado.Carriers.Domain.Interface.Repository;

namespace Axado.Carriers.Infraestructure.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        internal DbContext Db;
        internal DbSet<TEntity> DbSet;

        public BaseRepository(DbContext context)
        {
            Db = context;

            DbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
            Db.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public virtual void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
       
        public virtual IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = DbSet.AsQueryable();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            query = query.Where(predicate);

            return query.AsNoTracking().AsEnumerable();
        }

        public virtual TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
