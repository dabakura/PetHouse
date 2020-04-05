using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PetHouse.MVC.Models
{
    public class Distrito
    {
        public int Id { get; set; }
        public int CantonId { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Cantón")]
        public Canton Canton { get; set; }
    }
}
