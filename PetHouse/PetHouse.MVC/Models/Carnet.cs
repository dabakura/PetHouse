using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Carnet
    {
        public string ExpedienteId { get; set; }
        public int VacunaId { get; set; }
        public DateTime Fecha_Vacunacion { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
        
        public Vacuna Vacuna { get; set; }
    }
}
