using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Expediente
    {
        public string Id { get; set; }
        public string Observaciones { get; set; }
        public Nullable<int> Edad { get; set; }
        public Nullable<int> Peso { get; set; }
        public bool Castracion { get; set; }
        public System.DateTime Fecha_Ingreso { get; set; }
        public Nullable<System.DateTime> Fecha_Fallecimiento { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    }
}
