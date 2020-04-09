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
    [RoutePrefix("api/Vacuna")]
    [Authorize]
    public class VacunaController : BaseApiController
    {
        public IVacunaService VacunaServicio { get; }

        public VacunaController()
        {
            VacunaServicio = new VacunaRepositorio();
        }

        // GET: api/Vacuna
        public IHttpActionResult Get()
        {
            try
            {
                var vacunas = VacunaServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<VacunaModel, Vacuna>(vacunas, uri));
            }
            catch (Exception ex)
            {
                Log.Error<VacunaController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return NotFound();
            }
        }

        // GET: api/Vacuna/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var vacuna = VacunaServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<VacunaModel, Vacuna>(vacuna, uri));
            }
            catch (Exception ex)
            {
                Log.Error<VacunaController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // POST: api/Vacuna
        public IHttpActionResult Post([FromBody]Vacuna vacuna)
        {
            try
            {
                vacuna.Id = VacunaServicio.Insert(vacuna);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + vacuna.Id);
                return Created(uri, ModelFactory.Create<VacunaModel, Vacuna>(vacuna, uri));
            }
            catch (Exception ex)
            {
                Log.Error<VacunaController>("Post Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // PUT: api/Vacuna/5
        public IHttpActionResult Put(string id, [FromBody]Vacuna vacuna)
        {
            try
            {
                vacuna.Id = Convert.ToInt32(id);
                VacunaServicio.Update(vacuna);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<VacunaController>("Put Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
		
		// DELETE: api/Vacuna/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                VacunaServicio.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<VacunaController>("Delete Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
