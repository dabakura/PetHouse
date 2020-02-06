using PetHouse.BLL;
using PetHouse.BLL.Services;
using PetHouse.BLL.Repositorios;
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
        private IRoleService RolesRepositorio;
        public HomeController()
        {
            this.RolesRepositorio = new AspNetRolesRepositorio();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Roles()
        {
            var result = RolesRepositorio.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
