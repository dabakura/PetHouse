using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHouse.MVC.Models
{
    public class Bitacora
    {
		public Bitacora()
		{
		}

		public Bitacora(string controlador, string metodo, string mensaje, string usuario, int? tipo)
		{
			Controlador = controlador;
			Metodo = metodo;
			Mensaje = mensaje;
			Usuario = usuario;
			Tipo = tipo;
		}

		public int IdBitacora { get; set; }
		public string Controlador { get; set; }
		public string Metodo { get; set; }
		public string Mensaje { get; set; }
		public string Usuario { get; set; }
		public DateTime Fecha => DateTime.Now;
		public int? Tipo { get; set; }
	}
}