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
    public class CarnetController : BaseController
    {
        //private PetHouseEntities db = new PetHouseEntities();

        //// GET: Carnet
        //public async Task<ActionResult> Index()
        //{
        //    var carnet = db.Carnet.Include(c => c.Expediente).Include(c => c.Carnet);
        //    return View(carnet.ToList());
        //}

        //// GET: Carnet/Details/5
        //public async Task<ActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Carnet carnet = db.Carnet.Find(id);
        //    if (carnet == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(carnet);
        //}

        //// GET: Carnet/Create
        //public async Task<ActionResult> Create()
        //{
        //    ViewBag.ExpedienteId = new SelectList(db.Expediente, "Id", "Observaciones");
        //    ViewBag.CarnetId = new SelectList(db.Carnet, "Id", "Nombre");
        //    return View();
        //}

        //// POST: Carnet/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "ExpedienteId,CarnetId,Fecha_Vacunacion,Activo")] Carnet carnet)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Carnet.Add(carnet);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ExpedienteId = new SelectList(db.Expediente, "Id", "Observaciones", carnet.ExpedienteId);
        //    ViewBag.CarnetId = new SelectList(db.Carnet, "Id", "Nombre", carnet.CarnetId);
        //    return View(carnet);
        //}

        //// GET: Carnet/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Carnet carnet = db.Carnet.Find(id);
        //    if (carnet == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ExpedienteId = new SelectList(db.Expediente, "Id", "Observaciones", carnet.ExpedienteId);
        //    ViewBag.CarnetId = new SelectList(db.Carnet, "Id", "Nombre", carnet.CarnetId);
        //    return View(carnet);
        //}

        //// POST: Carnet/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "ExpedienteId,CarnetId,Fecha_Vacunacion,Activo")] Carnet carnet)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(carnet).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ExpedienteId = new SelectList(db.Expediente, "Id", "Observaciones", carnet.ExpedienteId);
        //    ViewBag.CarnetId = new SelectList(db.Carnet, "Id", "Nombre", carnet.CarnetId);
        //    return View(carnet);
        //}

        //// GET: Carnet/Delete/5
        //public async Task<ActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Carnet carnet = db.Carnet.Find(id);
        //    if (carnet == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(carnet);
        //}

        //// POST: Carnet/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    Carnet carnet = db.Carnet.Find(id);
        //    db.Carnet.Remove(carnet);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        // GET: Carnet
        public async Task<ActionResult> Index()
        {
            var result = await GetAsync("api/Carnet");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Carnet> carnets = JsonConvert.DeserializeObject<List<Carnet>>(resultdata);
                return View(carnets);
            }

            ViewData["Error"] = await ErrorAsync("Carnet", "Index", "Error al consultar api", 500);
            return HttpNotFound();
        }

        // GET: Carnet/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Carnet", "Details", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Carnet/" + id.Value);
            Carnet carnet = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                carnet = JsonConvert.DeserializeObject<Carnet>(resultdata);
            }
            if (carnet == null)
            {
                ViewData["Error"] = await ErrorAsync("Carnet", "Details", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(carnet);
        }

        // POST: Vacuna/Create
        [HttpPost]
        public async Task<JsonResult> Create([Bind(Include = "ExpedienteId,VacunaId,Fecha_Vacunacion,Expediente,Vacuna")] Carnet carnet)
        {
            ModelCustom(ModelState);
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Carnet", carnet);
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    carnet = JsonConvert.DeserializeObject<Carnet>(resultdata);
                    return Json(carnet);
                }
            }
            var Error = await ErrorAsync("Vacuna", "Create", "Error insertar vacuna compruebe los campos", 400);
            return new JsonHttpStatusResult(new { Error }, HttpStatusCode.BadRequest);
        }

        private void ModelCustom(ModelStateDictionary modelstage)
        {
            var keys = modelstage.Keys.ToArray();
            for (int i = 3; i < keys.Length; i++)
                modelstage.Remove(keys[i]);
        }

        //// GET: Carnet/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Carnet/Create
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "ExpedienteId,VacunaId,Fecha_Vacunacion")] Carnet carnet)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await PostAsync("api/Carnet", carnet);
        //        if (result.IsSuccessStatusCode)
        //            return RedirectToAction("Index");
        //    }
        //    ViewData["Error"] = await ErrorAsync("Carnet", "Create", "Error insertar carnet compruebe los campos", 400);
        //    return View(carnet);
        //}

        // GET: Carnet/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Carnet", "Edit", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Carnet/" + id.Value);
            Carnet carnet = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                carnet = JsonConvert.DeserializeObject<Carnet>(resultdata);
            }
            if (carnet == null)
            {
                ViewData["Error"] = await ErrorAsync("Carnet", "Edit", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(carnet);
        }

        // POST: Carnet/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ExpedienteId,VacunaId,Fecha_Vacunacion")] Carnet carnet)
        {
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Carnet/" + carnet.VacunaId, carnet);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Carnet", "Edit", "Error actualizar carnet compruebe los campos", 400);
            return View(carnet);
        }

        // GET: Carnet/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Carnet", "Delete", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Carnet/" + id.Value);
            Carnet carnet = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                carnet = JsonConvert.DeserializeObject<Carnet>(resultdata);
            }
            if (carnet == null)
            {
                ViewData["Error"] = await ErrorAsync("Carnet", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(carnet);
        }

        // POST: Carnet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await DeleteAsync("api/Carnet/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ViewData["Error"] = await ErrorAsync("Carnet", "DeleteConfirmed", "Error eliminar carnet compruebe los campos", 400);
            return HttpNotFound();
        }
    }
}
