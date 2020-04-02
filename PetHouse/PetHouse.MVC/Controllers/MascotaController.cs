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
        //private PetHouseEntities db = new PetHouseEntities();

        //// GET: Mascota
        //public async Task<ActionResult> Index()
        //{
        //    var mascota = db.Mascota.Include(m => m.Adopcion).Include(m => m.Expediente);
        //    return View(mascota.ToList());
        //}

        //// GET: Mascota/Details/5
        //public async Task<ActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Mascota mascota = db.Mascota.Find(id);
        //    if (mascota == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mascota);
        //}

        //// GET: Mascota/Create
        //public async Task<ActionResult> Create()
        //{
        //    ViewBag.AdopcionId = new SelectList(db.Adopcion, "Id", "Id");
        //    ViewBag.ExpedienteId = new SelectList(db.Expediente, "Id", "Observaciones");
        //    return View();
        //}

        //// POST: Mascota/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Identificacion,Nombre,Tipo,Genero,Raza,Fecha_Nacimiento,AdopcionId,ExpedienteId,Activo")] Mascota mascota)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Mascota.Add(mascota);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.AdopcionId = new SelectList(db.Adopcion, "Id", "Id", mascota.AdopcionId);
        //    ViewBag.ExpedienteId = new SelectList(db.Expediente, "Id", "Observaciones", mascota.ExpedienteId);
        //    return View(mascota);
        //}

        //// GET: Mascota/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Mascota mascota = db.Mascota.Find(id);
        //    if (mascota == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.AdopcionId = new SelectList(db.Adopcion, "Id", "Id", mascota.AdopcionId);
        //    ViewBag.ExpedienteId = new SelectList(db.Expediente, "Id", "Observaciones", mascota.ExpedienteId);
        //    return View(mascota);
        //}

        //// POST: Mascota/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Identificacion,Nombre,Tipo,Genero,Raza,Fecha_Nacimiento,AdopcionId,ExpedienteId,Activo")] Mascota mascota)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(mascota).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.AdopcionId = new SelectList(db.Adopcion, "Id", "Id", mascota.AdopcionId);
        //    ViewBag.ExpedienteId = new SelectList(db.Expediente, "Id", "Observaciones", mascota.ExpedienteId);
        //    return View(mascota);
        //}

        //// GET: Mascota/Delete/5
        //public async Task<ActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Mascota mascota = db.Mascota.Find(id);
        //    if (mascota == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mascota);
        //}

        //// POST: Mascota/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    Mascota mascota = db.Mascota.Find(id);
        //    db.Mascota.Remove(mascota);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        // GET: Mascota
        public async Task<ActionResult> Index()
        {
            var result = await GetAsync("api/Mascota");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Mascota> mascotas = JsonConvert.DeserializeObject<List<Mascota>>(resultdata);
                return View(mascotas);
            }

            ViewData["Error"] = await ErrorAsync("Mascota", "Index", "Error al consultar api", 500);
            return HttpNotFound();
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
            return View();
        }

        // POST: Mascota/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Identificacion,Nombre,Tipo,Genero,Raza,Fecha_Nacimiento,AdopcionId,ExpedienteId")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Mascota", mascota);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Mascota", "Create", "Error insertar mascota compruebe los campos", 400);
            return View(mascota);
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
        public async Task<ActionResult> Edit([Bind(Include = "Identificacion,Nombre,Tipo,Genero,Raza,Fecha_Nacimiento,AdopcionId,ExpedienteId")] Mascota mascota)
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
    }
}
