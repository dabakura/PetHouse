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
        [MaxLength(100, ErrorMessage = "No debe tener mas de {1} caracteres")]
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        [Required]
        [DisplayName("Precio en $")]
        [RegularExpression(@"^\d+\.?\d{0,2}$", ErrorMessage = "Formato permitido es #.##")]
        [Range(0, 199999.99, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
        public decimal Precio { get; set; }
    }
}
