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
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public Expediente Expediente { get; set; }
    }
}
