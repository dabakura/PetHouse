using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Adoptante
    {
        public int Id { get; set; }
        [DisplayName("Identificación")]
        public int Identificacion { get; set; }
        [StringLength(50,MinimumLength =3,ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
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
        [DisplayName("Id Domicilio")]
        public int DomicilioId { get; set; }
        [DisplayName("Región")]
        public Domicilio Domicilio { get; set; }
        [DisplayName("Mascotas")]
        public IEnumerable<Mascota> Mascotas { get; set; }
    }
}
