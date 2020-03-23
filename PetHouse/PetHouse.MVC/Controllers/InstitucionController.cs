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
    public class InstitucionController : BaseController
    {
        // GET: Institucion
        public async Task<ActionResult> Index()
        {
            var result = await GetAsync("api/Institucion");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Institucion> instituciones = JsonConvert.DeserializeObject<List<Institucion>>(resultdata);
                return View(instituciones);
            }

            ViewData["Error"] = await ErrorAsync("Institucion", "Index", "Error al consultar api", 500);
            return HttpNotFound();
        }

        // GET: Institucion/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Institucion", "Details", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Institucion/" + id.Value);
            Institucion institucion = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                institucion = JsonConvert.DeserializeObject<Institucion>(resultdata);
            }
            if (institucion == null)
            {
                ViewData["Error"] = await ErrorAsync("Institucion", "Details", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(institucion);
        }

        // GET: Institucion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Institucion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Ced_Juridica,Nombre,Telefono,Fax,Pag_Web,Correo,DireccionId")] Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Institucion", institucion);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Institucion", "Create", "Error insertar institucion compruebe los campos", 400);
            return View(institucion);
        }

        // GET: Institucion/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Institucion", "Edit", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Institucion/" + id.Value);
            Institucion institucion = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                institucion = JsonConvert.DeserializeObject<Institucion>(resultdata);
            }
            if (institucion == null)
            {
                ViewData["Error"] = await ErrorAsync("Institucion", "Edit", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(institucion);
        }

        // POST: Institucion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Ced_Juridica,Nombre,Telefono,Fax,Pag_Web,Correo,DireccionId")] Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Institucion/" + institucion.Id, institucion);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Institucion", "Edit", "Error actualizar institucion compruebe los campos", 400);
            return View(institucion);
        }

        // GET: Institucion/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Institucion", "Delete", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Institucion/" + id.Value);
            Institucion institucion = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                institucion = JsonConvert.DeserializeObject<Institucion>(resultdata);
            }
            if (institucion == null)
            {
                ViewData["Error"] = await ErrorAsync("Institucion", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(institucion);
        }

        // POST: Institucion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await DeleteAsync("api/Institucion/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ViewData["Error"] = await ErrorAsync("Institucion", "DeleteConfirmed", "Error eliminar institucion compruebe los campos", 400);
            return HttpNotFound();
        }
    }
}
