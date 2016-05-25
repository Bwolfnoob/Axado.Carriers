using System.ComponentModel.DataAnnotations;

namespace Axado.Carriers.Application.ViewModels
{
    public class RateViewModel: EntityViewModel
    {
        public int IdCarrier { get; set; }

        public int Point { get; set; }

        public int IdUser { get; set; }
    }
}
