using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Mascota
    {
        [DisplayName("Identificación")]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Genero { get; set; }
        public string Raza { get; set; }
        [DisplayName("Fecha Nacimiento")]
        public DateTime? Fecha_Nacimiento { get; set; }
        [DisplayName("Id Adopción")]
        public int? AdopcionId { get; set; }
        [DisplayName("Id Expediente")]
        public string ExpedienteId { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    
        public Adopcion Adopcion { get; set; }
        public Expediente Expediente { get; set; }
    }
}
