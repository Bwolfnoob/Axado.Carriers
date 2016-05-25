using Axado.Carriers.Domain.Entities;
using Axado.Carriers.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Axado.Carriers.Infraestructure.Repositories
{
    public class RateRepository : BaseRepository<Rate>, IRateRepository
    {
        public RateRepository(DbContext context) : base(context)
        {
        }

        public override Rate GetById(int id)
        {
            return DbSet.Where(c => c.Id == id).AsNoTracking().FirstOrDefault();
        }

        public override void Add(Rate obj)
        {
            Db.Entry(obj.Carrier).State = EntityState.Unchanged;
            Db.Entry(obj.User).State = EntityState.Unchanged;
            DbSet.Add(obj);
            Db.SaveChanges();
        }

        public Rate GetByUserCarrier(int _iduser, int idCarrier)
        {
            return DbSet.Include(c=>c.User).Include(c=>c.Carrier).Where(c => c.User.Id == _iduser && c.Carrier.Id == idCarrier).AsNoTracking().FirstOrDefault();
        }
    }
}
