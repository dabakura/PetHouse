using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Domicilio
    {
        public int Id { get; set; }
        public int ProvinciaId { get; set; }
        public int CantonId { get; set; }
        public int DistritoId { get; set; }
        public string Direccion { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    
        public Distrito Distrito { get; set; }
    }
}
