﻿using PetHouse.API.Models;
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
    [RoutePrefix("api/Domicilio")]
    [Authorize]
    public class DomicilioController : BaseApiController
    {
        public IDomicilioService DomicilioServicio { get; }


        public DomicilioController()
        {
            DomicilioServicio = new DomicilioRepositorio();
        }

        // GET: api/Domicilio
        public IHttpActionResult Get()
        {
            try
            {
                var domicilios = DomicilioServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<DomicilioModel,Domicilio>(domicilios, uri));
            }
            catch (Exception ex)
            {
                Log.Error<DomicilioController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return NotFound();
            }
        }

        // GET: api/Domicilio/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var domicilio = DomicilioServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<DomicilioModel, Domicilio>(domicilio, uri));
            }
            catch (Exception ex)
            {
                Log.Error<DomicilioController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // POST: api/Domicilio
        public IHttpActionResult Post([FromBody]Domicilio domicilio)
        {
            try
            {
                domicilio.Id = DomicilioServicio.Insert(domicilio);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + domicilio.Id);
                return Created(uri, ModelFactory.Create<DomicilioModel, Domicilio>(domicilio, uri));
            }
            catch (Exception ex)
            {
                Log.Error<DomicilioController>("POST Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // PUT: api/Domicilio/5
        public IHttpActionResult Put(string id, [FromBody]Domicilio domicilio)
        {
            try
            {
                domicilio.Id = Convert.ToInt32(id);
                DomicilioServicio.Update(domicilio);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<DomicilioController>("PUT Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
		
		// DELETE: api/Domicilio/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                DomicilioServicio.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<DomicilioController>("DELETE Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
