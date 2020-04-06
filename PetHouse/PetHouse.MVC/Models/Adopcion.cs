using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Adopcion
    {
        private int institucionId;
        private int adoptanteId;
        private string mascotaId;

        public Adopcion()
        {
            Adoptante = new Adoptante();
            Institucion = new Institucion();
            Mascota = new Mascota();
        }

        public int Id { get; set; }
        [DisplayName("Id Institución")]
        public int InstitucionId { get => institucionId; set => Institucion.Id = institucionId = value; }
        [DisplayName("Id Adoptante")]
        public int AdoptanteId { get => adoptanteId; set => Adoptante.Identificacion = adoptanteId = value; }
        [DisplayName("Id Mascota")]
        public string MascotaId { get => mascotaId; set => Mascota.Identificacion = mascotaId = value; }
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
