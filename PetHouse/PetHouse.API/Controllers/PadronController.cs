using PetHouse.API.Models;
using PetHouse.BLL.Repositorios;
using PetHouse.BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace PetHouse.API.Controllers
{
    public class PadronController : Controller
    {
        public IPadronService PadronServicio { get; }

        public PadronController()
        {
            PadronServicio = new PadronRepositorio();
        }
        // GET: Padron
        public ActionResult Index()
        {
            return View();
        }

        // POST: Padron/Create
        [HttpPost]
        public async Task<ActionResult> UploadingRegiones(HttpPostedFileBase file)
        {
            try
            {
                if (file == null || file.ContentLength <= 0)
                    return View("Index", new { Error = "No file", Complete = false });
                DataPadron dataPadron = await CargarData(file);
                HostingEnvironment.QueueBackgroundWorkItem(token => CargarArchivoRegiones(dataPadron, token));
            }
            catch (Exception ex)
            {
                return View("Index", new { Error = ex.Message, Complete = false });
            }
            return RedirectToAction("Index");
        }

        // POST: Padron/Create
        [HttpPost]
        public async Task<ActionResult> UploadingPadron(HttpPostedFileBase file)
        {
            try
            {
                if (file == null || file.ContentLength <= 0)
                    return View("Index", new { Error = "No file", Complete = false });
                DataPadron dataPadron = await CargarData(file);
                HostingEnvironment.QueueBackgroundWorkItem(token => CargarArchivoPersonas(dataPadron, token));
            }
            catch (Exception ex)
            {
                return View("Index", new { Error = ex.Message, Complete = false });
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult IndicatorPadron()
        {
            return Json(IndicatorState.IndicatorPersonas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult IndicatorRegion()
        {
            return Json(IndicatorState.IndicatorRegion, JsonRequestBehavior.AllowGet);
        }

        private Task CargarArchivoPersonas(DataPadron dataPadron, CancellationToken token)
        {
            try
            {
                dataPadron.Lineas.ForEach(linea => {
                    if (token.IsCancellationRequested) return;
                    dataPadron.PFila += 1;
                    //Partimos la linea con el caracter "," indicado
                    dataPadron.Campos = linea.Split(",".ToCharArray());
                    int idprovincia = Convert.ToInt32(dataPadron.Campos[1].Trim().Substring(0, 1));
                    int idcanton = Convert.ToInt32(dataPadron.Campos[1].Trim().Substring(0, 3));
                    int iddistrito = Convert.ToInt32(dataPadron.Campos[1].Trim());
                    if (idprovincia > 0 && idprovincia < 8)
                        PadronServicio.InsertPersona(Convert.ToInt32(dataPadron.Campos[0].Trim()), 
                            dataPadron.Campos[5].Trim(), dataPadron.Campos[6].Trim(), 
                            dataPadron.Campos[7].Trim(), Convert.ToInt32(dataPadron.Campos[2].Trim()), 
                            idprovincia, idcanton, iddistrito);
                    ActualizarProcesoPersonas(dataPadron);
                });
                IndicatorState.IndicatorPersonas = new Indicator();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        private Task CargarArchivoRegiones(DataPadron dataPadron, CancellationToken token)
        {
            try
            {
                dataPadron.Lineas.ForEach(linea => {
                    if (token.IsCancellationRequested) return;
                    dataPadron.PFila += 1;
                    //Partimos la linea con el caracter "," indicado
                    dataPadron.Campos = linea.Split(",".ToCharArray());
                    int idprovincia = Convert.ToInt32(dataPadron.Campos[0].Trim().Substring(0, 1));
                    int idcanton = Convert.ToInt32(dataPadron.Campos[0].Trim().Substring(0, 3));
                    int iddistrito = Convert.ToInt32(dataPadron.Campos[0].Trim());
                    if (idprovincia > 0 && idprovincia < 8)
                        PadronServicio.InsertRegion(idprovincia, idcanton, iddistrito, dataPadron.Campos[1].Trim(), dataPadron.Campos[2].Trim(), dataPadron.Campos[3].Trim());
                    ActualizarProcesoRegiones(dataPadron);
                });
                IndicatorState.IndicatorRegion = new Indicator();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        private Task<DataPadron> CargarData(HttpPostedFileBase file)
        {
            try
            {
                DataPadron dataPadron = new DataPadron();
                //Leemos Todas las lineas del fichero
                using (StreamReader reader = new StreamReader(file.InputStream))
                {
                    while (!reader.EndOfStream)
                        dataPadron.Lineas.Add(reader.ReadLine());
                }
                dataPadron.PCantidadTotal = dataPadron.Lineas.Count();
                return Task.FromResult(dataPadron);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ActualizarProcesoPersonas(DataPadron dataPadron)
        {
            IndicatorState.IndicatorPersonas.PAvanceReal = dataPadron.PFila;
            IndicatorState.IndicatorPersonas.PAvanceTotal = dataPadron.PCantidadTotal;
            IndicatorState.IndicatorPersonas.PNota = "Fila-" + dataPadron.PFila;
        }

        private void ActualizarProcesoRegiones(DataPadron dataPadron)
        {
            IndicatorState.IndicatorRegion.PAvanceReal = dataPadron.PFila;
            IndicatorState.IndicatorRegion.PAvanceTotal = dataPadron.PCantidadTotal;
            IndicatorState.IndicatorRegion.PNota = "Fila-" + dataPadron.PFila;
        }
    }
}