using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Puesto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    }
}
