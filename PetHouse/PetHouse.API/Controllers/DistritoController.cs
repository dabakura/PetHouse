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
    [RoutePrefix("api/Distrito")]
    public class DistritoController : ApiController
    {
        public IDistritoService DistritoServicio { get; }

        public DistritoController()
        {
            DistritoServicio = new DistritoRepositorio();
        }

        // GET: api/Distrito
        public IHttpActionResult Get()
        {
            try
            {
                var distritos = DistritoServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<DistritoModel,Distrito>(distritos, uri));
            }
            catch (Exception ex)
            {
                Log.Error<DistritoController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return NotFound();
            }
        }

        // GET: api/Distrito/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var distrito = DistritoServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<DistritoModel, Distrito>(distrito, uri));
            }
            catch (Exception ex)
            {
                Log.Error<DistritoController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // POST: api/Distrito
        public IHttpActionResult Post([FromBody]Distrito distrito)
        {
            try
            {
                distrito.Id = DistritoServicio.Insert(distrito);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + distrito.Id);
                return Created(uri, ModelFactory.Create<DistritoModel, Distrito>(distrito, uri));
            }
            catch (Exception ex)
            {
                Log.Error<DistritoController>("Post Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // PUT: api/Distrito/5
        public IHttpActionResult Put(string id, [FromBody]Distrito distrito)
        {
            try
            {
                distrito.Id = Convert.ToInt32(id);
                DistritoServicio.Update(distrito);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<DistritoController>("Put Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
