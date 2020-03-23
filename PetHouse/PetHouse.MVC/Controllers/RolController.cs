using Newtonsoft.Json;
using PetHouse.MVC.Controllers;
using PetHouse.MVC.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UI.Controllers
{
    [CustomAuthorize]
    public class RolController : BaseController
    {
        // GET: Rol
        public async Task<ActionResult> Index()
        {
            var result = await GetAsync("api/Rol");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Rol> roles = JsonConvert.DeserializeObject<List<Rol>>(resultdata);
                return View(roles);
            }

            ViewData["Error"] = await ErrorAsync("Rol", "Index", "Error al consultar api", 500);
            return HttpNotFound();
        }

        // GET: Rol/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Rol", "Details", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Rol/" + id.Value);
            Rol rol = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                rol = JsonConvert.DeserializeObject<Rol>(resultdata);
            }
            if (rol == null)
            {
                ViewData["Error"] = await ErrorAsync("Rol", "Details", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(rol);
        }

        // GET: Rol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rol/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Rol", rol);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Rol", "Create", "Error insertar rol compruebe los campos", 400);
            return View(rol);
        }

        // GET: Rol/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Rol", "Edit", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Rol/" + id.Value);
            Rol rol = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                rol = JsonConvert.DeserializeObject<Rol>(resultdata);
            }
            if (rol == null)
            {
                ViewData["Error"] = await ErrorAsync("Rol", "Edit", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(rol);
        }

        // POST: Rol/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Rol/" + rol.Id, rol);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Rol", "Edit", "Error actualizar rol compruebe los campos", 400);
            return View(rol);
        }

        // GET: Rol/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Rol", "Delete", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Rol/" + id.Value);
            Rol rol = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                rol = JsonConvert.DeserializeObject<Rol>(resultdata);
            }
            if (rol == null)
            {
                ViewData["Error"] = await ErrorAsync("Rol", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(rol);
        }

        // POST: Rol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await DeleteAsync("api/Rol/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ViewData["Error"] = await ErrorAsync("Rol", "DeleteConfirmed", "Error eliminar rol compruebe los campos", 400);
            return HttpNotFound();
        }
    }
}
