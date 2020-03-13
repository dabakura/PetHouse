using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHouse.API.Models
{
    public static class IndicatorState
    {
        public static Indicator IndicatorRegion = new Indicator();
        public static Indicator IndicatorPersonas = new Indicator();
    }

    public class Indicator
    {
        private string pNota;
        private double pAvanceTotal, pAvanceReal;
        public Indicator()
        {
            PNota = "Fila - ";
        }
        public string PNota { get => pNota; set => pNota = value; }
        public double PAvanceTotal { get => pAvanceTotal; set => pAvanceTotal = value; }
        public double PAvanceReal { get => pAvanceReal; set => pAvanceReal = value; }
        public int Porcentaje { get => Convert.ToInt32(((PAvanceTotal==0) ? 0 : (PAvanceReal / PAvanceTotal)) * 100); }
        public bool Completo { get => PAvanceTotal == 0; }
    }
}