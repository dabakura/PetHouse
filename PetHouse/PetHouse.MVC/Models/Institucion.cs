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
        public string Ced_Juridica { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Fax { get; set; }
        [DisplayName("Pag. Web")]
        public string Pag_Web { get; set; }
        public string Correo { get; set; }
        public int DireccionId { get; set; }
        [DisplayName("Región")]
        public Domicilio Domicilio { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    }
}
