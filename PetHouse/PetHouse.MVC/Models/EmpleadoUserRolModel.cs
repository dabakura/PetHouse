using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHouse.MVC.Models
{
    public class EmpleadoUserRolModel
    {
        public EmpleadoUserRolModel()
        {
            Empleado = new Empleado();
            User = new RegisterUser();
        }

        public Empleado Empleado { get; set; }
        public RegisterUser User { get; set; }
        public int? RolId { get; set; }
    }
}