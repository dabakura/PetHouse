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
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Nombre { get; set; }
        [DisplayName("Primer Apellido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Primer_Apellido { get; set; }
        [DisplayName("Segundo Apellido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Segundo_Apellido { get; set; }
        [DisplayName("Fecha Nacimiento")]
        [DataType(dataType: DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM'/'dd'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Nacimiento { get; set; }
        [DisplayName("Teléfono")]
        public int Telefono { get; set; }
        [EmailAddress(ErrorMessage = "Debe ser una dirección Email valida")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        public int DomicilioId { get => _domicilioId; set => Domicilio.Id = _domicilioId = value; }
        public int PuestoID { get => _puestoID; set => Puesto.Id = _puestoID = value; }
        public int InstitucionId { get => _institucionId; set => Institucion.Id = _institucionId = value; }
        public string UserId { get; set; }
        [DisplayName("Región")]
        public Domicilio Domicilio { get; set; }
        [DisplayName("Institución")]
        public Institucion Institucion { get; set; }
        [DisplayName("Puesto")]
        public Puesto Puesto { get; set; }
    }
}
