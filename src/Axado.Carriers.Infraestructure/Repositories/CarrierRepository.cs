using Axado.Carriers.Domain.Entities;
using Axado.Carriers.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Axado.Carriers.Infraestructure.Repositories
{
    public class CarrierRepository : BaseRepository<Carrier>, ICarrierRepository
    {
        public CarrierRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Carrier> GetAll()
        {
            return DbSet.Include(e => e.Address).Include(c => c.Ratings).ThenInclude(t=>t.User).AsNoTracking();
        }

        public override void Update(Carrier obj)
        {
            Db.Entry(obj.Address).State = EntityState.Modified;

            base.Update(obj);
        }

        public override Carrier GetById(int id)
        {
            return DbSet.Include(e => e.Address).Where(c=>c.Id == id).FirstOrDefault();
        }
    }
}
