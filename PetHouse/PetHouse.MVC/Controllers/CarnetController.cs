using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PetHouse.MVC.Models;

namespace PetHouse.MVC.Controllers
{
    [CustomAuthorize]
    public class CarnetController : BaseController
    {
        // HttpPost: Carnet/Index/5
        [HttpPost]
        public async Task<JsonResult> Index(string id)
        {
            var result = await GetAsync("api/Carnet/" + id);
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Carnet> carnets = JsonConvert.DeserializeObject<List<Carnet>>(resultdata);
                return Json(carnets);
            }

            var Error = await ErrorAsync("Vacuna", "Create", "Error al cargar las vacunas", 500);
            return new JsonHttpStatusResult(new { Error }, HttpStatusCode.BadRequest);
        }

        // POST: Vacuna/Create
        [HttpPost]
        public async Task<JsonResult> Create([Bind(Include = "ExpedienteId,VacunaId,Fecha_Vacunacion,Expediente,Vacuna")] Carnet carnet)
        {
            ModelCustom(ModelState);
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Carnet", carnet);
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    carnet = JsonConvert.DeserializeObject<Carnet>(resultdata);
                    return Json(carnet);
                }
            }
            var Error = await ErrorAsync("Vacuna", "Create", "Error insertar vacuna compruebe los campos", 400);
            return new JsonHttpStatusResult(new { Error }, HttpStatusCode.BadRequest);
        }

        private void ModelCustom(ModelStateDictionary modelstage)
        {
            var keys = modelstage.Keys.ToArray();
            for (int i = 3; i < keys.Length; i++)
                modelstage.Remove(keys[i]);
        }

        // POST: Vacuna/Delete
        [HttpPost]
        public async Task<JsonResult> Delete([Bind(Include = "ExpedienteId,VacunaId")] Carnet carnet)
        {
            var result = await DeleteAsync("api/Carnet?idExpediente=" + carnet.ExpedienteId + "&idVacuna=" + carnet.VacunaId);
            if (result.IsSuccessStatusCode)
                return Json(carnet);
            var Error = await ErrorAsync("Vacuna", "Create", "Error eliminar vacuna compruebe los campos", 400);
            return new JsonHttpStatusResult(new { Error }, HttpStatusCode.BadRequest);
        }
    }
}
