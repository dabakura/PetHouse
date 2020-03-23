using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Tratamiento
    {
        public int Id { get; set; }
        public string ExpedienteId { get; set; }
        public int EmpleadoId { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime Fecha { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    }
}
