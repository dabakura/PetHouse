using Newtonsoft.Json;
using PetHouse.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PetHouse.MVC.Controllers
{
    public class EventoController : BaseController
    {
        // GET: Evento
        public async Task<ActionResult> Index()
        {
            var result = await GetAsync("api/Evento");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                ViewBag.Eventos = resultdata;
                return View();
            }

            ViewData["Error"] = await ErrorAsync("Evento", "Index", "Error al consultar api", 500);
            return HttpNotFound();
        }

        // POST: Evento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<JsonResult> Create([Bind(Include = "Titulo,Descripcion,Inicio,Fin,ColorFondo")]Evento evento)
        {
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Evento", evento);
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    evento = JsonConvert.DeserializeObject<Evento>(resultdata);
                    return Json(evento);
                }
            }
            var Error = await ErrorAsync("Evento", "Create", "Error al crear evento", 500);
            return new JsonHttpStatusResult(new { Error }, HttpStatusCode.BadRequest);
        }

        // POST: Evento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<JsonResult> Edit([Bind(Include = "Id,Titulo,Descripcion,Inicio,Fin,ColorFondo")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                var result = await PutAsync("api/Evento/" + evento.Id, evento);
                if (result.IsSuccessStatusCode)
                    return Json(evento);
            }
            var Error = await ErrorAsync("Evento", "Edit", "Error al actualizar evento", 500);
            return new JsonHttpStatusResult(new { Error }, HttpStatusCode.BadRequest);
        }

        // POST: Evento/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await DeleteAsync("api/Evento/" + id);
            if (result.IsSuccessStatusCode)
                return Json(new { Status= true });
            var Error = await ErrorAsync("Evento", "Delete", "Error al eliminar evento", 500);
            return new JsonHttpStatusResult(new { Error }, HttpStatusCode.BadRequest);
        }
    }
}