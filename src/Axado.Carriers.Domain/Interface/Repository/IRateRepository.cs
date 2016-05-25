using Axado.Carriers.Domain.Entities;

namespace Axado.Carriers.Domain.Interface.Repository
{
    public interface IRateRepository : IBaseRepository<Rate>
    {
        Rate GetByUserCarrier(int _iduser , int idCarrier);
    }
}
