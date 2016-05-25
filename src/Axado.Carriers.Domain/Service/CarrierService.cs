using System;
using System.Collections.Generic;
using Axado.Carriers.Domain.Entities;
using Axado.Carriers.Domain.Interface.Repository;
using Axado.Carriers.Domain.Interface.Services;
using System.Linq;

namespace Axado.Carriers.Domain.Service
{
    public class CarrierService : BaseService<Carrier>, ICarrierService
    {
        private readonly ICarrierRepository repository;

        public CarrierService(ICarrierRepository _repository)
            : base(_repository)
        {
            repository = _repository;
        }
    }
}
