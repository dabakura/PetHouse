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
    public class RolController : BaseController
    {
        // GET: Rol
        public async Task<ActionResult> IndexSelect()
        {
            var result = await GetAsync("api/Empleado");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                List<Empleado> empleados = JsonConvert.DeserializeObject<List<Empleado>>(resultdata);
                return View(empleados);
            }

            ViewData["Error"] = await ErrorAsync("Rol", "IndexSelect", "Error al consultar api", 500);
            return View(new List<Empleado>()); ;
        }

        public async Task<ActionResult> Index(int? id)
        {
            var empleado = await GetEmpleadoAsync(id);
            var roles = await GetRolesAsync();

            if (empleado == null || roles == null)
            {
                ViewData["Error"] = await ErrorAsync("Rol", "Index", "Error al consultar api", 404);
                return HttpNotFound();
            }

            await SetViewData(empleado, roles);

            var empleadoUserRolModel = new EmpleadoUserRolModel { Empleado = empleado };
            return View(empleadoUserRolModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser([Bind(Include = "Empleado, User")] EmpleadoUserRolModel empleadoUserRolModel)
        {
            string userId = await Register(empleadoUserRolModel.User);
            if (userId != null)
            {
                var empleado = empleadoUserRolModel.Empleado;
                empleado.UserId = userId;
                var result = await PutAsync("api/Empleado/" + empleado.Identificacion, empleado);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index", new { id = empleado.Identificacion });
            }

            ViewData["Error"] = await ErrorAsync("Rol", "CreateUser", "Error al asignar permisos", 500);
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetRoles([Bind(Include = "Empleado, RolId")] EmpleadoUserRolModel empleadoUserRolModel)
        {
            Empleado empleado = await GetEmpleadoAsync(5);
            if (empleado == null)
            {
                ViewData["Error"] = await ErrorAsync("Rol", "Index", "Error al consultar api", 404);
                return HttpNotFound();
            }
            ViewBag.Empleado = empleado;

            var result = await GetAsync("api/Rol");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                ViewBag.Roles = JsonConvert.DeserializeObject<List<Rol>>(resultdata);
                return View();
            }

            ViewData["Error"] = await ErrorAsync("Rol", "Index", "Error al consultar api", 500);
            return HttpNotFound();
        }

        // GET: Rol/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = await ErrorAsync("Rol", "Delete", "No se ingreso el Id", 400);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await GetAsync("api/Rol/" + id.Value);
            Rol rol = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                rol = JsonConvert.DeserializeObject<Rol>(resultdata);
            }
            if (rol == null)
            {
                ViewData["Error"] = await ErrorAsync("Rol", "Delete", "Error al consultar api", 404);
                return HttpNotFound();
            }
            return View(rol);
        }

        // POST: Rol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await DeleteAsync("api/Rol/" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ViewData["Error"] = await ErrorAsync("Rol", "DeleteConfirmed", "Error eliminar rol compruebe los campos", 400);
            return HttpNotFound();
        }

        private async Task SetViewData(Empleado empleado, List<Rol> roles)
        {
            ViewBag.RolesAsignados = new List<Rol>();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");

            if (empleado.UserId != null)
            {
                var result = await GetAsync("api/Rol/GetUserRoles/" + empleado.UserId);
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    var rolesAsignados = JsonConvert.DeserializeObject<List<Rol>>(resultdata);
                    ViewBag.RolesAsignados = rolesAsignados;
                    var Roles = new RolManager(roles).SetAsignados(rolesAsignados).SetFilter(rol => !rol.IsAsignado).Roles;
                    ViewBag.Roles = new SelectList(Roles, "Id", "Name");
                }
                else
                    ViewData["Error"] = await ErrorAsync("Rol", "Index", "Error al consultar api", 404);
            }
        }

        private async Task<List<Rol>> GetRolesAsync()
        {
            var result = await GetAsync("api/Rol");
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                var roles = JsonConvert.DeserializeObject<List<Rol>>(resultdata);
                return roles;
            }
            return null;
        }

        private async Task<Empleado> GetEmpleadoAsync(int? id)
        {
            if (id == null)
                return null;
            var result = await GetAsync("api/Empleado/" + id.Value);
            Empleado empleado = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                empleado = JsonConvert.DeserializeObject<Empleado>(resultdata);
            }
            return empleado;
        }

        private async Task<string> Register(RegisterUser register)
        {
            var result = await PostAsync("api/Account/Register", register);
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                IdentityUser identity = JsonConvert.DeserializeObject<IdentityUser>(resultdata);
                return identity.Id;
            }
            return null;
        }
    }
}
