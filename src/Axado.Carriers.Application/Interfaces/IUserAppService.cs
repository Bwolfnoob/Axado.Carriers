using Axado.Carriers.Application.ViewModels;
using Axado.Carriers.Domain.Entities;
using System;

namespace Axado.Carriers.Application.Interfaces
{
    public interface IUserAppService : IBaseAppService<User> , IDisposable
    {
        UserViewModel Login(LoginViewModel usuario);
    }
}
