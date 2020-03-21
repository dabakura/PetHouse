using PetHouse.MVC.Models;
using System.Web.Mvc;

namespace PetHouse.MVC.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AnotherLink()
        {
            return View();
        }
    }
}
