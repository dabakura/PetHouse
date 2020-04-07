using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHouse.MVC.Models
{
    public class PanelProcedimientoViewModel
    {
        public PanelProcedimientoViewModel(Expediente expediente)
        {
            Expediente = expediente;
            Carnet = new Carnet();
            Procedimiento = new Procedimiento();
            Tratamiento = new Tratamiento();
            Carnet.Expediente = expediente;
            Tratamiento.Expediente = expediente;
            Procedimiento.Expediente = expediente;
            Carnet.ExpedienteId = expediente.Id;
            Tratamiento.ExpedienteId = expediente.Id;
            Procedimiento.ExpedienteId = expediente.Id;
        }

        public Expediente Expediente { get; set; }
        public Carnet Carnet { get; set; }
        public Procedimiento Procedimiento { get; set; }
        public Tratamiento Tratamiento { get; set; }
    }
}