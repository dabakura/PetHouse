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
    [RoutePrefix("api/Expediente")]
    [Authorize]
    public class ExpedienteController : BaseApiController
    {
        public IExpedienteService ExpedienteServicio { get; }

        public ExpedienteController()
        {
            ExpedienteServicio = new ExpedienteRepositorio();
        }

        // GET: api/Expediente
        public IHttpActionResult Get()
        {
            try
            {
                var expedientes = ExpedienteServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<ExpedienteModel,Expediente>(expedientes, uri));
            }
            catch (Exception ex)
            {
                Log.Error<ExpedienteController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return NotFound();
            }
        }

        // GET: api/Expediente/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var expediente = ExpedienteServicio.Get(id);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + expediente.Id);
                return Ok(ModelFactory.Create<ExpedienteModel, Expediente>(expediente, uri));
            }
            catch (Exception ex)
            {
                Log.Error<ExpedienteController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // POST: api/Expediente
        public IHttpActionResult Post([FromBody]Expediente expediente)
        {
            try
            {
                expediente.Id = ExpedienteServicio.Insert(expediente);
                Uri uri = Url.Request.RequestUri;
                return Created(uri, ModelFactory.Create<ExpedienteModel, Expediente>(expediente, uri));
            }
            catch (Exception ex)
            {
                Log.Error<ExpedienteController>("Post Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // PUT: api/Expediente/5
        public IHttpActionResult Put(string id, [FromBody]Expediente expediente)
        {
            try
            {
                expediente.Id = id;
                ExpedienteServicio.Update(expediente);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<ExpedienteController>("Put Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
		
		// DELETE: api/Expediente/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                ExpedienteServicio.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<ExpedienteController>("Delete Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // DELETE: api/Expediente/DelPermanent/5
        [Route("DelPermanent/{id}")]
        [HttpDelete]
        public IHttpActionResult DelPermanent(string id)
        {
            try
            {
                ExpedienteServicio.DeletePermanent(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<ExpedienteController>("Delete Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
