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
        //private PetHouseEntities db = new PetHouseEntities();

        //// GET: Tratamientoe
        //public async Task<ActionResult> Index()
        //{
        //    var tratamiento = db.Tratamiento.Include(t => t.Empleado).Include(t => t.Expediente);
        //    return View(tratamiento.ToList());
        //}

        //// GET: Tratamientoe/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Tratamiento tratamiento = db.Tratamiento.Find(id);
        //    if (tratamiento == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tratamiento);
        //}

        //// GET: Tratamientoe/Create
        //public async Task<ActionResult> Create()
        //{
        //    ViewBag.EmpleadoId = new SelectList(db.Empleado, "Identificacion", "Nombre");
        //    ViewBag.ExpedienteId = new SelectList(db.Expediente, "Id", "Observaciones");
        //    return View();
        //}

        //// POST: Tratamientoe/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,ExpedienteId,EmpleadoId,Descripcion,Fecha,Activo")] Tratamiento tratamiento)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Tratamiento.Add(tratamiento);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.EmpleadoId = new SelectList(db.Empleado, "Identificacion", "Nombre", tratamiento.EmpleadoId);
        //    ViewBag.ExpedienteId = new SelectList(db.Expediente, "Id", "Observaciones", tratamiento.ExpedienteId);
        //    return View(tratamiento);
        //}

        //// GET: Tratamientoe/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Tratamiento tratamiento = db.Tratamiento.Find(id);
        //    if (tratamiento == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.EmpleadoId = new SelectList(db.Empleado, "Identificacion", "Nombre", tratamiento.EmpleadoId);
        //    ViewBag.ExpedienteId = new SelectList(db.Expediente, "Id", "Observaciones", tratamiento.ExpedienteId);
        //    return View(tratamiento);
        //}

        //// POST: Tratamientoe/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,ExpedienteId,EmpleadoId,Descripcion,Fecha,Activo")] Tratamiento tratamiento)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tratamiento).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.EmpleadoId = new SelectList(db.Empleado, "Identificacion", "Nombre", tratamiento.EmpleadoId);
        //    ViewBag.ExpedienteId = new SelectList(db.Expediente, "Id", "Observaciones", tratamiento.ExpedienteId);
        //    return View(tratamiento);
        //}

        //// GET: Tratamientoe/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Tratamiento tratamiento = db.Tratamiento.Find(id);
        //    if (tratamiento == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tratamiento);
        //}

        //// POST: Tratamientoe/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Tratamiento tratamiento = db.Tratamiento.Find(id);
        //    db.Tratamiento.Remove(tratamiento);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //// GET: Tratamiento
        //public async Task<ActionResult> Index()
        //{
        //    var result = await GetAsync("api/Tratamiento");
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var resultdata = result.Content.ReadAsStringAsync().Result;
        //        List<Tratamiento> tratamientos = JsonConvert.DeserializeObject<List<Tratamiento>>(resultdata);
        //        return View(tratamientos);
        //    }

        //    ViewData["Error"] = await ErrorAsync("Tratamiento", "Index", "Error al consultar api", 500);
        //    return HttpNotFound();
        //}

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

        // GET: Tratamiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tratamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ExpedienteId,EmpleadoId,Descripcion,Fecha")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Tratamiento", tratamiento);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Tratamiento", "Create", "Error insertar tratamiento compruebe los campos", 400);
            return View(tratamiento);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,ExpedienteId,EmpleadoId,Descripcion,Fecha")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Tratamiento/" + tratamiento.Id, tratamiento);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            ViewData["Error"] = await ErrorAsync("Tratamiento", "DeleteConfirmed", "Error eliminar tratamiento compruebe los campos", 400);
            return HttpNotFound();
        }
    }
}
