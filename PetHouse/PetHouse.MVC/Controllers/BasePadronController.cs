using Newtonsoft.Json;
using PetHouse.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PetHouse.MVC.Controllers
{
    public abstract class BasePadronController : BaseController
    {
        [HttpPost]
        public async Task<JsonResult> ListCantones(int ID_PROVINCIA)
        {
            var cantones = await DataCantones(ID_PROVINCIA);
            var CantonesSelect = new SelectList(cantones, "Id", "Nombre");
            return Json(CantonesSelect);
        }

        [HttpPost]
        public async Task<JsonResult> ListDistritos(int ID_CANTON)
        {
            var distritos = await DataDistritos(ID_CANTON);
            var DistritosSelect = new SelectList(distritos, "Id", "Nombre");
            return Json(DistritosSelect);
        }

        [HttpGet]
        public async Task<JsonResult> BuscarPersona(int ID_CEDULA)
        {
            var persona = await DataPersona(ID_CEDULA);
            return Json(persona, JsonRequestBehavior.AllowGet);
        }

        private async Task<Persona> DataPersona(int ID_CEDULA)
        {
            var result = await GetAsync("api/Persona/"+ ID_CEDULA);
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                Persona persona = JsonConvert.DeserializeObject<Persona>(resultdata);
                return persona;
            }
            return new Persona();
        }

        private async Task<List<Provincia>> DataProvincias()
        {
            var result = await GetAsync("api/Provincia");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Provincia> provincias = JsonConvert.DeserializeObject<List<Provincia>>(resultdata);
                return provincias;
            }
            return new List<Provincia>();
        }

        private async Task<List<Canton>> DataCantones(int ID_PROVINCIA)
        {
            var result = await GetAsync("api/Canton");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Canton> Cantones = JsonConvert.DeserializeObject<List<Canton>>(resultdata);
                return Cantones.FindAll(canton => canton.ProvinciaId == ID_PROVINCIA);
            }
            return new List<Canton>();
        }

        private async Task<List<Distrito>> DataDistritos(int ID_CANTON)
        {
            var result = await GetAsync("api/Distrito");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Distrito> Distritos = JsonConvert.DeserializeObject<List<Distrito>>(resultdata);
                return Distritos.FindAll(distrito => distrito.CantonId == ID_CANTON);
            }
            return new List<Distrito>();
        }

        protected async Task SetDomicilio(int? provincia_id = 0, int? canton_id = 0)
        {
            var Provincias = await DataProvincias();
            var Cantones = new List<Canton>();
            var Distritos = new List<Distrito>();
            if (Provincias.Count > 0)
            {
                if (provincia_id > 0)
                    Cantones = await DataCantones(provincia_id.Value);
                else
                    Cantones = await DataCantones(Provincias.ToArray()[0].Id);
            }
            if (Cantones.Count > 0)
            {
                if (canton_id > 0)
                    Distritos = await DataDistritos(canton_id.Value);
                else
                    Distritos = await DataDistritos(Cantones.ToArray()[0].Id);
            }
            ViewBag.Provincias = new SelectList(Provincias, "Id", "Nombre");
            ViewBag.Cantones = new SelectList(Cantones, "Id", "Nombre");
            ViewBag.Distritos = new SelectList(Distritos, "Id", "Nombre");
        }
    }
}
