using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Vacuna
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "No debe tener mas de 100 caracteres")]
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        [Required]
        [DisplayName("Precio en $")]
        [RegularExpression(@"^\d+\,\d{0,2}$",ErrorMessage = "Formato permitido es 10,50")]
        [Range(0, 199999.99, ErrorMessage = "La cantidad debe ser expresada en dolares")]
        public decimal Precio { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    }
}
