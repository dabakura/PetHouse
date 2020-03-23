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
		[DisplayName("Codigó")]
		public string Id { get; set; }
		public string Nombre { get; set; }
		[DisplayName("Descripción")]
		[DataType(DataType.Text)]
		public string Descripcion { get; set; }
		public string Tipo { get; set; }
		public decimal Precio { get; set; }
		[ScaffoldColumn(false)]
		public bool? Activo { get; set; }
	}
}