using PetHouse.API.Models;
using PetHouse.BLL.Repositorios;
using PetHouse.BLL.Services;
using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetHouse.API.Controllers
{
    [RoutePrefix("api/Mascota")]
    public class MascotaController : ApiController
    {
        public IMascotaService MascotaServicio { get; }

        public MascotaController()
        {
            MascotaServicio = new MascotaRepositorio();
        }

        // GET: api/Mascota
        public IHttpActionResult Get()
        {
            try
            {
                var mascotas = MascotaServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<MascotaModel, Mascota>(mascotas, uri));
            }
            catch (Exception ex)
            {
                Log.Error<MascotaController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return NotFound();
            }
        }

        // GET: api/Mascota/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mascota = MascotaServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<MascotaModel, Mascota>(mascota, uri));
            }
            catch (Exception ex)
            {
                Log.Error<MascotaController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        //// DELETE: api/Expediente/DelPermanent/5
        //[Route("AllByAdoptanteId/{id}")]
        //[HttpGet]
        //public IHttpActionResult AllByAdoptanteId(int id)
        //{
        //    try
        //    {
        //        var mascotas = MascotaServicio.GetAllByAdoptanteId(id);
        //        Uri uri = Url.Request.RequestUri;
        //        return Ok(ModelFactory.Create<MascotaModel, Mascota>(mascotas, uri));
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error<MascotaController>("Delete Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
        //        return BadRequest();
        //    }
        //}

        // POST: api/Mascota
        public IHttpActionResult Post([FromBody]Mascota mascota)
        {
            try
            {
                mascota.Identificacion = MascotaServicio.Insert(mascota);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + mascota.Identificacion);
                return Created(uri, ModelFactory.Create<MascotaModel, Mascota>(mascota, uri));
            }
            catch (Exception ex)
            {
                Log.Error<MascotaController>("Post Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // PUT: api/Mascota/5
        public IHttpActionResult Put(string id, [FromBody]Mascota mascota)
        {
            try
            {
                mascota.Identificacion = id;
                MascotaServicio.Update(mascota);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<MascotaController>("Put Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
		
		// DELETE: api/Mascota/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                MascotaServicio.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<MascotaController>("Delete Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
