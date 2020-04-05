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
        [RegularExpression(@"^\d+\.?\d{0,2}$", ErrorMessage = "Formato permitido es #.##")]
        [Range(0, 199.99, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
        public decimal? Edad { get; set; }
        [RegularExpression(@"^\d+\.?\d{0,2}$", ErrorMessage = "Formato permitido es #.##")]
        [Range(0, 199999.99, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
        public decimal? Peso { get; set; }
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
    }
}
