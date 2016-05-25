using Axado.Carriers.Domain.Entities;

namespace Axado.Carriers.Domain.Interface.Services
{
    public interface IUserService : IBaseService<User>
    {
        User LoginVerify(string _name, string _password);
    }
}
