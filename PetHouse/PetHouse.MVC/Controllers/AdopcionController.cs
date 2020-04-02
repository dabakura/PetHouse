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
    public class AdopcionController : BaseController
    {
        //private PetHouseEntities db = new PetHouseEntities();

        //// GET: Adopcion
        //public async Task<ActionResult> Index()
        //{
        //    var adopcion = db.Adopcion.Include(a => a.Adoptante).Include(a => a.Institucion);
        //    return View(adopcion.ToList());
        //}

        //// GET: Adopcion/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Adopcion adopcion = db.Adopcion.Find(id);
        //    if (adopcion == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(adopcion);
        //}

        //// GET: Adopcion/Create
        //public async Task<ActionResult> Create()
        //{
        //    ViewBag.AdoptanteId = new SelectList(db.Adoptante, "Identificacion", "Nombre");
        //    ViewBag.InstituionId = new SelectList(db.Institucion, "Id", "Ced_Juridica");
        //    return View();
        //}

        //// POST: Adopcion/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,InstituionId,AdoptanteId,Fecha_Adopcion,Activo")] Adopcion adopcion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Adopcion.Add(adopcion);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.AdoptanteId = new SelectList(db.Adoptante, "Identificacion", "Nombre", adopcion.AdoptanteId);
        //    ViewBag.InstituionId = new SelectList(db.Institucion, "Id", "Ced_Juridica", adopcion.InstituionId);
        //    return View(adopcion);
        //}

        //// GET: Adopcion/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Adopcion adopcion = db.Adopcion.Find(id);
        //    if (adopcion == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.AdoptanteId = new SelectList(db.Adoptante, "Identificacion", "Nombre", adopcion.AdoptanteId);
        //    ViewBag.InstituionId = new SelectList(db.Institucion, "Id", "Ced_Juridica", adopcion.InstituionId);
        //    return View(adopcion);
        //}

        //// POST: Adopcion/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,InstituionId,AdoptanteId,Fecha_Adopcion,Activo")] Adopcion adopcion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(adopcion).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.AdoptanteId = new SelectList(db.Adoptante, "Identificacion", "Nombre", adopcion.AdoptanteId);
        //    ViewBag.InstituionId = new SelectList(db.Institucion, "Id", "Ced_Juridica", adopcion.InstituionId);
        //    return View(adopcion);
        //}

        //// GET: Adopcion/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Adopcion adopcion = db.Adopcion.Find(id);
        //    if (adopcion == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(adopcion);
        //}

        //// POST: Adopcion/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Adopcion adopcion = db.Adopcion.Find(id);
        //    db.Adopcion.Remove(adopcion);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        // GET: Adopcion
        public async Task<ActionResult> Index()
        {
            var result = await GetAsync("api/Adopcion");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Adopcion> adopciones = JsonConvert.DeserializeObject<List<Adopcion>>(resultdata);
                return View(adopciones);
            }

            ViewData["Error"] = await ErrorAsync("Adopcion", "Index", "Error al consultar api", 500);
            return HttpNotFound();
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adopcion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,InstituionId,AdoptanteId,Fecha_Adopcion")] Adopcion adopcion)
        {
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Adopcion", adopcion);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
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
            return View(adopcion);
        }

        // POST: Adopcion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,InstituionId,AdoptanteId,Fecha_Adopcion")] Adopcion adopcion)
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
    }
}
