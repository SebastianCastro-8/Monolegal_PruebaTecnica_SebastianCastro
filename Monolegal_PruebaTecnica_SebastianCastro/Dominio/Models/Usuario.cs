using System;

namespace Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models
{
    public class Usuario
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Ciudad { get; protected set; }
        public string Email { get; protected set; }

        public Usuario(string name, string email)
        {
            Name = name;
            Email = email;
        }

        internal Usuario Actualizar(string ciudad)
        {
            this.Ciudad= ciudad;
            return this;
        }
    }


}
