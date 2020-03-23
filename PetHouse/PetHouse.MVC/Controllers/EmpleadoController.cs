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
    public class EmpleadoController : BaseController
    {
        // GET: Empleado
        public async Task<ActionResult> Index()
        {
            var result = await GetAsync("api/Empleado");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Empleado> empleados = JsonConvert.DeserializeObject<List<Empleado>>(resultdata);
                return View(empleados);
            }

            ViewData["Error"] = await ErrorAsync("Empleado", "Index", "Error al consultar api", 500);
            return HttpNotFound();
        }

        // GET: Empleado/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Empleado", "Details", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Empleado/" + id.Value);
            Empleado empleado = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                empleado = JsonConvert.DeserializeObject<Empleado>(resultdata);
            }
            if (empleado == null)
            {
                ViewData["Error"] = await ErrorAsync("Empleado", "Details", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Identificacion,Nombre,Primer_Apellido,Segundo_Apellido,Fecha_Nacimiento,Telefono,Correo,DomicilioId,PuestoID,InstitucionId,UserId")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Empleado", empleado);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Empleado", "Create", "Error insertar empleado compruebe los campos", 400);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Empleado", "Edit", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Empleado/" + id.Value);
            Empleado empleado = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                empleado = JsonConvert.DeserializeObject<Empleado>(resultdata);
            }
            if (empleado == null)
            {
                ViewData["Error"] = await ErrorAsync("Empleado", "Edit", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Identificacion,Nombre,Primer_Apellido,Segundo_Apellido,Fecha_Nacimiento,Telefono,Correo,DomicilioId,PuestoID,InstitucionId,UserId")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Empleado/" + empleado.Id, empleado);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ViewData["Error"] = await ErrorAsync("Empleado", "Edit", "Error actualizar empleado compruebe los campos", 400);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Empleado", "Delete", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Empleado/" + id.Value);
            Empleado empleado = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                empleado = JsonConvert.DeserializeObject<Empleado>(resultdata);
            }
            if (empleado == null)
            {
                ViewData["Error"] = await ErrorAsync("Empleado", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await DeleteAsync("api/Empleado/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ViewData["Error"] = await ErrorAsync("Empleado", "DeleteConfirmed", "Error eliminar empleado compruebe los campos", 400);
            return HttpNotFound();
        }
    }
}
