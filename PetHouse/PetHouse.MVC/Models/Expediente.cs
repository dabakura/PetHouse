using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Expediente
    {
        public string Id { get; set; }
        public string Observaciones { get; set; }
        public int? Edad { get; set; }
        public int? Peso { get; set; }
        [DisplayName("Castración")]
        public bool Castracion { get; set; }
        [DisplayName("Fecha_Ingreso")]
        public DateTime Fecha_Ingreso { get; set; }
        [DisplayName("Fecha Fallecimiento")]
        public DateTime? Fecha_Fallecimiento { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    }
}
