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
    [RoutePrefix("api/Tratamiento")]
    public class TratamientoController : ApiController
    {
        public ITratamientoService TratamientoServicio { get; }

        public TratamientoController()
        {
            TratamientoServicio = new TratamientoRepositorio();
        }

        // GET: api/Tratamiento/5
        [HttpGet]
        public IHttpActionResult GetAll(string idExpediente)
        {
            try
            {
                var tratamientos = TratamientoServicio.GetAll(idExpediente);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<TratamientoModel, Tratamiento>(tratamientos, uri));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Tratamiento/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var tratamiento = TratamientoServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<TratamientoModel, Tratamiento>(tratamiento, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Tratamiento
        public IHttpActionResult Post([FromBody]Tratamiento tratamiento)
        {
            try
            {
                tratamiento.Id = TratamientoServicio.Insert(tratamiento);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + tratamiento.Id);
                return Created(uri, ModelFactory.Create<TratamientoModel, Tratamiento>(tratamiento, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Tratamiento/5
        public IHttpActionResult Put(string id, [FromBody]Tratamiento tratamiento)
        {
            try
            {
                tratamiento.Id = Convert.ToInt32(id);
                TratamientoServicio.Update(tratamiento);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
		
		// DELETE: api/Tratamiento/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                TratamientoServicio.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
