using System;

namespace Axado.Carriers.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public bool Active { get; set; }
    }
}
