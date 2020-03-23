using Newtonsoft.Json;
using PetHouse.API.Models;
using PetHouse.MVC.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PetHouse.MVC.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // GET: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAsync(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                var result = await TokenAsync("Token", user);
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result.Replace("\".", "\"");
                    Token token = JsonConvert.DeserializeObject<Token>(resultdata);
                    Session.Add("Token", token);
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewData["Error"] = await ErrorAsync("Account", "LoginAsync", "Sus credenciales son incorrectos", 401);
            Session.Add("Token", null);
            return View("Login", user);
        }

        // GET: Account/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Add("Token", null);
            return RedirectToAction("Login");
        }

        // GET: Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // GET: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterAsync(RegisterUser register)
        {
            if (ModelState.IsValid)
            {
                var result = await PostAsync("api/Account/Register", register);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Login");
            }
            ViewData["Error"] = await ErrorAsync(
                "Account", 
                "RegisterAsync", 
                "Verifique los datos Ingresados. - Las contraseñas deben tener mayusculas minisculas un caracter y numeros.", 
                404);
            return View("Register", register);
        }
    }
}