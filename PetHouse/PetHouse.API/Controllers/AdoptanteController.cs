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
    [RoutePrefix("api/Adoptante")]
    public class AdoptanteController : ApiController
    {
        public IAdoptanteService AdoptanteServicio { get; }

        public AdoptanteController()
        {
            AdoptanteServicio = new AdoptanteRepositorio();
        }

        // GET: api/Adoptante
        public IHttpActionResult Get()
        {
            try
            {
                var adoptantes = AdoptanteServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<AdoptanteModel, Adoptante>(adoptantes, uri));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Adoptante/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var adoptante = AdoptanteServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<AdoptanteModel, Adoptante>(adoptante, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Adoptante
        public IHttpActionResult Post([FromBody]Adoptante adoptante)
        {
            try
            {
                adoptante.Id = AdoptanteServicio.Insert(adoptante);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + adoptante.Id);
                return Created(uri, ModelFactory.Create<AdoptanteModel, Adoptante>(adoptante, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Adoptante/5
        public IHttpActionResult Put(string id, [FromBody]Adoptante adoptante)
        {
            try
            {
                adoptante.Id = Convert.ToInt32(id);
                AdoptanteServicio.Update(adoptante);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Adoptante/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                AdoptanteServicio.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
