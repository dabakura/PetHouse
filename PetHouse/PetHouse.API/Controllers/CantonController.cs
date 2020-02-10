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
    [RoutePrefix("api/Canton")]
    public class CantonController : ApiController
    {
        public ICantonService CantonServicio { get; }

        public CantonController()
        {
            CantonServicio = new CantonRepositorio();
        }

        // GET: api/Canton
        public IHttpActionResult Get()
        {
            try
            {
                var cantones = CantonServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<CantonModel,Canton>(cantones, uri));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Canton/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var canton = CantonServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<CantonModel, Canton>(canton, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Canton
        public IHttpActionResult Post([FromBody]Canton canton)
        {
            try
            {
                canton.Id = CantonServicio.Insert(canton);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + canton.Id);
                return Created(uri, ModelFactory.Create<CantonModel, Canton>(canton, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Canton/5
        public IHttpActionResult Put(string id, [FromBody]Canton canton)
        {
            try
            {
                canton.Id = Convert.ToInt32(id);
                CantonServicio.Update(canton);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
