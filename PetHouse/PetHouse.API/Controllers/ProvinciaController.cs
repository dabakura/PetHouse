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
    [RoutePrefix("api/Provincia")]
    public class ProvinciaController : BaseApiController
    {
        public IProvinciaService ProvinciaServicio { get; }

        public ProvinciaController()
        {
            ProvinciaServicio = new ProvinciaRepositorio();
        }

        // GET: api/Provincia
        public IHttpActionResult Get()
        {
            try
            {
                var provincias = ProvinciaServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<ProvinciaModel, Provincia>(provincias, uri));
            }
            catch (Exception ex)
            {
                Log.Error<ProvinciaController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return NotFound();
            }
        }

        // GET: api/Provincia/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var provincia = ProvinciaServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<ProvinciaModel, Provincia>(provincia, uri));
            }
            catch (Exception ex)
            {
                Log.Error<ProvinciaController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // POST: api/Provincia
        public IHttpActionResult Post([FromBody]Provincia provincia)
        {
            try
            {
                provincia.Id = ProvinciaServicio.Insert(provincia);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + provincia.Id);
                return Created(uri, ModelFactory.Create<ProvinciaModel, Provincia>(provincia, uri));
            }
            catch (Exception ex)
            {
                Log.Error<ProvinciaController>("Post Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // PUT: api/Provincia/5
        public IHttpActionResult Put(string id, [FromBody]Provincia provincia)
        {
            try
            {
                provincia.Id = Convert.ToInt32(id);
                ProvinciaServicio.Update(provincia);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<ProvinciaController>("Put Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
