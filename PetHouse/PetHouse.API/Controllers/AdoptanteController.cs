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
        public IMascotaService MascotaServicio { get; }

        public AdoptanteController()
        {
            AdoptanteServicio = new AdoptanteRepositorio();
            MascotaServicio = new MascotaRepositorio();
        }

        // GET: api/Adoptante
        public IHttpActionResult Get()
        {
            try
            {
                var adoptantes = AdoptanteServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                var adoptantesModel = ModelFactory.Create<AdoptanteModel, Adoptante>(adoptantes, uri);
                foreach (var adoptante in adoptantesModel)
                {
                    adoptante.Mascotas = MascotaServicio.GetAllByAdoptanteId(adoptante.Identificacion);
                }
                return Ok(adoptantesModel);
            }
            catch (Exception ex)
            {
                Log.Error<AdoptanteController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
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
                var adoptantesModel = ModelFactory.Create<AdoptanteModel, Adoptante>(adoptante, uri);
                if (adoptantesModel != null)
                    adoptantesModel.Mascotas = MascotaServicio.GetAllByAdoptanteId(adoptante.Identificacion);
                return Ok(adoptantesModel);
            }
            catch (Exception ex)
            {
                Log.Error<AdoptanteController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
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
            catch (Exception ex)
            {
                Log.Error<AdoptanteController>("Post Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
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
            catch (Exception ex)
            {
                Log.Error<AdoptanteController>("Put Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
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
            catch (Exception ex)
            {
                Log.Error<AdoptanteController>("Delete Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
