using System;
using System.Collections.Generic;

namespace PetHouse.MVC.Models
{
    public class Distrito
    {
        public int Id { get; set; }
        public int CantonId { get; set; }
        public string Nombre { get; set; }
    
        public Canton Canton { get; set; }
    }
}
