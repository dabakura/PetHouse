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
    public class ExpedienteController : BaseController
    {

        //private PetHouseEntities db = new PetHouseEntities();

        //// GET: Expediente
        //public async Task<ActionResult> Index()
        //{
        //    return View(db.Expediente.ToList());
        //}

        //// GET: Expediente/Details/5
        //public async Task<ActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Expediente expediente = db.Expediente.Find(id);
        //    if (expediente == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(expediente);
        //}

        //// GET: Expediente/Create
        //public async Task<ActionResult> Create()
        //{
        //    return View();
        //}

        //// POST: Expediente/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Observaciones,Edad,Peso,Castracion,Fecha_Ingreso,Fecha_Fallecimiento,Activo")] Expediente expediente)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Expediente.Add(expediente);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(expediente);
        //}

        //// GET: Expediente/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Expediente expediente = db.Expediente.Find(id);
        //    if (expediente == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(expediente);
        //}

        //// POST: Expediente/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Observaciones,Edad,Peso,Castracion,Fecha_Ingreso,Fecha_Fallecimiento,Activo")] Expediente expediente)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(expediente).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(expediente);
        //}

        //// GET: Expediente/Delete/5
        //public async Task<ActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Expediente expediente = db.Expediente.Find(id);
        //    if (expediente == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(expediente);
        //}

        //// POST: Expediente/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    Expediente expediente = db.Expediente.Find(id);
        //    db.Expediente.Remove(expediente);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        // GET: Expediente
        public async Task<ActionResult> Index()
        {
            var expedientes = await GetExpedientesync();
            if (expedientes == null)
            {
                ViewData["Error"] = await ErrorAsync("Expediente", "Index", "Error al consultar api", 500);
                return HttpNotFound();
            }
            return View(expedientes);
        }

        // GET: Expediente/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Expediente", "Details", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Expediente/" + id);
            Expediente expediente = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                expediente = JsonConvert.DeserializeObject<Expediente>(resultdata);
            }
            if (expediente == null)
            {
                ViewData["Error"] = await ErrorAsync("Expediente", "Details", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(expediente);
        }

        // GET: Expediente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expediente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Observaciones,Edad,Peso,Castracion,Fecha_Ingreso,Fecha_Fallecimiento")] Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Expediente", expediente);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Expediente", "Create", "Error insertar expediente compruebe los campos", 400);
            return View(expediente);
        }

        // GET: Expediente/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Expediente", "Edit", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Expediente/" + id);
            Expediente expediente = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                expediente = JsonConvert.DeserializeObject<Expediente>(resultdata);
            }
            if (expediente == null)
            {
                ViewData["Error"] = await ErrorAsync("Expediente", "Edit", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(expediente);
        }

        // POST: Expediente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Observaciones,Edad,Peso,Castracion,Fecha_Ingreso,Fecha_Fallecimiento")] Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Expediente/" + expediente.Id, expediente);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Expediente", "Edit", "Error actualizar expediente compruebe los campos", 400);
            return View(expediente);
        }

        // GET: Expediente/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Expediente", "Delete", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Expediente/" + id);
            Expediente expediente = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                expediente = JsonConvert.DeserializeObject<Expediente>(resultdata);
            }
            if (expediente == null)
            {
                ViewData["Error"] = await ErrorAsync("Expediente", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(expediente);
        }

        // POST: Expediente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var result = await DeleteAsync("api/Expediente/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ViewData["Error"] = await ErrorAsync("Expediente", "DeleteConfirmed", "Error eliminar expediente compruebe los campos", 400);
            return HttpNotFound();
        }

        private async Task<List<Expediente>> GetExpedientesync()
        {
            var result = await GetAsync("api/Expediente");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Expediente>>(resultdata);
            }
            return null;
        }
    }
}
