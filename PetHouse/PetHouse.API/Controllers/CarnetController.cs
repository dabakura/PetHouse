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
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<CarnetModel,Carnet>(carnets, uri));
            }
            catch (Exception ex)
            {
                Log.Error<CarnetController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return NotFound();
            }
        }

        // GET: api/Carnet/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var carnets = CarnetServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<CarnetModel, Carnet>(carnets, uri));
            }
            catch (Exception ex)
            {
                Log.Error<CarnetController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return NotFound();
            }
        }

        // POST: api/Carnet
        public IHttpActionResult Post([FromBody]Carnet carnet)
        {
            try
            {
                carnet = CarnetServicio.Insert(carnet);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + carnet.ExpedienteId);
                return Created(uri, ModelFactory.Create<CarnetModel, Carnet>(carnet, uri));
            }
            catch (Exception ex)
            {
                Log.Error<CarnetController>("Post Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
		
		// DELETE: api/Carnet/5
        public IHttpActionResult Delete(string idExpediente, int idVacuna)
        {
            try
            {
                CarnetServicio.DeleteVacuna(idExpediente,idVacuna);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<CarnetController>("Delete Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
