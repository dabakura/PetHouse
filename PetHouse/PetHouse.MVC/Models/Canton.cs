using System;
using System.Collections.Generic;

namespace PetHouse.MVC.Models
{
    public class Canton
    {
        public int Id { get; set; }
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }
    
        public Provincia Provincia { get; set; }
    }
}
