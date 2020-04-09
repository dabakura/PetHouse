using Newtonsoft.Json;
using PetHouse.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PetHouse.MVC.Controllers
{
    [CustomAuthorize]
    public class HomeProcedimientoController : BaseController
    {
        // GET: HomeTratamiento
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var expedientes = await GetExpedientesAsync();
            if (expedientes == null) {
                ViewData["Error"] = await ErrorAsync("HomeTratamiento", "Index", "Error al consultar api", 500);
                return HttpNotFound();
            }
            return View(expedientes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PanelProcedimiento(string ExpedienteId)
        {
            var expediente = await GetExpedienteAsync(ExpedienteId);
            if (expediente != null)
            {
                await SetDataAsync(ExpedienteId);
                var panelProcedimiento = new PanelProcedimientoViewModel(expediente);
                return View(panelProcedimiento);
            }
            ViewData["Error"] = await ErrorAsync("HomeTratamiento", "PanelProcedimiento", "Expediente Invalido", 400);
            return View("Index");
        }
        private async Task<List<Expediente>> GetExpedientesAsync()
        {
            var result = await GetAsync("api/Expediente");
            List<Expediente> expedientes = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                expedientes = JsonConvert.DeserializeObject<List<Expediente>>(resultdata);
            }
            return expedientes;
        }

        private async Task<List<Empleado>> GetEmpleadosAsync()
        {
            var result = await GetAsync("api/Empleado");
            List<Empleado> empleados = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                empleados = JsonConvert.DeserializeObject<List<Empleado>>(resultdata);
                empleados.ForEach(empleado => empleado.Nombre = empleado.Identificacion + " " + empleado.Nombre + " "+ empleado.Primer_Apellido + " "+ empleado.Segundo_Apellido);
            }
            return empleados;
        }

        private async Task<List<Medicamento>> GetMedicamentosAsync()
        {
            var result = await GetAsync("api/Medicamento");
            List<Medicamento> medicamento = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                medicamento = JsonConvert.DeserializeObject<List<Medicamento>>(resultdata);
            }
            return medicamento;
        }

        private async Task<Expediente> GetExpedienteAsync(string expedienteId)
        {
            var result = await GetAsync("api/Expediente/" + expedienteId);
            Expediente expediente = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                expediente = JsonConvert.DeserializeObject<Expediente>(resultdata);
            }
            return expediente;
        }
        private async Task SetDataAsync(string expedienteId)
        {
            List<Vacuna> vacunas = null;
            var carnets = await GetCarnetsAsync(expedienteId);
            var empleados = await GetEmpleadosAsync();
            var medicamentos = await GetMedicamentosAsync();
            if (empleados == null)
                empleados = new List<Empleado>();
            if (medicamentos == null)
                medicamentos = new List<Medicamento>();
            if (carnets != null)
                vacunas = await GetVacunasNoAdministradasAsync(carnets);
            else
                carnets = new List<Carnet>();
            if (vacunas == null)
                vacunas = new List<Vacuna>();
            ViewBag.VacunasNoAdministradas = new SelectList(vacunas, "Id", "Nombre");
            ViewBag.Carnets = carnets;
            ViewBag.Empleados = new SelectList(empleados, "Identificacion", "Nombre"); ;
            ViewBag.Medicamentos = medicamentos;
        }

        private async Task<List<Carnet>> GetCarnetsAsync(string expedienteId)
        {
            var result = await GetAsync("api/Carnet/" + expedienteId);
            List<Carnet> carnets = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                carnets = JsonConvert.DeserializeObject<List<Carnet>>(resultdata);
            }
            return carnets;
        }

        private async Task<List<Vacuna>> GetVacunasNoAdministradasAsync(List<Carnet> carnets)
        {
            var result = await GetAsync("api/Vacuna");
            List<Vacuna> vacunas = null;
            if (result.IsSuccessStatusCode)
            {
                var resultdata = result.Content.ReadAsStringAsync().Result;
                vacunas = JsonConvert.DeserializeObject<List<Vacuna>>(resultdata);
                var isdVacunas = carnets.Select(carnet => carnet.VacunaId).ToList();
                vacunas = vacunas.FindAll(vacuna => !isdVacunas.Contains(vacuna.Id));
            }
            return vacunas;
        }
    }
}