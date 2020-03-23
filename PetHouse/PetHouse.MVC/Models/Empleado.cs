using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public System.DateTime Fecha_Nacimiento { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public int DomicilioId { get; set; }
        public int PuestoID { get; set; }
        public int InstitucionId { get; set; }
        public string UserId { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    
        public Domicilio Domicilio { get; set; }
        public Institucion Institucion { get; set; }
        public Puesto Puesto { get; set; }
    }
}
