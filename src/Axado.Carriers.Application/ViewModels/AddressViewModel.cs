using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Axado.Carriers.Application.ViewModels
{
    public class AddressViewModel: EntityViewModel
    {
        [Display(Name = "Rua")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string Street { get; set; }

        [Display(Name = "Bairro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string District { get; set; }

        [Display(Name = "Cidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obrigatório")]
        public string City { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
      
        public string Obs { get; set; }
    }
}
