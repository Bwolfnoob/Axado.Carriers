using System;

namespace Axado.Carriers.Domain.Entities
{
    public class Rate : Entity
    {
        public virtual Carrier Carrier { get; private set; }
        public virtual User User { get; private set; }
        public int Point { get; set; }

        private Rate()
        { }

        public Rate(int _rate, User _user, Carrier _carrier)
        {
            if (_user == null)
            {
                throw new Exception("Usuário não informado");
            }

            if (_carrier == null)
            {
                throw new Exception("Transportadora não informada");
            }

            Point = _rate;
            User = _user;
            Carrier = _carrier;
        }
    }
}
