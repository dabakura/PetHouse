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
    public class AdopcionController : BasePadronController
    {
        // GET: Adopcion
        public async Task<ActionResult> Index()
        {
            List<Adopcion> adopciones = await GetAdopcionesAsync("Index");
            return View(adopciones);
        }

        // GET: Adopcion/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Adopcion", "Details", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Adopcion/" + id.Value);
            Adopcion adopcion = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                adopcion = JsonConvert.DeserializeObject<Adopcion>(resultdata);
            }
            if (adopcion == null)
            {
                ViewData["Error"] = await ErrorAsync("Adopcion", "Details", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(adopcion);
        }

        // GET: Adopcion/Create
        public async Task<ActionResult> Create()
        {
            await SetDomicilio();
            await SetInstitucionesData();
            await SetMascotaData();
            return View();
        }

        // POST: Adopcion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InstitucionId,AdoptanteId,MascotaId,Fecha_Adopcion,Institucion,Adoptante,Mascota")] Adopcion adopcion)
        {
            if (ModelState.IsValid)
            {
                if (await RegistarAdoptante(adopcion.Adoptante))
                {
                    var result = await PostAsync("api/Adopcion", adopcion);
                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                }
            }
            await SetDomicilio();
            await SetInstitucionesData();
            await SetMascotaData();
            ViewData["Error"] = await ErrorAsync("Adopcion", "Create", "Error insertar adopción compruebe los campos", 400);
            return View(adopcion);
        }

        // GET: Adopcion/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Adopcion", "Edit", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Adopcion/" + id.Value);
            Adopcion adopcion = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                adopcion = JsonConvert.DeserializeObject<Adopcion>(resultdata);
            }
            if (adopcion == null)
            {
                ViewData["Error"] = await ErrorAsync("Adopcion", "Edit", "Error al consultar api", 404);
                return HttpNotFound();
            }
            await SetInstitucionesData();
            await SetInstitucionesData();
            await SetMascotaData();
            return View(adopcion);
        }

        // POST: Adopcion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,InstitucionId,AdoptanteId,MascotaId,Fecha_Adopcion,Institucion,Adoptante,Mascota")] Adopcion adopcion)
        {
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Adopcion/" + adopcion.Id, adopcion);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Adopcion", "Edit", "Error actualizar adopción compruebe los campos", 400);
            return View(adopcion);
        }

        // GET: Adopcion/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Adopcion", "Delete", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Adopcion/" + id.Value);
            Adopcion adopcion = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                adopcion = JsonConvert.DeserializeObject<Adopcion>(resultdata);
            }
            if (adopcion == null)
            {
                ViewData["Error"] = await ErrorAsync("Adopcion", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(adopcion);
        }

        // POST: Adopcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await DeleteAsync("api/Adopcion/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ViewData["Error"] = await ErrorAsync("Adopcion", "DeleteConfirmed", "Error eliminar adopción compruebe los campos", 400);
            return HttpNotFound();
        }

        private async Task<bool> RegistarAdoptante(Adoptante adoptante)
        {
            if (await ValidarAdoptante(adoptante.Identificacion))
            {
                var resultDomicilio = await PostAsync("api/Domicilio", adoptante.Domicilio);
                if (resultDomicilio.IsSuccessStatusCode)
                {
                    string resultdata = resultDomicilio.Content.ReadAsStringAsync().Result;
                    adoptante.Domicilio = JsonConvert.DeserializeObject<Domicilio>(resultdata);
                    var result = await PostAsync("api/Adoptante", adoptante);
                    return result.IsSuccessStatusCode;
                }
                return false;
            }
            return true;
        }

        private async Task<bool> ValidarAdoptante(int identificacion)
        {
            var result = await GetAsync("api/Adoptante/" + identificacion);
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                return resultdata == "null";
            }
            return true;
        }

        private async Task SetInstitucionesData()
        {
            var result = await GetAsync("api/Institucion");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                var Instituciones = JsonConvert.DeserializeObject<List<Institucion>>(resultdata);
                ViewBag.Instituciones = new SelectList(Instituciones, "Id", "Nombre");
            }
        }

        private async Task SetMascotaData()
        {
            var adopciones = await GetAdopcionesAsync("Create");
            var mascotasAdoptadasIds = adopciones.Select(adopcion => adopcion.MascotaId).ToList();
            var result = await GetAsync("api/Mascota");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                var Mascotas = JsonConvert.DeserializeObject<List<Mascota>>(resultdata);
                Mascotas = Mascotas.FindAll(mascota => !mascotasAdoptadasIds.Contains(mascota.Identificacion));
                Mascotas.ForEach(mascota => mascota.Nombre = mascota.Identificacion + " - " + mascota.Nombre);
                ViewBag.Mascotas = new SelectList(Mascotas, "Identificacion", "Nombre");
            }
        }

        private async Task<List<Adopcion>> GetAdopcionesAsync(string action)
        {
            var result = await GetAsync("api/Adopcion");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Adopcion>>(resultdata);
            }
            ViewData["Error"] = await ErrorAsync("Adopcion", action + " - GetAdopcionesAsync", "Error al consultar api", 500);
            return new List<Adopcion>();
        }
    }
}
