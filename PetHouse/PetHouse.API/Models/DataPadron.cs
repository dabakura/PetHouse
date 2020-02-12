using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHouse.API.Models
{
    public class DataPadron
    {

        private int pCantidadTotal;
        private int pFila;
        private List<string> lineas;
        private string[] campos;

        public DataPadron()
        {
            pCantidadTotal = 0;
            pCantidadTotal = 0;
            lineas = new List<string>();
        }

        public int PCantidadTotal { get => pCantidadTotal; set => pCantidadTotal = value; }
        public int PFila { get => pFila; set => pFila = value; }
        public List<string> Lineas { get => lineas; set => lineas = value; }
        public string[] Campos { get => campos; set => campos = value; }
    }
}