using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Empleado
    {
        private int _domicilioId;
        private int _puestoID;
        private int _institucionId;

        public Empleado()
        {
            Domicilio = new Domicilio();
            Institucion = new Institucion();
            Puesto = new Puesto();
        }

        public int Id { get; set; }
        [DisplayName("Identificación")]
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Primer Apellido")]
        public string Primer_Apellido { get; set; }
        [DisplayName("Segundo Apellido")]
        public string Segundo_Apellido { get; set; }
        [DisplayName("Fecha Nacimiento")]
        [DataType(dataType: DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Nacimiento { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public int DomicilioId { get => _domicilioId; set => Domicilio.Id = _domicilioId = value; }
        public int PuestoID { get => _puestoID; set => Puesto.Id = _puestoID = value; }
        public int InstitucionId { get => _institucionId; set => Institucion.Id = _institucionId = value; }
        public string UserId { get; set; }
        [ScaffoldColumn(false)]
        public bool? Activo { get; set; }
        [DisplayName("Región")]
        public Domicilio Domicilio { get; set; }
        [DisplayName("Institución")]
        public Institucion Institucion { get; set; }
        [DisplayName("Puesto")]
        public Puesto Puesto { get; set; }
    }
}
