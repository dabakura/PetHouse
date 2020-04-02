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
    public class AdoptanteController : BaseController
    {
        //private PetHouseEntities db = new PetHouseEntities();

        //// GET: Adoptante
        //public async Task<ActionResult> Index()
        //{
        //    var adoptante = db.Adoptante.Include(a => a.Domicilio);
        //    return View(adoptante.ToList());
        //}

        //// GET: Adoptante/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Adoptante adoptante = db.Adoptante.Find(id);
        //    if (adoptante == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(adoptante);
        //}

        //// GET: Adoptante/Create
        //public async Task<ActionResult> Create()
        //{
        //    ViewBag.DomicilioId = new SelectList(db.Domicilio, "Id", "Direccion");
        //    return View();
        //}

        //// POST: Adoptante/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Identificacion,Nombre,Primer_Apellido,Segundo_Apellido,Fecha_Nacimiento,Telefono,Correo,DomicilioId,Activo")] Adoptante adoptante)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Adoptante.Add(adoptante);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.DomicilioId = new SelectList(db.Domicilio, "Id", "Direccion", adoptante.DomicilioId);
        //    return View(adoptante);
        //}

        //// GET: Adoptante/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Adoptante adoptante = db.Adoptante.Find(id);
        //    if (adoptante == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.DomicilioId = new SelectList(db.Domicilio, "Id", "Direccion", adoptante.DomicilioId);
        //    return View(adoptante);
        //}

        //// POST: Adoptante/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Identificacion,Nombre,Primer_Apellido,Segundo_Apellido,Fecha_Nacimiento,Telefono,Correo,DomicilioId,Activo")] Adoptante adoptante)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(adoptante).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.DomicilioId = new SelectList(db.Domicilio, "Id", "Direccion", adoptante.DomicilioId);
        //    return View(adoptante);
        //}

        //// GET: Adoptante/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Adoptante adoptante = db.Adoptante.Find(id);
        //    if (adoptante == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(adoptante);
        //}

        //// POST: Adoptante/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Adoptante adoptante = db.Adoptante.Find(id);
        //    db.Adoptante.Remove(adoptante);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        // GET: Adoptante
        public async Task<ActionResult> Index()
        {
            var result = await GetAsync("api/Adoptante");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Adoptante> adoptantes = JsonConvert.DeserializeObject<List<Adoptante>>(resultdata);
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

        // GET: Adoptante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adoptante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Identificacion,Nombre,Primer_Apellido,Segundo_Apellido,Fecha_Nacimiento,Telefono,Correo,DomicilioId")] Adoptante adoptante)
        {
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Adoptante", adoptante);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Adoptante", "Create", "Error insertar adoptante compruebe los campos", 400);
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
            return View(adoptante);
        }

        // POST: Adoptante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Identificacion,Nombre,Primer_Apellido,Segundo_Apellido,Fecha_Nacimiento,Telefono,Correo,DomicilioId")] Adoptante adoptante)
        {
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Adoptante/" + adoptante.Id, adoptante);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Adoptante", "Edit", "Error actualizar adoptante compruebe los campos", 400);
            return View(adoptante);
        }

        // GET: Adoptante/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Adoptante", "Delete", "No se ingreso el Id", 400);
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
                ViewData["Error"] = await ErrorAsync("Adoptante", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(adoptante);
        }

        // POST: Adoptante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await DeleteAsync("api/Adoptante/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ViewData["Error"] = await ErrorAsync("Adoptante", "DeleteConfirmed", "Error eliminar adoptante compruebe los campos", 400);
            return HttpNotFound();
        }
    }
}
