using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Axado.Carriers.Application.ViewModels
{
    public class UserViewModel: EntityViewModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Email { get; set; }
    }
}
