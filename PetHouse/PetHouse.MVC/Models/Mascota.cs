using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Mascota
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Genero { get; set; }
        public string Raza { get; set; }
        public Nullable<System.DateTime> Fecha_Nacimiento { get; set; }
        public Nullable<int> AdopcionId { get; set; }
        public string ExpedienteId { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    
        public Adopcion Adopcion { get; set; }
        public Expediente Expediente { get; set; }
    }
}
