using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Puesto
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Nombre { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Descripcion { get; set; }
    }
}
