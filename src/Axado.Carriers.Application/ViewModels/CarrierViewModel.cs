using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Axado.Carriers.Application.ViewModels
{
    public class CarrierViewModel : EntityViewModel
    {

        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string Phone { get; set; }

        [Display(Name = "Website")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string WebSite { get; set; }

        [Display(Name = "Endereco")]
        public AddressViewModel Address { get; set; }

        public ICollection<RateViewModel> Ratings { get; set; }

        public double TotalRatings()
        {
            if (Ratings.Count == 0)
            {
                return 0;
            }
            else
            {
                return Ratings.Average(c => c.Point);
            }
        }
    }
}
