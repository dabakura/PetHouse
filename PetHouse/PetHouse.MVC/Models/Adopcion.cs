using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Adopcion
    {
        public int Id { get; set; }
        [DisplayName("Id Institución")]
        public int InstitucionId { get; set; }
        [DisplayName("Id Adoptante")]
        public int AdoptanteId { get; set; }
        [DisplayName("Fecha Adopcion")]
        [DataType(dataType: DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM'/'dd'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Adopcion { get; set; }
        public Adoptante Adoptante { get; set; }
        [DisplayName("Institución")]
        public Institucion Institucion { get; set; }
        public Mascota Mascota { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { DateFormatString = "MM/dd/yyyy" };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
