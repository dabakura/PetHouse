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
        [StringLength(100, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        [Required]
        [DisplayName("Precio en $")]
        [RegularExpression(@"^\d+\,?\d{0,2}$", ErrorMessage = "Formato permitido es #,##")]
        [Range(0, 199999.99, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
        public decimal Precio { get; set; }
    }
}
