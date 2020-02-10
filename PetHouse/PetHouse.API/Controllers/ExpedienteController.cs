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
    public class ExpedienteController : ApiController
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
                return Ok(ModelFactory.Create(expedientes));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Expediente/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var expediente = ExpedienteServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create(expediente, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Expediente
        public IHttpActionResult Post([FromBody]Expediente expediente)
        {
            try
            {
                expediente.Id = ExpedienteServicio.Insert(expediente);
                Uri uri = new Uri(Url.Request.RequestUri + "/" +expediente.Id);
                return Created(uri, ModelFactory.Create(expediente, uri));
            }
            catch
            {
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
            catch
            {
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
            catch
            {
                return BadRequest();
            }
        }
    }
}
