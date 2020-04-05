using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Adopcion
    {
        public int Id { get; set; }
        public int InstitucionId { get; set; }
        public int AdoptanteId { get; set; }
        public DateTime Fecha_Adopcion { get; set; }
        public Adoptante Adoptante { get; set; }
        public Institucion Institucion { get; set; }
        public Mascota Mascota { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
