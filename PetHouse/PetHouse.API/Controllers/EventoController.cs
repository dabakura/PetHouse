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
    [RoutePrefix("api/Evento")]
    [Authorize]
    public class EventoController : BaseApiController
    {
        public IEventoService EventoServicio { get; }


        public EventoController()
        {
            EventoServicio = new EventoRepositorio();
        }

        // GET: api/Evento
        public IHttpActionResult Get()
        {
            try
            {
                var eventos = EventoServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<EventoModel,Evento>(eventos, uri));
            }
            catch (Exception ex)
            {
                Log.Error<EventoController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return NotFound();
            }
        }

        // GET: api/Evento/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var evento = EventoServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<EventoModel, Evento>(evento, uri));
            }
            catch (Exception ex)
            {
                Log.Error<EventoController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // POST: api/Evento
        public IHttpActionResult Post([FromBody]Evento evento)
        {
            try
            {
                evento.Id = EventoServicio.Insert(evento);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + evento.Id);
                return Created(uri, ModelFactory.Create<EventoModel, Evento>(evento, uri));
            }
            catch (Exception ex)
            {
                Log.Error<EventoController>("POST Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // PUT: api/Evento/5
        public IHttpActionResult Put(string id, [FromBody]Evento evento)
        {
            try
            {
                evento.Id = Convert.ToInt32(id);
                EventoServicio.Update(evento);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<EventoController>("PUT Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
		
		// DELETE: api/Evento/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                EventoServicio.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<EventoController>("DELETE Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
