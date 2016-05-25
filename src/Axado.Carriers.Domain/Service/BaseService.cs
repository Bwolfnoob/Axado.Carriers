using Axado.Carriers.Domain.Interface.Repository;
using Axado.Carriers.Domain.Interface.Services;
using System.Collections.Generic;

namespace Axado.Carriers.Domain.Service
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> _repository)
        {
            repository = _repository;
        }

        public void Add(TEntity obj)
        {
            using (var rep = repository)
            {
                rep.Add(obj);
            }
        }

        public void Update(TEntity obj)
        {

            using (var rep = repository)
            {
                repository.Update(obj);
            }
        }

        public void Remove(TEntity obj)
        {
            using (var rep = repository)
            {
                repository.Remove(obj);
            }
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

    }
}
