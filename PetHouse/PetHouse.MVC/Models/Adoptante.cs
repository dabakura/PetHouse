using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Adoptante
    {
        public int Id { get; set; }
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public int DomicilioId { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    
        public Domicilio Domicilio { get; set; }
    }
}
