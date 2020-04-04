using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Expediente
    {
        public string Id { get; set; }
        [DataType(dataType: DataType.MultilineText)]
        public string Observaciones { get; set; }
        public int? Edad { get; set; }
        public int? Peso { get; set; }
        [DisplayName("Castración")]
        public bool Castracion { get; set; }
        [DisplayName("Fecha Ingreso")]
        [DataType(dataType: DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM'/'dd'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Ingreso { get; set; }
        [DisplayName("Fecha Fallecimiento")]
        [DataType(dataType: DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM'/'dd'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha_Fallecimiento { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
    }
}
