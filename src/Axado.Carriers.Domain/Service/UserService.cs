using Axado.Carriers.Domain.Entities;
using Axado.Carriers.Domain.Interface.Repository;
using Axado.Carriers.Domain.Interface.Services;
using System;
using System.Linq;

namespace Axado.Carriers.Domain.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository _repository)
            : base(_repository)
        {
            repository = _repository;
        }

        public User LoginVerify(string _name, string _password)
        {
            User user;
            try
            {
              user = repository.GetAll().Single(u => u.IsLoggable(_name , _password));
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Login incorreto ou usuário não está ativo!");
            }

            return user;
        }
    }
}
