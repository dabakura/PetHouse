using System.Web.Mvc;

namespace PetHouse.MVC.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult InternalServerError()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NotFound()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UnAuthorized()
        {
            return View();
        }
    }
}
