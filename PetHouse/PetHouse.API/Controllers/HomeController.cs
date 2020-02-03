using PetHouse.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PetHouse.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public async Task<ActionResult> Roles()
        {
            UserMantenimiento userMantenimiento = new UserMantenimiento();
            //var roles = userMantenimiento.Method().Select(rol => new { rol.Id, rol.Name }).ToList();
            //var result = ClsInstitucion.Instance.GetAll();
            var result = await userMantenimiento.MethodAsync();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
