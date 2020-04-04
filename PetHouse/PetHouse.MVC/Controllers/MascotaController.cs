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
    public class MascotaController : BaseController
    {
        // GET: Mascota
        public async Task<ActionResult> Index()
        {
            var mascotas = await GetMascotasync();
            if (mascotas == null)
            {
                ViewData["Error"] = await ErrorAsync("Mascota", "Index", "Error al consultar api", 500);
                return HttpNotFound();
            }
            return View(mascotas);
        }

        // GET: Mascota/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Mascota", "Details", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Mascota/" + id);
            Mascota mascota = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                mascota = JsonConvert.DeserializeObject<Mascota>(resultdata);
            }
            if (mascota == null)
            {
                ViewData["Error"] = await ErrorAsync("Mascota", "Details", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(mascota);
        }

        // GET: Mascota/Create
        public ActionResult Create()
        {
            return RedirectToAction("Ingreso", "Home");
        }

        // GET: Mascota/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Mascota", "Edit", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Mascota/" + id);
            Mascota mascota = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                mascota = JsonConvert.DeserializeObject<Mascota>(resultdata);
            }
            if (mascota == null)
            {
                ViewData["Error"] = await ErrorAsync("Mascota", "Edit", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascota/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Identificacion,Nombre,Tipo,Genero,Raza,Fecha_Nacimiento,AdopcionId,ExpedienteId,Adopcion,Expediente")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Mascota/" + mascota.Identificacion, mascota);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Mascota", "Edit", "Error actualizar mascota compruebe los campos", 400);
            return View(mascota);
        }

        // GET: Mascota/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Mascota", "Delete", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Mascota/" + id);
            Mascota mascota = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                mascota = JsonConvert.DeserializeObject<Mascota>(resultdata);
            }
            if (mascota == null)
            {
                ViewData["Error"] = await ErrorAsync("Mascota", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var result = await DeleteAsync("api/Mascota/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ViewData["Error"] = await ErrorAsync("Mascota", "DeleteConfirmed", "Error eliminar mascota compruebe los campos", 400);
            return HttpNotFound();
        }

        private async Task<List<Mascota>> GetMascotasync()
        {
            var result = await GetAsync("api/Mascota");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Mascota>>(resultdata);
            }
            return null;
        }
    }
}
