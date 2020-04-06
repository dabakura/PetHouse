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
    public class AdoptanteController : BasePadronController
    {
        // GET: Adoptante
        public async Task<ActionResult> Index()
        {
            var result = await GetAsync("api/Adoptante");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Adoptante> adoptantes = JsonConvert.DeserializeObject<List<Adoptante>>(resultdata);
                adoptantes = adoptantes.FindAll(adoptante => adoptante.Mascotas.Count() > 0);
                return View(adoptantes);
            }

            ViewData["Error"] = await ErrorAsync("Adoptante", "Index", "Error al consultar api", 500);
            return HttpNotFound();
        }

        // GET: Adoptante/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Adoptante", "Details", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Adoptante/" + id.Value);
            Adoptante adoptante = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                adoptante = JsonConvert.DeserializeObject<Adoptante>(resultdata);
            }
            if (adoptante == null)
            {
                ViewData["Error"] = await ErrorAsync("Adoptante", "Details", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(adoptante);
        }

        // GET: Adoptante/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Adoptante", "Edit", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Adoptante/" + id.Value);
            Adoptante adoptante = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                adoptante = JsonConvert.DeserializeObject<Adoptante>(resultdata);
            }
            if (adoptante == null)
            {
                ViewData["Error"] = await ErrorAsync("Adoptante", "Edit", "Error al consultar api", 404);
                return HttpNotFound();
            }
            await SetDomicilio(adoptante.Domicilio.ProvinciaId, adoptante.Domicilio.CantonId);
            return View(adoptante);
        }

        // POST: Adoptante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Identificacion,Nombre,Primer_Apellido,Segundo_Apellido,Fecha_Nacimiento,Telefono,Correo,DomicilioId,Domicilio")] Adoptante adoptante)
        {
            if (ModelState.IsValid)
            {
                var resultDomicilio = await PutAsync("api/Domicilio/" + adoptante.DomicilioId, adoptante.Domicilio);
                if (resultDomicilio.IsSuccessStatusCode)
                {
                    var result = await PutAsync("api/Adoptante/" + adoptante.Id, adoptante);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                }
            }
            await SetDomicilio(adoptante.Domicilio.ProvinciaId, adoptante.Domicilio.CantonId);
            ViewData["Error"] = await ErrorAsync("Adoptante", "Edit", "Error actualizar adoptante compruebe los campos", 400);
            return View(adoptante);
        }
    }
}
