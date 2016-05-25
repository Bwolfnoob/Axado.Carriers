using Axado.Carriers.Application.Entities;
using Axado.Carriers.Application.ViewModels;
using Axado.Carriers.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Axado.Carriers.Application.Interfaces
{
    public interface ICarrierAppService : IBaseAppService<Carrier>, IDisposable
    {
    
    }
}
