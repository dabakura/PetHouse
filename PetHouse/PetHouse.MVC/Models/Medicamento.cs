using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetHouse.MVC.Models
{
    public class Medicamento
    {
		[DisplayName("Codigo")]
		[MaxLength(100, ErrorMessage = "No debe tener mas de {1} caracteres")]
		public string Id { get; set; }
		[Required]
		[MaxLength(50,ErrorMessage = "No debe tener mas de {1} caracteres")]
		public string Nombre { get; set; }
		[DisplayName("Descripción")]
		[DataType(DataType.MultilineText)]
		public string Descripcion { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage = "No debe tener mas de {1} caracteres")]
		public string Tipo { get; set; }
		[Required]
		[DisplayName("Precio en $")]
		[RegularExpression(@"^\d+\,\d{0,2}$", ErrorMessage = "Formato permitido es 10,50")]
		[Range(0, 199999.99, ErrorMessage = "El {0} debe estar entre {1} y {2}")]

		public decimal Precio { get; set; }
		[ScaffoldColumn(false)]
		public bool? Activo { get; set; }
	}
}