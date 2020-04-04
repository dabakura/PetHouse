using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHouse.MVC.Models
{
    public class ExpedienteMascotaModel
    {
        private Expediente expediente;

        public ExpedienteMascotaModel()
        {
            expediente = new Expediente();
            Mascota = new Mascota { AdopcionId = null, Adopcion = null, Expediente = expediente };
        }
        public Expediente Expediente { get => expediente; set { expediente = value; Mascota.ExpedienteId = expediente.Id; } }
        public Mascota Mascota { get; set; }
    }
}