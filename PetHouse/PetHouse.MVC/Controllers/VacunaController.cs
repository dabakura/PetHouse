using Newtonsoft.Json;
using PetHouse.MVC.Controllers;
using PetHouse.MVC.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UI.Controllers
{
    [CustomAuthorize]
    public class VacunaController : BaseController
    {
        // GET: Vacuna
        public async Task<ActionResult> Index()
        {
            var result = await GetAsync("api/Vacuna");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Vacuna> vacunas = JsonConvert.DeserializeObject<List<Vacuna>>(resultdata);
                return View(vacunas);
            }

            ViewData["Error"] = await ErrorAsync("Vacuna", "Index", "Error al consultar api", 500);
            return HttpNotFound();
        }

        // GET: Vacuna/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Vacuna", "Details", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Vacuna/" + id.Value);
            Vacuna vacuna = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                vacuna = JsonConvert.DeserializeObject<Vacuna>(resultdata);
            }
            if (vacuna == null)
            {
                ViewData["Error"] = await ErrorAsync("Vacuna", "Details", "Error al consultar api", 404);
                return HttpNotFound();
            }
            await LLenarIndicador();
            return View(vacuna);
        }

        // GET: Vacuna/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vacuna/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Nombre,Descripcion,Precio")] Vacuna vacuna)
        {
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Vacuna", vacuna);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Vacuna", "Create", "Error insertar vacuna compruebe los campos", 400);
            return View(vacuna);
        }

        // GET: Vacuna/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Vacuna", "Edit", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Vacuna/" + id.Value);
            Vacuna vacuna = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                vacuna = JsonConvert.DeserializeObject<Vacuna>(resultdata);
            }
            if (vacuna == null)
            {
                ViewData["Error"] = await ErrorAsync("Vacuna", "Edit", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(vacuna);
        }

        // POST: Vacuna/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Descripcion,Precio")] Vacuna vacuna)
        {
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Vacuna/" + vacuna.Id, vacuna);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Vacuna", "Edit", "Error actualizar vacuna compruebe los campos", 400);
            return View(vacuna);
        }

        // GET: Vacuna/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Vacuna", "Delete", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Vacuna/" + id.Value);
            Vacuna vacuna = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                vacuna = JsonConvert.DeserializeObject<Vacuna>(resultdata);
            }
            if (vacuna == null)
            {
                ViewData["Error"] = await ErrorAsync("Vacuna", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(vacuna);
        }

        // POST: Vacuna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await DeleteAsync("api/Vacuna/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ViewData["Error"] = await ErrorAsync("Vacuna", "DeleteConfirmed", "Error eliminar vacuna compruebe los campos", 400);
            return HttpNotFound();
        }

        private async Task LLenarIndicador()
        {
            var FechaInicio = DateTime.Now.ToString("dd/MM/yyyy");
            var FechaFin = DateTime.Now.ToString("dd/MM/yyyy");
            var result = await PostAsync("api/Consulta/TipoCambio", new { Indicador = 318, FechaInicio, FechaFin });
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result.Replace("\"", "");
                ViewBag.TipoCambio = double.Parse(resultdata);
            } else
                ViewBag.TipoCambio = 0.0;
        }
    }
}
