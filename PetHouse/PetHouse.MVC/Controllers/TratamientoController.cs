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
    public class TratamientoController : BaseController
    {
        // POST: Tratamiento/{id}
        [HttpPost]
        public async Task<JsonResult> Index(string id)
        {
            var result = await GetAsync("api/Tratamiento/GetAll/" + id);
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Tratamiento> tratamientos = JsonConvert.DeserializeObject<List<Tratamiento>>(resultdata);
                return Json(tratamientos);
            }

            var Error = await ErrorAsync("Tratamiento", "Index", "Error al cargar los Tratamientos", 500);
            return new JsonHttpStatusResult(new { Error }, HttpStatusCode.BadRequest);
        }

        // GET: Tratamiento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Tratamiento", "Details", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Tratamiento/" + id.Value);
            Tratamiento tratamiento = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                tratamiento = JsonConvert.DeserializeObject<Tratamiento>(resultdata);
            }
            if (tratamiento == null)
            {
                ViewData["Error"] = await ErrorAsync("Tratamiento", "Details", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // POST: Tratamiento/Create
        [HttpPost]
        public async Task<JsonResult> Create([Bind(Include = "Id,ExpedienteId,EmpleadoId,Descripcion,Empleado,Expediente,Medicamentos")] Tratamiento tratamiento)
        {
            ModelCustom(ModelState);
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Tratamiento", tratamiento);
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    tratamiento = JsonConvert.DeserializeObject<Tratamiento>(resultdata);
                    return Json(tratamiento);
                }
            }
            var Error = await ErrorAsync("Tratamiento", "Create", "Error insertar el tratamiento compruebe los campos", 400);
            return new JsonHttpStatusResult(new { Error }, HttpStatusCode.BadRequest);
        }

        private void ModelCustom(ModelStateDictionary modelstage)
        {
            var keys = modelstage.Keys.ToArray();
            for (int i = 4; i < keys.Length; i++)
                modelstage.Remove(keys[i]);
        }

        // GET: Tratamiento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Tratamiento", "Edit", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Tratamiento/" + id.Value);
            Tratamiento tratamiento = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                tratamiento = JsonConvert.DeserializeObject<Tratamiento>(resultdata);
            }
            if (tratamiento == null)
            {
                ViewData["Error"] = await ErrorAsync("Tratamiento", "Edit", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // POST: Tratamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ExpedienteId,EmpleadoId,Descripcion,Fecha,Expediente,Empleado")] Tratamiento tratamiento)
        {
            ModelCustom(ModelState);
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Tratamiento/" + tratamiento.Id, tratamiento);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index","HomeProcedimiento");
            }
            ViewData["Error"] = await ErrorAsync("Tratamiento", "Edit", "Error actualizar tratamiento compruebe los campos", 400);
            return View(tratamiento);
        }

        // GET: Tratamiento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Tratamiento", "Delete", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Tratamiento/" + id.Value);
            Tratamiento tratamiento = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                tratamiento = JsonConvert.DeserializeObject<Tratamiento>(resultdata);
            }
            if (tratamiento == null)
            {
                ViewData["Error"] = await ErrorAsync("Tratamiento", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // POST: Tratamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await DeleteAsync("api/Tratamiento/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index", "HomeProcedimiento");
            ViewData["Error"] = await ErrorAsync("Tratamiento", "DeleteConfirmed", "Error eliminar tratamiento compruebe los campos", 400);
            return HttpNotFound();
        }
    }
}
