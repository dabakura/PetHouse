using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Procedimiento
    {
        private string expedienteId;
        private int empleadoId;

        public Procedimiento()
        {
            Expediente = new Expediente();
            Empleado = new Empleado();
        }

        public int Id { get; set; }
        [DisplayName("Id Expediente")]
        public string ExpedienteId { get => expedienteId; set => Expediente.Id = expedienteId = value; }
        [DisplayName("Id Empleado")]
        public int EmpleadoId { get => empleadoId; set => Empleado.Identificacion = empleadoId = value; }
        [DisplayName("Procedimiento")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Nombre_Procedimiento { get; set; }
        [DisplayName("Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        public Expediente Expediente { get; set; }
        public Empleado Empleado { get; set; }
    }
}
