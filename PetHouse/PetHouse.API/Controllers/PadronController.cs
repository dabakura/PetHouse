using PetHouse.API.Models;
using PetHouse.BLL.Repositorios;
using PetHouse.BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PetHouse.API.Controllers
{
    public class PadronController : Controller
    {
        private delegate void del_ActualizarProceso(string pNota, int pAvanceTotal, int pAvanceReal);
        public IPadronService PadronServicio { get; }

        public PadronController()
        {
            PadronServicio = new PadronRepositorio();
        }
        // GET: Padron
        public ActionResult Index()
        {
            return View(new { Error = "", Complete = false });
        }

        // POST: Padron/Create
        [HttpPost]
        public async Task<ActionResult> UploadingRegiones(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength <= 0)
                return View("Index", new { Error = "No file", Complete = false });
            if (!await bgwCargaRegiones_DoWork(file))
                return View("Index", new { Error = "Se ha prodicido un error", Complete = false });
            return View("Index", new { Error = "", Complete = true });
        }

        // POST: Padron/Create
        [HttpPost]
        public async Task<ActionResult> uploadingPadron(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength <= 0)
                return View("Index", new { Error = "No file", Complete = false });
            if (!await bgwCargaPersonas_DoWork(file))
                return View("Index", new { Error = "Se ha prodicido un error", Complete = false });
            return View("Index", new { Error = "", Complete = true });
        }

        private async Task<bool> bgwCargaPersonas_DoWork(HttpPostedFileBase file)
        {
            try
            {
                await CargarArchivoPersonas(file);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<bool> bgwCargaRegiones_DoWork(HttpPostedFileBase file)
        {
            try
            {
                await CargarArchivoRegiones(file);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private Task CargarArchivoPersonas(HttpPostedFileBase file)
        {
            try
            {
                DataPadron dataPadron = CargarData(file);
                del_ActualizarProceso proceso = new del_ActualizarProceso(ActualizarProcesoPersonas);
                foreach (string linea in dataPadron.Lineas)
                {
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
                    proceso.Invoke("Fila-" + dataPadron.PFila, dataPadron.PCantidadTotal, dataPadron.PFila);
                }
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Task CargarArchivoRegiones(HttpPostedFileBase file)
        {
            try
            {
                DataPadron dataPadron = CargarData(file);
                //Leemos Todas las lineas del fichero
                del_ActualizarProceso proceso = new del_ActualizarProceso(ActualizarProcesoRegiones);
                dataPadron.Lineas.ForEach(linea => {
                    dataPadron.PFila += 1;
                    //Partimos la linea con el caracter "," indicado
                    dataPadron.Campos = linea.Split(",".ToCharArray());
                    int idprovincia = Convert.ToInt32(dataPadron.Campos[0].Trim().Substring(0, 1));
                    int idcanton = Convert.ToInt32(dataPadron.Campos[0].Trim().Substring(0, 3));
                    int iddistrito = Convert.ToInt32(dataPadron.Campos[0].Trim());
                    if (idprovincia > 0 && idprovincia < 8)
                        PadronServicio.InsertRegion(idprovincia, idcanton, iddistrito, dataPadron.Campos[1].Trim(), dataPadron.Campos[2].Trim(), dataPadron.Campos[3].Trim());
                    proceso.Invoke("Fila-" + dataPadron.PFila, dataPadron.PCantidadTotal, dataPadron.PFila);
                });
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private DataPadron CargarData(HttpPostedFileBase file)
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
                return dataPadron;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ActualizarProcesoPersonas(string pNota, int pAvanceTotal, int pAvanceReal)
        {
            
        }

        private void ActualizarProcesoRegiones(string pNota, int pAvanceTotal, int pAvanceReal)
        {

        }
    }
}