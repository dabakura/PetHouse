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
    [RoutePrefix("api/Domicilio")]
    public class DomicilioController : ApiController
    {
        public IDomicilioService DomicilioServicio { get; }

        public DomicilioController()
        {
            DomicilioServicio = new DomicilioRepositorio();
        }

        // GET: api/Domicilio
        public IHttpActionResult Get()
        {
            try
            {
                var domicilios = DomicilioServicio.GetAll();
                return Ok(ModelFactory.Create(domicilios));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Domicilio/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var domicilio = DomicilioServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create(domicilio, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Domicilio
        public IHttpActionResult Post([FromBody]Domicilio domicilio)
        {
            try
            {
                domicilio.Id = DomicilioServicio.Insert(domicilio);
                Uri uri = new Uri(Url.Request.RequestUri + "/" +domicilio.Id);
                return Created(uri, ModelFactory.Create(domicilio, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Domicilio/5
        public IHttpActionResult Put(string id, [FromBody]Domicilio domicilio)
        {
            try
            {
                domicilio.Id = Convert.ToInt32(id);
                DomicilioServicio.Update(domicilio);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
		
		// DELETE: api/Domicilio/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                DomicilioServicio.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
