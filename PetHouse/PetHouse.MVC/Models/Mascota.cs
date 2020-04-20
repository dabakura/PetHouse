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

        public Mascota()
        {
            Expediente = new Expediente();
        }

        [DisplayName("Identificación")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Identificacion { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Nombre { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Tipo { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Genero { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Raza { get; set; }
        [DisplayName("Fecha Nacimiento")]
        [DataType(dataType: DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM'/'dd'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha_Nacimiento { get; set; }
        [DisplayName("Id Expediente")]
        public string ExpedienteId { get => expedienteId; set => Expediente.Id = expedienteId = value; }
        public Expediente Expediente { get; set; }
    }
}
