using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Adoptante
    {
        public int Id { get; set; }
        [DisplayName("Identificación")]
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Primer Apellido")]
        public string Primer_Apellido { get; set; }
        [DisplayName("Segundo Apellido")]
        public string Segundo_Apellido { get; set; }
        [DisplayName("Fecha Nacimiento")]
        [DataType(dataType: DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Fecha_Nacimiento { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        [DisplayName("Id Domicilio")]
        public int DomicilioId { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    
        public Domicilio Domicilio { get; set; }
    }
}
