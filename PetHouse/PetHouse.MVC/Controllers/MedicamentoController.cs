using Newtonsoft.Json;
using PetHouse.MVC.Controllers;
using PetHouse.MVC.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class MedicamentoController : BaseController
    {
        // GET: Medicamento
        public async Task<ActionResult> Index()
        {
            var result = await GetAsync("api/Medicamento");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Medicamento> medicamentos = JsonConvert.DeserializeObject<List<Medicamento>>(resultdata);
                return View(medicamentos);
            }

            ViewData["Error"] = await ErrorAsync("Medicamento", "Index", "Error al consultar api", 500);
            return HttpNotFound();
        }

        // GET: Medicamento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Medicamento", "Details", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Medicamento/" + id.Value);
            Medicamento medicamento = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                medicamento = JsonConvert.DeserializeObject<Medicamento>(resultdata);
            }
            if (medicamento == null)
            {
                ViewData["Error"] = await ErrorAsync("Medicamento", "Details", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // GET: Medicamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicamento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Nombre,Descripcion,Precio,Tipo")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Medicamento", medicamento);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Medicamento", "Create", "Error insertar medicamento compruebe los campos", 400);
            return View(medicamento);
        }

        // GET: Medicamento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Medicamento", "Edit", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Medicamento/" + id.Value);
            Medicamento medicamento = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                medicamento = JsonConvert.DeserializeObject<Medicamento>(resultdata);
            }
            if (medicamento == null)
            {
                ViewData["Error"] = await ErrorAsync("Medicamento", "Edit", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Descripcion,Precio,Tipo")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Medicamento", medicamento);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Medicamento", "Edit", "Error actualizar medicamento compruebe los campos", 400);
            return View(medicamento);
        }

        // GET: Medicamento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Medicamento", "Delete", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Medicamento/" + id.Value);
            Medicamento medicamento = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                medicamento = JsonConvert.DeserializeObject<Medicamento>(resultdata);
            }
            if (medicamento == null)
            {
                ViewData["Error"] = await ErrorAsync("Medicamento", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await DeleteAsync("api/Medicamento/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ViewData["Error"] = await ErrorAsync("Medicamento", "DeleteConfirmed", "Error eliminar medicamento compruebe los campos", 400);
            return HttpNotFound();
        }
    }
}
