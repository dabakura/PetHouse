using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetHouse.MVC.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string ColorFondo { get; set; }

        [ScaffoldColumn(false)]
        public bool Estado { get; set; }
    }
}