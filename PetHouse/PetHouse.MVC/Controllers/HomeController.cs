using Newtonsoft.Json;
using PetHouse.MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PetHouse.MVC.Controllers
{
    [CustomAuthorize]
    public class HomeController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            await SetViewData();
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AnotherLink()
        {
            return View();
        }

        private async Task SetViewData()
        {
            ViewBag.Mascotas = await GetMascotasync();
            ViewBag.Expedientes = await GetExpedientesync();

            if (ViewBag.Expedientes == null || ViewBag.Mascotas == null)
            {
                ViewData["Error"] = await ErrorAsync("Home", "Index", "Error al consultar api", 404);
                ViewBag.Mascotas = new List<Mascota>();
                ViewBag.Expedientes = new List<Expediente>();
            }
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

        private async Task<List<Mascota>> GetMascotasync()
        {
            var result = await GetAsync("api/Mascota");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Mascota>>(resultdata);
            }
            return null;
        }
    }
}
