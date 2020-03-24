using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Procedimiento
    {
        public int Id { get; set; }
        public string ExpedienteId { get; set; }
        public int EmpleadoId { get; set; }
        public string Nombre_Procedimiento { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    }
}
