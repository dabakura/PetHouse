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
        public async Task<ActionResult> Create()
        {
            await SetDomicilio();
            return View();
        }

        // POST: Institucion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Ced_Juridica,Nombre,Telefono,Fax,Pag_Web,Correo,Domicilio")] Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                var resultDomicilio = await PostAsync("api/Domicilio", institucion.Domicilio);
                if (resultDomicilio.IsSuccessStatusCode)
                {
                    string resultdata = resultDomicilio.Content.ReadAsStringAsync().Result;
                    institucion.Domicilio = JsonConvert.DeserializeObject<Domicilio>(resultdata);
                    var result = await PostAsync("api/Institucion", institucion);
                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                }
            }
            await SetDomicilio();
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
            await SetDomicilio(institucion.Domicilio.ProvinciaId, institucion.Domicilio.CantonId);
            return View(institucion);
        }

        // POST: Institucion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Ced_Juridica,Nombre,Telefono,Fax,Pag_Web,Correo,DireccionId,Domicilio")] Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                var resultDomicilio = await PutAsync("api/Domicilio/" + institucion.DireccionId, institucion.Domicilio);
                if (resultDomicilio.IsSuccessStatusCode)
                {
                    var result = await PutAsync("api/Institucion/" + institucion.Id, institucion);
                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                }
            }
            await SetDomicilio();
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

        [HttpPost]
        public async Task<JsonResult> ListCantones(int ID_PROVINCIA)
        {
            var cantones = await DataCantones(ID_PROVINCIA);
            var CantonesSelect = new SelectList(cantones, "Id", "Nombre");
            return Json(CantonesSelect);
        }

        [HttpPost]
        public async Task<JsonResult> ListDistritos(int ID_CANTON)
        {
            var distritos = await DataDistritos(ID_CANTON);
            var DistritosSelect = new SelectList(distritos, "Id", "Nombre");
            return Json(DistritosSelect);
        }

        private async Task<List<Provincia>> DataProvincias()
        {
            var result = await GetAsync("api/Provincia");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Provincia> provincias = JsonConvert.DeserializeObject<List<Provincia>>(resultdata);
                return provincias;
            }
            return new List<Provincia>();
        }

        private async Task<List<Canton>> DataCantones(int ID_PROVINCIA)
        {
            var result = await GetAsync("api/Canton");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Canton> Cantones = JsonConvert.DeserializeObject<List<Canton>>(resultdata);
                return Cantones.FindAll(canton => canton.ProvinciaId == ID_PROVINCIA);
            }
            return new List<Canton>();
        }

        private async Task<List<Distrito>> DataDistritos(int ID_CANTON)
        {
            var result = await GetAsync("api/Distrito");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Distrito> Distritos = JsonConvert.DeserializeObject<List<Distrito>>(resultdata);
                return Distritos.FindAll(distrito => distrito.CantonId == ID_CANTON);
            }
            return new List<Distrito>();
        }

        private async Task SetDomicilio(int? provincia_id = 0, int? canton_id = 0)
        {
            var Provincias = await DataProvincias();
            var Cantones = new List<Canton>();
            var Distritos = new List<Distrito>();
            if (Provincias.Count > 0)
            {
                if (provincia_id > 0)
                    Cantones = await DataCantones(provincia_id.Value);
                else
                    Cantones = await DataCantones(Provincias.ToArray()[0].Id);
            }
            if (Cantones.Count > 0)
            {
                if (canton_id > 0)
                    Distritos = await DataDistritos(canton_id.Value);
                else
                    Distritos = await DataDistritos(Cantones.ToArray()[0].Id);
            }
            ViewBag.Provincias = new SelectList(Provincias, "Id", "Nombre"); ;
            ViewBag.Cantones = new SelectList(Cantones, "Id", "Nombre"); ;
            ViewBag.Distritos = new SelectList(Distritos, "Id", "Nombre"); ;
        }
    }
}
