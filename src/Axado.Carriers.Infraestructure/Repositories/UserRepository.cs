using Axado.Carriers.Domain.Entities;
using Axado.Carriers.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Axado.Carriers.Infraestructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
        public override User GetById(int id)
        {
            return DbSet.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
