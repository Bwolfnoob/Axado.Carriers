
using System;
using System.Text.RegularExpressions;

namespace Axado.Carriers.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        private User()
        {

        }

        public User(string _name, string _password, string _email, string _passwordConfirmation)
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                throw new Exception("O Nome não foi preenchido");
            }

            if (string.IsNullOrWhiteSpace(_password) || string.IsNullOrWhiteSpace(_passwordConfirmation))
            {
                throw new Exception("O Senha não foi preenchido");
            }

            if (_password != _passwordConfirmation)
            {
                throw new Exception("As senhas não são iguais");
            }

            if (IsNotValidEmail(_email))
            {
                throw new Exception("O Email informado esta inválido");
            }

            Name = _name;
            Password = _password;
            Email = _email;
        }

        private bool IsNotValidEmail(string email)
        {
            var regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            return !regex.IsMatch(email);
        }

        public bool IsLoggable(string _name, string _password)
        {
            return _name == Name && _password == Password;
        }

    }
}
