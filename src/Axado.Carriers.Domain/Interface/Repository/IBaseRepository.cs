using System;
using System.Collections.Generic;

namespace Axado.Carriers.Domain.Interface.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        IEnumerable<TEntity> GetAll();
       TEntity GetById(int id);
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
