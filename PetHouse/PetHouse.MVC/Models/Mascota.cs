using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Mascota
    {
        private string expedienteId;
        private int? adopcionId;

        public Mascota()
        {
            Adopcion = new Adopcion();
            Expediente = new Expediente();
        }

        [DisplayName("Identificación")]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Genero { get; set; }
        public string Raza { get; set; }
        [DisplayName("Fecha Nacimiento")]
        [DataType(dataType: DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha_Nacimiento { get; set; }
        [DisplayName("Id Adopción")]
        public int? AdopcionId { 
            get => adopcionId; 
            set {
                if (value.HasValue)
                {
                    adopcionId = value;
                    Adopcion.Id = value.Value;
                } else
                {
                    Adopcion = null;
                    adopcionId = value;
                }
            } 
        }
        [DisplayName("Id Expediente")]
        public string ExpedienteId { get => expedienteId; set => Expediente.Id = expedienteId = value; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
        public Adopcion Adopcion { get; set; }
        public Expediente Expediente { get; set; }
    }
}
