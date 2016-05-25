using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Axado.Carriers.Domain.Entities
{
    public class Carrier : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string WebSite { get; private set; }
        public Address Address { get; private set; }
        public virtual ICollection<Rate> Ratings { get; set; }

        private Carrier()
        { }

        public Carrier(string _name, string _email, string _phone, Address _address, string _website = "")
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                throw new Exception("O Nome não foi preenchido");
            }
            _phone = _phone.Replace(" ", string.Empty);
            if (IsNotValidPhone(_phone))
            {
                throw new Exception("O Telefone informado esta inválido");
            }

            if (IsNotValidEmail(_email))
            {
                throw new Exception("O Email informado esta inválido");
            }

            if (_address == null)
            {
                throw new Exception("O Endereco não foi preenchido");
            }

            Email = _email;
            Name = _name;
            Phone = _phone;
            Address = _address;
            WebSite = _website;
        }

        private bool IsNotValidPhone(string phone)
        {
            var regex = new Regex(@"^\(\d{2}\)\d{4}-\d{4}$");
            return !regex.IsMatch(phone);
        }

        private bool IsNotValidEmail(string email)
        {
            var regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            return !regex.IsMatch(email);
        }
    }
}
