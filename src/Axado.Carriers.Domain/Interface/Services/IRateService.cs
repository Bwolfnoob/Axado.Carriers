using Axado.Carriers.Domain.Entities;

namespace Axado.Carriers.Domain.Interface.Services
{
    public interface IRateService : IBaseService<Rate>
    {
        Rate GetByUserCarrier(int _iduser, int _idCarrier);
    }
}
