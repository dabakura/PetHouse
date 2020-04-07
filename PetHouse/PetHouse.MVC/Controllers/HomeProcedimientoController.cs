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
                await setDataAsync(ExpedienteId);
                var panelProcedimiento = new PanelProcedimientoViewModel(expediente);
                return View(panelProcedimiento);
            }
            ViewData["Error"] = await ErrorAsync("HomeTratamiento", "PanelProcedimiento", "Expediente Invalido", 400);
            return View("Index");
        }

        private async Task<PanelProcedimientoInfoModel> GetDataAsync(string ExpedienteId)
        {
            var panelProcedimientoInfoModel = new PanelProcedimientoInfoModel();
            var expediente = await GetExpedienteAsync(ExpedienteId);
            if (expediente == null)
                return null;
            panelProcedimientoInfoModel.Expediente = expediente;
            var carnets = await GetCarnetsAsync(ExpedienteId);
            if (carnets == null)
                return null;
            panelProcedimientoInfoModel.Carnets = carnets;
            return panelProcedimientoInfoModel;
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
        private async Task setDataAsync(string expedienteId)
        {
            List<Vacuna> vacunas = null;
            var carnets = await GetCarnetsAsync(expedienteId);
            if (carnets != null)
                vacunas = await GetVacunasNoAdministradasAsync(carnets);
            else
                carnets = new List<Carnet>();
            if (vacunas == null)
                vacunas = new List<Vacuna>();
            ViewBag.VacunasNoAdministradas = new SelectList(vacunas, "Id", "Nombre");
            ViewBag.Carnets = carnets;
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