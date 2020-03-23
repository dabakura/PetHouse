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
        //[DataType(DataType.Text)]
        public string Descripcion { get; set; }
        [Required]
        [Range(0.01,199999.99,ErrorMessage = "La cantidad debe ser expresada en dolares")]
        public double Precio { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    }
}
