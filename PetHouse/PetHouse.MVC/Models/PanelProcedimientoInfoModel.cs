using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHouse.MVC.Models
{
    public class PanelProcedimientoInfoModel
    {
        public Expediente Expediente { get; set; }
        public List<Carnet> Carnets { get; set; }
    }
}