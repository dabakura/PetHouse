using Newtonsoft.Json;
using PetHouse.MVC.Controllers;
using PetHouse.MVC.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class PuestoController : BaseController
    {
        // GET: Puesto
        public async Task<ActionResult> Index()
        {
            var result = await GetAsync("api/Puesto");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Puesto> puestos = JsonConvert.DeserializeObject<List<Puesto>>(resultdata);
                return View(puestos);
            }

            ViewData["Error"] = await ErrorAsync("Puesto", "Index", "Error al consultar api", 500);
            return HttpNotFound();
        }

        // GET: Puesto/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Puesto", "Details", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Puesto/" + id.Value);
            Puesto puesto = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                puesto = JsonConvert.DeserializeObject<Puesto>(resultdata);
            }
            if (puesto == null)
            {
                ViewData["Error"] = await ErrorAsync("Puesto", "Details", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(puesto);
        }

        // GET: Puesto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puesto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,Descripcion")] Puesto puesto)
        {
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Puesto", puesto);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Puesto", "Create", "Error insertar puesto compruebe los campos", 400);
            return View(puesto);
        }

        // GET: Puesto/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Puesto", "Edit", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Puesto/" + id.Value);
            Puesto puesto = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                puesto = JsonConvert.DeserializeObject<Puesto>(resultdata);
            }
            if (puesto == null)
            {
                ViewData["Error"] = await ErrorAsync("Puesto", "Edit", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(puesto);
        }

        // POST: Puesto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Descripcion")] Puesto puesto)
        {
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Puesto", puesto);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Puesto", "Edit", "Error actualizar puesto compruebe los campos", 400);
            return View(puesto);
        }

        // GET: Puesto/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Puesto", "Delete", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Puesto/" + id.Value);
            Puesto puesto = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                puesto = JsonConvert.DeserializeObject<Puesto>(resultdata);
            }
            if (puesto == null)
            {
                ViewData["Error"] = await ErrorAsync("Puesto", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(puesto);
        }

        // POST: Puesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await DeleteAsync("api/Puesto/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ViewData["Error"] = await ErrorAsync("Puesto", "DeleteConfirmed", "Error eliminar puesto compruebe los campos", 400);
            return HttpNotFound();
        }
    }
}