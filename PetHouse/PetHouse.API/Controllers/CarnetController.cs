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
    [RoutePrefix("api/Carnet")]
    public class CarnetController : ApiController
    {
        public ICarnetService CarnetServicio { get; }

        public CarnetController()
        {
            CarnetServicio = new CarnetRepositorio();
        }

        // GET: api/Carnet
        public IHttpActionResult Get()
        {
            try
            {
                var carnets = CarnetServicio.GetAll();
                return Ok(ModelFactory.Create(carnets));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Carnet/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var carnets = CarnetServicio.Get(id);
                return Ok(carnets);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: api/Carnet
        public IHttpActionResult Post([FromBody]Carnet carnet)
        {
            try
            {
                CarnetServicio.Insert(carnet);
                Uri uri = new Uri(Url.Request.RequestUri + "/" +carnet.ExpedienteId);
                return Created(uri, ModelFactory.Create(carnet, uri));
            }
            catch
            {
                return BadRequest();
            }
        }
		
		// DELETE: api/Carnet/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                CarnetServicio.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
