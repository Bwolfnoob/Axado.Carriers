using System;

namespace Axado.Carriers.Application.ViewModels
{
    public abstract class EntityViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public bool Active { get; set; }
    }
}
