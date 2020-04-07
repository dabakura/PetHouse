using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Carnet
    {
        private int vacunaId;
        private string expedienteId;

        public Carnet()
        {
            Expediente = new Expediente();
            Vacuna = new Vacuna();
        }

        [DisplayName("Id Expediente")]
        public string ExpedienteId { get => expedienteId; set => Expediente.Id = expedienteId = value; }
        [DisplayName("Id Vacuna")]
        public int VacunaId { get => vacunaId; set => Vacuna.Id = vacunaId = value; }
        [DisplayName("Fecha Vacunación")]
        [DataType(dataType: DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM'/'dd'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Vacunacion { get; set; }
        public Expediente Expediente { get; set; }
        public Vacuna Vacuna { get; set; }
    }
}
