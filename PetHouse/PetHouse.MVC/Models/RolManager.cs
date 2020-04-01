using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHouse.MVC.Models
{
    public class RolManager
    {
        private List<Rol> _roles;

        public RolManager(IEnumerable<Rol> roles)
        {
            _roles = roles.ToList();
        }

        public List<Rol> Roles => _roles;
        public RolManager SetAsignados(List<Rol> rolesAsignados)
        {
            _roles.ForEach(rol =>
            {
                rol.IsAsignado = rolesAsignados.Exists(rolasignado => rolasignado.Name.Equals(rol.Name));
            });
            return this;
        }

        public RolManager SetFilter(Func<Rol, bool> predicate)
        {
            _roles = Roles.Where(predicate).ToList();
            return this;
        }
    }
}