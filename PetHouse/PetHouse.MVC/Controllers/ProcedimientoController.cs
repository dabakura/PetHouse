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
    public class ProcedimientoController : BaseController
    {
        // POST: Procedimiento/{id}
        [HttpPost]
        public async Task<JsonResult> Index(string id)
        {
            var result = await GetAsync("api/Procedimiento/ByExpediente/" + id);
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Procedimiento> procedimientos = JsonConvert.DeserializeObject<List<Procedimiento>>(resultdata);
                return Json(procedimientos);
            }

            var Error = await ErrorAsync("Procedimiento", "Index", "Error al cargar los Procedimientos", 500);
            return new JsonHttpStatusResult(new { Error }, HttpStatusCode.BadRequest);
        }

        // GET: Procedimiento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                ViewData["Error"] = await ErrorAsync("Procedimiento", "Details", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Procedimiento/" + id.Value);
            Procedimiento procedimiento = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                procedimiento = JsonConvert.DeserializeObject<Procedimiento>(resultdata);
            }
            if (procedimiento == null)
            {
                ViewData["Error"] = await ErrorAsync("Procedimiento", "Details", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(procedimiento);
        }

        // POST: Procedimiento/Create
        [HttpPost]
        public async Task<JsonResult> Create([Bind(Include = "Id,ExpedienteId,EmpleadoId,Nombre_Procedimiento,Descripcion,Empleado,Expediente")] Procedimiento procedimiento)
        {
            ModelCustom(ModelState);
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Procedimiento", procedimiento);
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    procedimiento = JsonConvert.DeserializeObject<Procedimiento>(resultdata);
                    return Json(procedimiento);
                }
            }
            var Error = await ErrorAsync("Procedimiento", "Create", "Error insertar el procedimiento compruebe los campos", 400);
            return new JsonHttpStatusResult(new { Error }, HttpStatusCode.BadRequest);
        }


        private void ModelCustom(ModelStateDictionary modelstage)
        {
            var keys = modelstage.Keys.ToArray();
            for (int i = 5; i < keys.Length; i++)
                modelstage.Remove(keys[i]);
        }

        // GET: Procedimiento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                ViewData["Error"] = await ErrorAsync("Procedimiento", "Edit", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Procedimiento/" + id.Value);
            Procedimiento procedimiento = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                procedimiento = JsonConvert.DeserializeObject<Procedimiento>(resultdata);
            }
            if (procedimiento == null)
            {
                ViewData["Error"] = await ErrorAsync("Procedimiento", "Edit", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(procedimiento);
        }

        // POST: Procedimiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ExpedienteId,EmpleadoId,Nombre_Procedimiento,Descripcion,Empleado,Expediente")] Procedimiento procedimiento)
        {
            ModelCustom(ModelState);
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Procedimiento/" + procedimiento.Id, procedimiento);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index", "HomeProcedimiento");
            }
            ViewData["Error"] = await ErrorAsync("Procedimiento", "Edit", "Error actualizar procedimiento compruebe los campos", 400);
            return View(procedimiento);
        }

        // GET: Procedimiento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                ViewData["Error"] = await ErrorAsync("Procedimiento", "Delete", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Procedimiento/" + id.Value);
            Procedimiento procedimiento = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                procedimiento = JsonConvert.DeserializeObject<Procedimiento>(resultdata);
            }
            if (procedimiento == null)
            {
                ViewData["Error"] = await ErrorAsync("Procedimiento", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(procedimiento);
        }

        // POST: Procedimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await DeleteAsync("api/Procedimiento/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index","HomeProcedimiento");
            ViewData["Error"] = await ErrorAsync("Procedimiento", "DeleteConfirmed", "Error eliminar procedimiento compruebe los campos", 400);
            return HttpNotFound();
        }
    }
}
