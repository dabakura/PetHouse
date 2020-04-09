using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Tratamiento
    {
        private string expedienteId;
        private int empleadoId;

        public Tratamiento()
        {
            Fecha = DateTime.Now;
            Expediente = new Expediente();
            Empleado = new Empleado();
            Medicamentos = new List<Medicamento>();
        }

        public int Id { get; set; }
        [DisplayName("Id Expediente")]
        public string ExpedienteId { get => expedienteId; set => Expediente.Id = expedienteId = value; }
        [DisplayName("Id Empleado")]
        public int EmpleadoId { get => empleadoId; set => Empleado.Identificacion = empleadoId = value; }
        [DisplayName("Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        [DataType(dataType: DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM'/'dd'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public Expediente Expediente { get; set; }
        public Empleado Empleado { get; set; }
        public List<Medicamento> Medicamentos { get; set; }
    }
}
