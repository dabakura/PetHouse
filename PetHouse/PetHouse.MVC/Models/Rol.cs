using System;
using System.Collections.Generic;

namespace PetHouse.MVC.Models
{    
    public class Rol
    {
        public Rol()
        {
            IsAsignado = false;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsAsignado { get; set; }
    }
}
