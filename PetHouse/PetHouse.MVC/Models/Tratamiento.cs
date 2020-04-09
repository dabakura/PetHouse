using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Tratamiento
    {
        private DateTime fecha;
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
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Expediente Expediente { get; set; }
        public Empleado Empleado { get; set; }
        public List<Medicamento> Medicamentos { get; set; }
    }
}
