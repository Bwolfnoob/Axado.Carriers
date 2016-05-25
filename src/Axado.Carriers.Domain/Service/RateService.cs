using System;
using Axado.Carriers.Domain.Entities;
using Axado.Carriers.Domain.Interface.Repository;
using Axado.Carriers.Domain.Interface.Services;

namespace Axado.Carriers.Domain.Service
{
    public class RateService : BaseService<Rate>, IRateService
    {
        private readonly IRateRepository repository;

        public RateService(IRateRepository _repository)
            : base(_repository)
        {
            repository = _repository;
        }

        public Rate GetByUserCarrier(int _iduser, int _idCarrier)
        {
            return repository.GetByUserCarrier(_iduser , _idCarrier);
        }
    }
}
