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
    [RoutePrefix("api/Institucion")]
    public class InstitucionController : ApiController
    {
        public IInstitucionService InstitucionServicio { get; }

        public InstitucionController()
        {
            InstitucionServicio = new InstitucionRepositorio();
        }

        // GET: api/Institucion
        public IHttpActionResult Get()
        {
            try
            {
                var instituciones = InstitucionServicio.GetAll();
                return Ok(ModelFactory.Create(instituciones));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Institucion/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var institucion = InstitucionServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create(institucion, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Institucion
        public IHttpActionResult Post([FromBody]Institucion institucion)
        {
            try
            {
                institucion.Id = InstitucionServicio.Insert(institucion);
                Uri uri = new Uri(Url.Request.RequestUri + "/" +institucion.Id);
                return Created(uri, ModelFactory.Create(institucion, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Institucion/5
        public IHttpActionResult Put(string id, [FromBody]Institucion institucion)
        {
            try
            {
                institucion.Id = Convert.ToInt32(id);
                InstitucionServicio.Update(institucion);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
		
		// DELETE: api/Institucion/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                InstitucionServicio.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
