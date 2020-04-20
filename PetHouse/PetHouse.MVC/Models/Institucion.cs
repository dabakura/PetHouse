using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Institucion
    {
        public int Id { get; set; }
        [DisplayName("Ced. Juridica")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Ced_Juridica { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Fax { get; set; }
        [DisplayName("Pag. Web")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Pag_Web { get; set; }
        [EmailAddress(ErrorMessage = "Debe ser una dirección Email valida")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        public int DireccionId { get; set; }
        [DisplayName("Región")]
        public Domicilio Domicilio { get; set; }
    }
}
