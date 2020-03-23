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
		[MaxLength(100, ErrorMessage = "No debe tener mas de 100 caracteres")]
		public string Id { get; set; }
		[Required]
		[MaxLength(50,ErrorMessage ="No debe tener mas de 50 caracteres")]
		public string Nombre { get; set; }
		[DisplayName("Descripción")]
		
		public string Descripcion { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage = "No debe tener mas de 50 caracteres")]
		public string Tipo { get; set; }
		[Required]
		
		[Range(0.01, 199999.99, ErrorMessage = "La cantidad debe ser expresada en dolares")]

		public double Precio { get; set; }
		[ScaffoldColumn(false)]
		public bool? Activo { get; set; }
	}
}