using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Institucion
    {
        public int Id { get; set; }
        public string Ced_Juridica { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Fax { get; set; }
        public string Pag_Web { get; set; }
        public string Correo { get; set; }
        public int DireccionId { get; set; }
        public Domicilio Domicilio { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    }
}
