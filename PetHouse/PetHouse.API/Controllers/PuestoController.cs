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
    [RoutePrefix("api/Puesto")]
    [Authorize]
    public class PuestoController : BaseApiController
    {
        public IPuestoService PuestoServicio { get; }

        public PuestoController()
        {
            PuestoServicio = new PuestoRepositorio();
        }

        // GET: api/Puesto
        public IHttpActionResult Get()
        {
            try
            {
                var puestos = PuestoServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<PuestoModel, Puesto>(puestos, uri));
            }
            catch (Exception ex)
            {
                Log.Error<PuestoController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return NotFound();
            }
        }

        // GET: api/Puesto/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var puesto = PuestoServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<PuestoModel, Puesto>(puesto, uri));
            }
            catch (Exception ex)
            {
                Log.Error<PuestoController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // POST: api/Puesto
        public IHttpActionResult Post([FromBody]Puesto puesto)
        {
            try
            {
                puesto.Id = PuestoServicio.Insert(puesto);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + puesto.Id);
                return Created(uri, ModelFactory.Create<PuestoModel, Puesto>(puesto, uri));
            }
            catch (Exception ex)
            {
                Log.Error<PuestoController>("Post Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // PUT: api/Puesto/5
        public IHttpActionResult Put(string id, [FromBody]Puesto puesto)
        {
            try
            {
                puesto.Id = Convert.ToInt32(id);
                PuestoServicio.Update(puesto);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<PuestoController>("Put Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
		
		// DELETE: api/Puesto/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                PuestoServicio.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<PuestoController>("Delete Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
