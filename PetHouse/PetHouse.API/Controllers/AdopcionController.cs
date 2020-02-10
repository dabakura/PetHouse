using Microsoft.Owin.Logging;
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
    public class AdopcionController : BaseApiController
    {
        public IAdopcionService AdopcionServicio { get; }

        public AdopcionController()
        {
            AdopcionServicio = new AdopcionRepositorio();
        }

        // GET: api/Adopcion
        public IHttpActionResult Get()
        {
            try
            {
                var adopciones = AdopcionServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<AdopcionModel, Adopcion>(adopciones, uri));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Adopcion/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var adopcion = AdopcionServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<AdopcionModel, Adopcion>(adopcion,uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Adopcion
        public IHttpActionResult Post([FromBody]Adopcion adopcion)
        {
            try
            {
                adopcion.Id = AdopcionServicio.Insert(adopcion);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + adopcion.Id);
                return Created(uri, ModelFactory.Create<AdopcionModel, Adopcion>(adopcion, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Adopcion/5
        public IHttpActionResult Put(string id, [FromBody]Adopcion adopcion)
        {
            try
            {
                adopcion.Id = Convert.ToInt32(id);
                AdopcionServicio.Update(adopcion);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Adopcion/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                AdopcionServicio.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
