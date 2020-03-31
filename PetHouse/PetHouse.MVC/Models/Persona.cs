using System;
using System.Collections.Generic;

namespace PetHouse.MVC.Models
{
    public class Persona
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public int Sexo { get; set; }
        public int? ProvinciaId { get; set; }
        public int? CantonId { get; set; }
        public int? DistritoId { get; set; }
    
        public string Canton_Nombre { get; set; }
        public string Distrito_Nombre { get; set; }
        public string Provincia_Nombre { get; set; }
    }
}